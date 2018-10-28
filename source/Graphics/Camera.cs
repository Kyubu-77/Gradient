using System.Numerics;
using System.Drawing;

namespace LED_Planer.Graph
{

    public class Camera
    {
        public Vector2 Zoom { get; set; }
        public Vector2 PositionInWorldCoordinates { get; set; }

        public Vector2 ImageSize { get; set; }
        public Vector2 GraphAreaSize { get; set; } // Define 
        public Vector2 GraphOffsetInPx { get; set; } // Offset of GraphAreaSize inside Image

        private Matrix3x2 screenToWorld;
        private Matrix3x2 screenToWorldAndFlipY; // also flip Y

        private Matrix3x2 worldToScreen;
        private Matrix3x2 worldToScreenAndFlipY; // also flip Y

        private Matrix3x2 normScreen;           // just flip Y
        private Matrix3x2 unNormScreen;         // just flip Y


        public void CalcultateMatrixes()
        {
            worldToScreenAndFlipY = Matrix3x2.CreateTranslation(-PositionInWorldCoordinates.X, -PositionInWorldCoordinates.Y) *
                    Matrix3x2.CreateScale(new Vector2(Zoom.X, Zoom.Y)) * //  Y up is plus
                    Matrix3x2.CreateScale(GraphAreaSize) *
                    Matrix3x2.CreateTranslation(GraphAreaSize.X / 2 + GraphOffsetInPx.X, GraphAreaSize.Y / 2 + GraphOffsetInPx.Y) *

                    // move 0,0 corner in pix from upper left corner to lower, left corner
                    Matrix3x2.CreateScale(new Vector2(1, -1)) *
                    Matrix3x2.CreateTranslation(new Vector2(0, ImageSize.Y));

            worldToScreen = Matrix3x2.CreateTranslation(-PositionInWorldCoordinates.X, -PositionInWorldCoordinates.Y) *
                    Matrix3x2.CreateScale(new Vector2(Zoom.X, Zoom.Y)) * //  Y up is plus
                    Matrix3x2.CreateScale(GraphAreaSize) *
                    Matrix3x2.CreateTranslation(GraphAreaSize.X / 2 + GraphOffsetInPx.X, GraphAreaSize.Y / 2 + GraphOffsetInPx.Y);

            normScreen = Matrix3x2.CreateScale(new Vector2(1, -1)) *
                    Matrix3x2.CreateTranslation(new Vector2(0, ImageSize.Y));

            Matrix3x2.Invert(worldToScreen, out screenToWorld);
            Matrix3x2.Invert(worldToScreenAndFlipY, out screenToWorldAndFlipY);
            Matrix3x2.Invert(normScreen, out unNormScreen);
        }


        public PointF WorldToScreenAndFlipY(Vector2 worldPosition)
        {
            Vector2 v = Vector2.Transform(worldPosition, worldToScreenAndFlipY);
            return new PointF(v.X, v.Y);
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, worldToScreen);
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, screenToWorld);
        }

        public Vector2 ScreenToWorldAndFlipY(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, screenToWorldAndFlipY);
        }

        public Vector2 FlipScreenY(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, normScreen);
        }

        public PointF FlipScreenPointY(Vector2 screenPosition)
        {
            Vector2 v = Vector2.Transform(screenPosition, normScreen);
            return new PointF(v.X, v.Y);
        }

    }
}
