using System;

using System.Drawing;

using System.Xml;
using U = LED_Planer.Utils;

namespace LED_Planer.Data
{
    /// <summary>
    /// A curve for one color e.g. red, green or blue
    /// </summary>
    public class Curve
    {
        private Color color;
        public Color Color { get { return color; } }

        private bool dirty; // some curve points have been changed and all segment whose keys are dirty too will be reinterpolated
        public bool IsDirty { get => dirty; set => dirty = value; }

        private Key[] keys; // list of keys defining the position of the curve points, ordered by position
        public Key[] GetKeys() { return keys; }

        private int tag; // used to distinguish the red, green and blue curve
        public int Tag { get => tag; }

        public Curve(Color color, int tag)
        {
            this.color = color;
            this.tag = tag;

            dirty = true;
            keys = new Key[0];
        }


        public Key AddKey(float x, float y, SegmentKind type, int tag)
        {
            Key key = new Key(x, y, type, tag);
            return AddKey(key);
        }

        public Key AddKey(Key key)
        {
            // find insert position
            int i = 0;
            while (i < keys.Length && keys[i].Position.X < key.Position.X) i++;

            // insert
            U.Insert(ref keys, i, key);

            // link/relink
            if (i > 0)
            {
                key.Left = keys[i - 1];
                key.Left.Right = key;
            }
            else
            {
                key.Left = null;
            }

            if (i < keys.Length - 1)
            {
                key.Right = keys[i + 1];
                key.Right.Left = key;
            }
            else
            {
                key.Right = null;
            }

            dirty = true;

            return key;
        }

        public void DeleteKey(Key key)
        {
            if (key.Left != null)
            {
                key.Left.Right = key.Right;
                key.Left.IsDirty = true;
            }
            if (key.Right != null)
            {
                key.Right.Left = key.Left;
                key.Right.IsDirty = true;
            }

            U.Remove(keys, key);
            dirty = true;
        }

        public void RefreshInterpolation()
        {
            if (!dirty) return;

            for (int i = 0; i < keys.Length - 1; i++)
            {

                Key left = keys[i];
                Key right = keys[i + 1];

                if (!(left.IsDirty || right.IsDirty)) continue;

                left.CalcSegmentInfo(right);
            }
            dirty = false;
        }

        public float GetValueAtX(float v)
        {
            if (keys.Length == 0) return 0;

            if (v < keys[0].Position.X) return keys[0].Position.Y;
            if (keys[keys.Length - 1].Position.X <= v) return keys[keys.Length - 1].Position.Y;

            int i = 0;

            // find segment to use
            while (keys[i].Right != null && v >= keys[i].Right.Position.X) i++;

            // peek into segment
            return keys[i].SegmentInfo.getValueAt(v);
        }

        public void SortPoints()
        {
            Key[] origOrder = (Key[])keys.Clone();
            Array.Sort(keys, delegate (Key a, Key b)
            {
                if (a.Position.X < b.Position.X)
                {
                    return -1;
                }
                else if (a.Position.X > b.Position.X)
                {
                    return 1;
                }
                return 0;

            });

            for (int i = 0; i < keys.Length; i++)
            {
                Key key = keys[i];
                if (keys[i] != origOrder[i]) key.IsDirty = true;
                key.Left = (i > 0) ? keys[i - 1] : null;
                key.Right = (i < keys.Length - 1) ? keys[i + 1] : null;
            }
            dirty = true;
        }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Curve");
            elem.SetAttribute("a", color.A.ToString());
            elem.SetAttribute("r", color.R.ToString());
            elem.SetAttribute("g", color.G.ToString());
            elem.SetAttribute("b", color.B.ToString());
            elem.SetAttribute("tag", tag.ToString());

            foreach (Key key in GetKeys())
            {
                elem.AppendChild(key.WriteToXml(doc));
            }

            return elem;
        }

        public static Curve FromXML(XmlElement elem)
        {
            byte a = Convert.ToByte(elem.Attributes["a"].Value);
            byte r = Convert.ToByte(elem.Attributes["r"].Value);
            byte g = Convert.ToByte(elem.Attributes["g"].Value);
            byte b = Convert.ToByte(elem.Attributes["b"].Value);
            byte tag = Convert.ToByte(elem.Attributes["tag"].Value);

            Curve curve = new Curve(Color.FromArgb(a, r, g, b), tag);

            foreach (XmlNode c in elem.ChildNodes)
            {
                if (c.Name == "Key")
                {
                    Key key = Key.FromXML((XmlElement)c, tag);
                    curve.AddKey(key);
                }

            }

            return curve;
        }
    }
}
