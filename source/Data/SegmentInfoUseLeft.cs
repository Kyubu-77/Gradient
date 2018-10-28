using System.Numerics;

namespace LED_Planer.Data
{
    public class SegmentInfoUseLeft : SegmentInfo
    {
        
        public SegmentInfoUseLeft(Key key, Key right)
        {
            type = SegmentKind.UseLeft;
            this.key = key;
            this.right = right;
            
        }
        public override float getValueAt(float v)
        {
            return key.Position.Y;
        }

        public override void recalc()
        {
            points = new Vector2[]  {
               key.Position,
            new Vector2(right.Position.X, key.Position.Y)
            };
        }
    }
}