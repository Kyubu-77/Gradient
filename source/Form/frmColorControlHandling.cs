using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace LED_Planer
{
    public partial class FrmGradient : Form
    {
        private void FillGradientPointColorPic()
        {
            float red = 0;
            if (selection.RedKeys.Length > 0)
            {
                foreach (Data.Key key in selection.RedKeys)
                {
                    red += key.Position.Y;
                }
                red /= selection.RedKeys.Length;
            }

            float green = 0;
            if (selection.GreenKeys.Length > 0)
            {
                foreach (Data.Key key in selection.GreenKeys)
                {
                    green += key.Position.Y;
                }
                green /= selection.GreenKeys.Length;
            }

            float blue = 0;
            if (selection.BlueKeys.Length > 0)
            {
                foreach (Data.Key key in selection.BlueKeys)
                {
                    blue += key.Position.Y;
                }
                blue /= selection.BlueKeys.Length;
            }

            picGradientPointColor.BackColor = Color.FromArgb(255, (int)(255 * red), (int)(255 * green), (int)(255 * blue));
        }


        private static void FillSliderPic(Graphics graphics, int widht, int height,Color color, Data.Key[] values)
        {
            graphics.Clear(Color.LightGray);
            Utils.DrawHorizontalGradient(graphics, widht, height, Color.FromArgb(255, 255,255,255), color);
            Utils.DrawMarker(graphics, values);
        }


        private void UpdatePictureGraphics()
        {
            FillGradientPointColorPic();
            picRed.Refresh();
            picGreen.Refresh();
            picBlue.Refresh(); 
        }
 /*
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmGradient
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FrmGradient";
            this.Load += new System.EventHandler(this.FrmGradient_Load);
            this.ResumeLayout(false);

        }*/

    }
}
