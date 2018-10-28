using System.Numerics;

namespace LED_Planer.Data
{
    internal class SegmentInfoLinear : SegmentInfo
    {
        public SegmentInfoLinear(Key key, Key right)
        {
            type = SegmentKind.Line;
            this.key = key;
            this.right = right;
        }

        public override float getValueAt(float v)
        {
            if (right == null) return 0;

            Vector2 dist = right.Position - key.Position;
            

            float f = (v - key.Position.X) / dist.X;

            return key.Position.Y + dist.Y * f;
        }


        public override void recalc()
        {
            points = new Vector2[]  {
                key.Position,
                right.Position
            };
        }
    }
}