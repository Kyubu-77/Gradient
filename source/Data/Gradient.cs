using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Xml;
using C = LED_Planer.Constants;

namespace LED_Planer.Data
{
    /// <summary>
    /// Color Gradient build from 3 (R,G,B) color curves, the curvers are build from Keys, 
    /// the space between the keys is called Segmentinfo and attached to the segments left key.
    /// </summary>
    public class Gradient
    {
        static Random rnd1 = new Random();

        public String name;

        public Graph.Graph2D graph;

        private Curve[] curves = new Curve[3];

        private Curve redCurve;
        public Curve RedCurve { get => redCurve; }

        private Curve greenCurve;
        public Curve GreenCurve { get => greenCurve; }

        private Curve blueCurve;
        public Curve BlueCurve { get => blueCurve; }

        Gradient(string name)
        {
            this.name = name;
            graph = new Graph.Graph2D();
        }

        void AddCurve(Curve curve, int tag)
        {
            curves[tag] = curve;
            graph.AddCurve(curve);

            if (tag == C.RED)
            {
                if (redCurve != null) throw new Exception("Red curve already set");
                redCurve = curve;
            }
            else if (tag == C.GREEN)
            {
                if (greenCurve != null) throw new Exception("Green curve already set");
                greenCurve = curve;
            }
            else if (tag == C.BLUE)
            {
                if (blueCurve != null) throw new Exception("Blue curve already set");
                blueCurve = curve;
            }

            curve.RefreshInterpolation();
        }

        public static Gradient CreateDefaultGradient()
        {
            Gradient grad = new Gradient("new " + (int)(rnd1.NextDouble() * 100));

            Curve redCurve = new Curve(Color.Red, C.RED);
            Curve greenCurve = new Curve(Color.Green, C.GREEN);
            Curve blueCurve = new Curve(Color.Blue, C.BLUE);

            redCurve.AddKey(0.0f, 0, SegmentKind.Line, C.RED);
            greenCurve.AddKey(0.0f, 0.55f, SegmentKind.Line, C.GREEN);
            blueCurve.AddKey(0.0f, 0, SegmentKind.Line, C.BLUE);

            redCurve.AddKey(0.5f, 0.25f, SegmentKind.Line, C.RED);
            greenCurve.AddKey(0.5f, 0.5f, SegmentKind.Line, C.GREEN);
            blueCurve.AddKey(0.5f, 0.75f, SegmentKind.Line, C.BLUE);

            redCurve.AddKey(1.0f, 1f, SegmentKind.Line, C.RED);
            greenCurve.AddKey(1.0f, 0.55f, SegmentKind.Line, C.GREEN);
            blueCurve.AddKey(1.0f, 0, SegmentKind.Line, C.BLUE);

            grad.AddCurve(redCurve, redCurve.Tag);
            grad.AddCurve(greenCurve, greenCurve.Tag);
            grad.AddCurve(blueCurve, blueCurve.Tag);

            return grad;
        }

        /// <summary>
        /// Create new keys on all curves and return the new keys so that they can be added to a selection
        /// </summary>
        public Key[] AddKeysAtPositionX(float x, Color color)
        {
            Key[] ret = new Key[3];
            Key redKey = redCurve.AddKey(x, color.R / 255.0f, SegmentKind.Line, C.RED);
            Key greenKey = greenCurve.AddKey(x, color.G / 255.0f, SegmentKind.Line, C.GREEN);
            Key blueKey = blueCurve.AddKey(x, color.B / 255.0f, SegmentKind.Line, C.BLUE);

            ret[C.RED] = redKey;
            ret[C.GREEN] = greenKey;
            ret[C.BLUE] = blueKey;

            return ret;
        }

        public void DeleteKey(Key key)
        {
            Curve curve = GetCurveByTag(key.Tag);
            curve.DeleteKey(key);
        }

        public void SortPoints()
        {
            foreach (Curve curve in curves) curve.SortPoints();
        }

        // Create list for combobox grdPoint items
        public SortedList<float, LBE.ComboKeyInfo> getUniqueKeyPositions()
        {
            SortedList<float, LBE.ComboKeyInfo> sortedLists = new SortedList<float, LBE.ComboKeyInfo>();

            foreach (Key key in redCurve.GetKeys())
            {
                if (sortedLists.ContainsKey(key.Position.X))
                {
                    sortedLists[key.Position.X].Text = sortedLists[key.Position.X].Text + "R";
                    sortedLists[key.Position.X].AddKey(key);
                }
                else
                {
                    sortedLists[key.Position.X] = new LBE.ComboKeyInfo(key, "R");
                }
            }

            foreach (Key key in greenCurve.GetKeys())
            {
                if (sortedLists.ContainsKey(key.Position.X))
                {
                    sortedLists[key.Position.X].Text = sortedLists[key.Position.X].Text + "G";
                    sortedLists[key.Position.X].AddKey(key);
                }
                else
                {
                    sortedLists[key.Position.X] = new LBE.ComboKeyInfo(key, "G");
                }
            }
            foreach (Key key in blueCurve.GetKeys())
            {
                if (sortedLists.ContainsKey(key.Position.X))
                {
                    sortedLists[key.Position.X].Text = sortedLists[key.Position.X].Text + "B";
                    sortedLists[key.Position.X].AddKey(key);
                }
                else
                {
                    sortedLists[key.Position.X] = new LBE.ComboKeyInfo(key, "B");
                }
            }

            return sortedLists;
        }

        public override string ToString()
        {
            return name;
        }

        public Curve GetCurveByTag(int tag)
        {
            if (tag == Constants.RED)
            {
                return redCurve;
            }
            if (tag == Constants.GREEN)
            {
                return greenCurve;
            }
            if (tag == Constants.BLUE)
            {
                return blueCurve;
            }
            return null;
        }

        /// <summary>
        /// Used to find a position when inserting a new point
        /// </summary>
        public Key FindFirstKeyRightOf(Key point)
        {
            Key foundKey = null;
            foreach (Curve curve in curves)
            {
                foreach (Key key in curve.GetKeys())
                {
                    // not same point, key is right of point, dist is shorter
                    if (point != key && (point.Position.X < key.Position.X))
                    {
                        if (foundKey == null)
                        {
                            foundKey = key;
                        }
                        else
                        {
                            if (key.Position.X < foundKey.Position.X)
                            {
                                foundKey = key;
                            }
                        }
                    }
                }
            }

            return foundKey;
        }

        public Color GetColorAt(float v)
        {
            float r = Utils.LimitFloatZeroToOne(redCurve.GetValueAtX(v));
            float g = Utils.LimitFloatZeroToOne(greenCurve.GetValueAtX(v));
            float b = Utils.LimitFloatZeroToOne(blueCurve.GetValueAtX(v));

            return Color.FromArgb(255, (int)(r * 255f), (int)(g * 255f), (int)(b * 255f));
        }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Gradient");
            elem.SetAttribute("Name", name);

            foreach (Curve c in curves)
            {
                elem.AppendChild(c.ToXml(doc));
            }

            return elem;
        }

        public static Gradient FromXML(XmlElement elem)
        {

            Gradient gradient = new Gradient(elem.Attributes["Name"].Value);

            foreach (XmlNode c in elem.ChildNodes)
            {
                if (c.Name == "Curve")
                {
                    Curve curve = Curve.FromXML((XmlElement)c);
                    gradient.AddCurve(curve, curve.Tag);

                }

            }
            return gradient;
        }

    }
}
