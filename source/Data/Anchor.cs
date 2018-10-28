using System;
using System.Numerics;
using System.Xml;

namespace LED_Planer.Data
{
    /// <summary>
    /// A anchor for moving the bezier control point
    /// Every segment of type Bezier has 2 anchor points.
    /// </summary>
    public class Anchor : Bind.IMovable
    {
        private bool isSelected;
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public Vector2 position;
        public Vector2 Position { get => position; set => position = value; }
        public void SetPosition(Vector2 position) { Position = position; }

        private AnchorPosition posCal;
        public AnchorPosition PosCal { get => posCal; set => posCal = value; }

        private Side side;
        public Side Side { get => side; }
        
        public Anchor(Vector2 position, Side side)
        {
            this.side = side;
            this.position = position;

            posCal = AnchorPosition.AutoOnQuarter;
            isSelected = false;
        }
        
        public XmlElement ToXml(XmlDocument doc, string name)
        {
            XmlElement elem = doc.CreateElement(name);
            elem.SetAttribute("X", Position.X.ToString());
            elem.SetAttribute("Y", Position.Y.ToString());
            return elem;
        }

        public static Anchor FromXML(XmlElement elem, Side side)
        {
            float x = (float)Convert.ToDouble(elem.Attributes["X"].Value);
            float y = (float)Convert.ToDouble(elem.Attributes["Y"].Value);
            return new Anchor( new Vector2(x, y), side);
        }
    }
}
