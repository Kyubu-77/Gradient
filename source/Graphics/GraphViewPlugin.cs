using System.Drawing;

namespace LED_Planer.Graph
{
    public abstract class GraphViewPlugin
    {
        public abstract void Draw(Graphics graphics, Camera camera);
    }
}