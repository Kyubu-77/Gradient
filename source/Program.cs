using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Planer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major>= 6) SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmGradient f = new FrmGradient();
            f.StartPosition = FormStartPosition.Manual;

            Screen leftScreen = null;
            foreach (Screen screen in Screen.AllScreens)
            {
                if (leftScreen == null)
                {
                    leftScreen = screen;
                }
                else
                {
                    if (screen.Bounds.Left < leftScreen.Bounds.Left)
                    {
                        leftScreen = screen;
                    }
                }
            }

            f.Location = leftScreen.Bounds.Location;

            Application.Run(f);
         
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
