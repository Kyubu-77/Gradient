using System;
using System.Numerics;

namespace LED_Planer.Data
{
    internal class SegmentInfoBezier : SegmentInfo
    {
        public SegmentInfoBezier(Key key, Key right)
        {
            type = SegmentKind.Bezier;
            this.key = key;
            this.right = right;
        }

        public override float getValueAt(float v)
        {
            int i = (points.Length - 1) / 2;
            float change = i / 2;
            int found = -1;

            while (found == -1)
            {
                if (points[i].X <= v && v < points[i + 1].X)
                {
                    found = i;
                }
                else if (v < points[i].X)
                {
                    i = (int)(i - change);
                    change /= 2;
                }
                else
                {
                    i = (int)(i + change);
                    change /= 2;


                }
                change = (int)Math.Max(change, 1);
            }
            return Interpolate(points[i], points[i + 1], v);
        }

        static public float Interpolate(Vector2 left, Vector2 right, float v)
        {
            if (right == null) return 0;

            float distX = (right.X - left.X);
            float distY = (right.Y - left.Y);

            float f = (v - left.X) / distX;

            return left.Y + distY * f;
        }

        public override void recalc()
        {

            float stepWithOnXY = 1.0f / Constants.BezierSegmentSteps;

            float d4 = (right.Position.X - key.Position.X) / 4f;

            if (key.RightAnchor == null)
            {
                key.RightAnchor = new Data.Anchor(new Vector2(key.Position.X + d4, key.Position.Y), Side.Right);
            }
            else
            {
                if (key.RightAnchor.PosCal == AnchorPosition.AutoOnQuarter)
                {
                    key.RightAnchor.Position =new Vector2(key.Position.X + d4, key.Position.Y);
                }
                else
                {
                    // check constrains on w
                    Vector2 pos = key.RightAnchor.Position;
                    key.RightAnchor.Position = Vector2.Clamp(pos, new Vector2(key.Position.X, Constants.lu.Y), new Vector2(right.Position.X, Constants.ro.Y));
                }
            }

            if (right.LeftAnchor == null)
            {
                right.LeftAnchor = new Data.Anchor( new Vector2(right.Position.X - d4, right.Position.Y), Side.Left);
            }
            else
            {
                if (right.LeftAnchor.PosCal == AnchorPosition.AutoOnQuarter)
                {
                    right.LeftAnchor.Position = new Vector2(right.Position.X - d4, right.Position.Y);
                }
                else
                {
                    // clamp
                    Vector2 pos = right.LeftAnchor.Position;
                    right.LeftAnchor.Position = Vector2.Clamp(pos, new Vector2(key.Position.X, Constants.lu.Y), new Vector2(right.Position.X, Constants.ro.Y));
                }
            }

            points = Bezier.getBezierPoints(
                key.Position,
                key.RightAnchor.Position,
                right.LeftAnchor.Position,
                right.Position,
                stepWithOnXY);
        }
    }
}