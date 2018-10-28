using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LED_Planer.Data;

namespace LED_Planer
{
    public partial class FrmExport : Form
    {
        private Gradient gradient;

        public FrmExport()
        {
            InitializeComponent();
        }

        internal void SetGradient(Gradient gradient)
        {
            this.gradient = gradient;
        }

        private void btn1001JsonRGBPoints_Click(object sender, EventArgs e)
        {
            txtOutout.Text = Export.Gen1001JsonRGBPoints(gradient);
        }
    }
}
