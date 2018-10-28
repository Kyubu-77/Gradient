using System;
using System.Numerics;
using System.Xml;

namespace LED_Planer.Data
{

    public class Key : IEquatable<Key>, Bind.IMovable
    {
        Key left = null;
        public Key Left { get => left; set => left = value; }

        Key right = null;
        public Key Right { get => right; set => right = value; }

        int tag;
        public int Tag { get => tag; }

        bool isDirty;
        public bool IsDirty { get => isDirty; set => isDirty = value; }

        bool isSelected;
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public Vector2 Position;

        Anchor leftAnchor;
        public Anchor LeftAnchor { get => leftAnchor; set => leftAnchor = value; }
        Anchor rightAnchor;
        public Data.Anchor RightAnchor { get => rightAnchor; set => rightAnchor = value; }


        private SegmentKind segmentKind;
        public SegmentInfo SegmentInfo { get => segmentInfo; set => segmentInfo = value; }

        SegmentInfo segmentInfo;
        public void setPosition(Vector2 v)
        {
            Position = v;
        }

        public void setPosition(Vector2 v, bool repositionAnchors = false)
        {
            if (!repositionAnchors)
            {
                Position = v;
            }
            else
            {
                Vector2 offs = v - Position;
                Position += offs;
            }
        }

        public SegmentKind getSegmentType()
        {
            if (right != null)
            {
                return segmentKind;


            }
            return SegmentKind.None; // The rightest point have no segment type
        }

        public Key(float x, float y, SegmentKind type, int tag)
        {
            isDirty = true;
            isSelected = false;
            Position = new Vector2(x, y);
            segmentKind = type;
            segmentInfo = null;

            leftAnchor = null;
            rightAnchor = null;
            this.tag = tag;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void CalcSegmentInfo(Key right)
        {
            if (segmentInfo == null || (segmentInfo != null && segmentInfo.GetSegmentType != segmentKind)
                || (segmentInfo.right != right))
            {
                switch (segmentKind)
                {
                    case SegmentKind.UseLeft:
                        segmentInfo = new SegmentInfoUseLeft(this, right);
                        break;
                    case SegmentKind.UseRight:
                        segmentInfo = new SegmentInfoUseRight(this, right);
                        break;
                    case SegmentKind.Line:
                        segmentInfo = new SegmentInfoLinear(this, right);
                        break;
                    case SegmentKind.Bezier:
                        segmentInfo = new SegmentInfoBezier(this, right);
                        break;
                }
            }
            segmentInfo.recalc();
        }

        internal void setSegmentType(SegmentKind st)
        {
            segmentKind = st;
        }

        public bool Equals(Key other)
        {
            return this == other;
        }


        public XmlElement WriteToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Key");
            //elem.SetAttribute("Tag", Tag.ToString());
            elem.SetAttribute("X", Position.X.ToString());
            elem.SetAttribute("Y", Position.Y.ToString());
            elem.SetAttribute("SegmentKind", ((int)segmentKind).ToString());

            if (leftAnchor != null)
            {
                elem.AppendChild(leftAnchor.ToXml(doc, "LeftAnchor"));
            }
            if (rightAnchor != null)
            {
                elem.AppendChild(rightAnchor.ToXml(doc, "RightAnchor"));
            }
            return elem;
        }

        public static Key FromXML(XmlElement elem, int tag)
        {
            //int tag = (int)Convert.ToDouble(elem.Attributes["Tag"].Value);
            float x = (float)Convert.ToDouble(elem.Attributes["X"].Value);
            float y = (float)Convert.ToDouble(elem.Attributes["Y"].Value);


            int segmentKindInt = Convert.ToByte(elem.Attributes["SegmentKind"].Value);
            SegmentKind segmentKind = SegmentKind.None;
            switch (segmentKindInt)
            {
                case (int)SegmentKind.None:
                    segmentKind = SegmentKind.None;
                    break;
                case (int)SegmentKind.UseLeft:
                    segmentKind = SegmentKind.UseLeft;
                    break;
                case (int)SegmentKind.UseRight:
                    segmentKind = SegmentKind.UseRight;
                    break;
                case (int)SegmentKind.Line:
                    segmentKind = SegmentKind.Line;
                    break;
                case (int)SegmentKind.Bezier:
                    segmentKind = SegmentKind.Bezier;
                    break;
            }
            Key key = new Key(x, y, segmentKind, tag);
            foreach (XmlNode c in elem.ChildNodes)
            {
                XmlElement cElement = (XmlElement)c;

                if (c.Name == "LeftAnchor")
                {
                    key.leftAnchor = Data.Anchor.FromXML(cElement, Side.Left);
                }
                else if (c.Name == "RightAnchor")
                {
                    key.rightAnchor = Data.Anchor.FromXML(cElement, Side.Right);
                }
            }


            key.isDirty = true;
            return key;
        }
    }
}
