using System.Drawing;
using System.Numerics;

namespace LED_Planer
{
    public class Constants
    {
        public const int RED = 0;
        public const int GREEN = RED + 1;
        public const int BLUE = GREEN + 1;

        private Constants() { }
        public const float vRulerWidhtPX = 60;
        public const float hRulerHightPx = 30; 
        public const float hColorbandHightPx = 30;
        public const float stepWidth = 0.05f;
        public const float hRuler_SpaceBetweenRulerAndTextInX = 3; // in px
        public const float hRuler_SpaceBetweenRulerAndTextInY = 2; // in px
        public const float vRuler_SpaceBetweenRulerAndTextInX = 3; // in px
        public const float vRuler_SpaceBetweenRulerAndTextInY = 2; // in px
        public const float hSpaceBetweenRulerAndText = 3; // in px

        public static LBE.ComboSegmentType None = new LBE.ComboSegmentType("None", Data.SegmentKind.None);
        public static LBE.ComboSegmentType Left = new LBE.ComboSegmentType("Left", Data.SegmentKind.UseLeft);
        public static LBE.ComboSegmentType Right = new LBE.ComboSegmentType("Right", Data.SegmentKind.UseRight);
        public static LBE.ComboSegmentType Line = new LBE.ComboSegmentType("Line", Data.SegmentKind.Line);
        public static LBE.ComboSegmentType Bezier = new LBE.ComboSegmentType("Bezier", Data.SegmentKind.Bezier);

        public static float DragDist = 2.0f;

        public static Vector2 lu = new Vector2(0f, 0f);
        public static Vector2 ro = new Vector2(1f, 1f);
        public static int ColorBandSteps = 500;
        public static float BezierSegmentSteps = 250;

        public static Brush BrushOne = new SolidBrush(Color.White);
        public static Brush BrushMany = new SolidBrush(Color.LightGray);

        
    }
}

