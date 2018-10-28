using System.Numerics;

namespace LED_Planer.Data
{
    public abstract class SegmentInfo
    {
        protected SegmentKind type;
        public Vector2[] points;
        public Key key;
        public Key right;


        public SegmentInfo()
        {
            type = SegmentKind.Line;
            points = null;
        }

        public abstract void recalc();
        public abstract float getValueAt(float v);
        public SegmentKind GetSegmentType { get { return type; } }
    }
}
