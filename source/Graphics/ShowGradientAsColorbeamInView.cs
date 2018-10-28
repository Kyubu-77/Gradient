using System.Drawing;
using System.Numerics;

namespace LED_Planer.Graph
{
    /// <summary>
    /// Shows a gradient as colorband inside a graphic object
    /// </summary>
    public class ShowGradientAsColorbeamInView : GraphViewPlugin
    {
        private Data.Gradient gradient;
        
        public void SetGradient(Data.Gradient gradient)
        {
            this.gradient = gradient;
        }
        
        public override void Draw(Graphics graphics, Camera camera)
        {
            Vector2 maxLeftBottom = new Vector2(0, /*Constants.hRulerHightPx*/0);
            Vector2 maxRightTop = new Vector2(camera.ImageSize.X, /*Constants.hRulerHightPx +*/ Constants.hColorbandHightPx);
            int steps = Constants.ColorBandSteps;
            float stepWidthScreen = ((float)camera.ImageSize.X) / steps;

            float middleOffs = maxLeftBottom.X + stepWidthScreen * 0.5f;
            float line = camera.ImageSize.Y - maxLeftBottom.Y - Constants.hColorbandHightPx;

            for (int i = 0; i < steps; i++)
            {
                Color color = Color.Red;
                if (gradient!= null) { 
                 color = gradient.GetColorAt( camera.ScreenToWorld(new Vector2(middleOffs + stepWidthScreen * i, 0)).X);
                }
                Brush b = new SolidBrush(color);

                // custom flip
                graphics.FillRectangle(b, new RectangleF(maxLeftBottom.X +  stepWidthScreen* i, line, stepWidthScreen, Constants.hColorbandHightPx));
            }
        }
    }
}