using System;
using System.Numerics;

namespace LED_Planer
{
    /// <summary>
    /// Calculates a bezier curve throught 4 points
    /// </summary>
    public class Bezier
    {
        public static Vector2[] getBezierPoints(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float stepWith) // step with in p0-p3 coord space
        {
            float xs = p0.X;
            float xe = p3.X;

            if (xe - xs <= stepWith) // avoid overhead
            {
                return new Vector2[] { p0, p3 };
            }

            int steps = Math.Max((int)((xe - xs) / stepWith), 16); // min 8 steps

            float tStepWith = 1.0f / steps;
            float t;


            Vector2[] ret = new Vector2[steps + 1];

            for (int i = 0; i <= steps; i++)
            {
                if (i == steps)
                {
                    t = 1.0f;
                }
                else
                {
                    t = i * tStepWith;
                }

                float px = (1 - t) * (1 - t) * (1 - t) * p0.X + 3 * t * (1 - t) * (1 - t) * p1.X + 3 * t * t * (1 - t) * p2.X + t * t * t * p3.X;
                float py = (1 - t) * (1 - t) * (1 - t) * p0.Y + 3 * t * (1 - t) * (1 - t) * p1.Y + 3 * t * t * (1 - t) * p2.Y + t * t * t * p3.Y;
                ret[i] = new Vector2(px, py);
            }
            return ret;
        }

    }
}