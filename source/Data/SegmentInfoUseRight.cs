using System.Numerics;

namespace LED_Planer.Data
{
    internal class SegmentInfoUseRight : SegmentInfo
    {
        

        public SegmentInfoUseRight(Key key, Key right)
        {
            type = SegmentKind.UseRight;
            this.key = key;
            this.right = right;
        }

        public override float getValueAt(float v)
        {
            if (right == null) return 0;
            return right.Position.Y;
        }


        public override void recalc()
        {
            points = new Vector2[]  {
                new Vector2(key.Position.X, right.Position.Y),
                right.Position
            };
        }
    }
}