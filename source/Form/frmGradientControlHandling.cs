using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LED_Planer
{

    public partial class FrmGradient :  Form
    {
        // Get
        Data.Gradient getCurrentGradient()
        {
            return (Data.Gradient)cboGradients.SelectedItem;
        }

        // Set
        void SetCurrentGradient(Data.Gradient palette)
        {
            ShowGradient(palette);
        }

        // New
        private void btnNewGradient_Click(object sender, EventArgs e)
        {

            Data.Gradient newGradient = Data.Gradient.CreateDefaultGradient();
            gradients.Add(newGradient);
            cboGradients.Items.Add(newGradient); // TODO check if this triggers and event, it should not trigger an event

            ShowGradient(newGradient);
        }

        //Load
        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<Data.Gradient> newGradients = XmlProcessor.LoadGradients();

            gradients = newGradients;

            cboGradients.Items.Clear();

            foreach (Data.Gradient grad in gradients)
            {
                cboGradients.Items.Add(grad); // TODO check if this triggers and event, it should not trigger an event
            }

            if (newGradients.Count > 0)
            {
                ShowGradient(newGradients[0]);
            }
            else
            {
                ShowGradient(null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String xml = XmlProcessor.SaveGradients(gradients);
            MessageBox.Show(xml);
        }

        // Delete
        private void btnDeleteGradient_Click(object sender, EventArgs e)
        {
            Data.Gradient currentGradient = getCurrentGradient();

            if (currentGradient == null) return;

            // remove from list
            gradients.Remove(currentGradient);

            // find combo entry
            int index = cboGradients.Items.IndexOf(currentGradient);


            // remove combo entry 
            cboGradients.Items.Remove(currentGradient);

            // select next gradient
            if (index < cboGradients.Items.Count)
            {
                cboGradients.SelectedIndex = index;
            }
            else if (cboGradients.Items.Count > 0)
            {
                cboGradients.SelectedIndex = index - 1;
            }
            else
            {
                cboGradients.SelectedItem = null;// last cbo entry removed
            }


            // show next gradient
            ShowGradient((Data.Gradient)cboGradients.SelectedItem);
        }

        // Allow input
        private void AllowEditingGradient()
        {
            btnNewGradient.Enabled = true;
            btnDeleteGradient.Enabled = true;

            grpGradientInput.Enabled = true;
        }

        // Disable input
        private void ForbitEditingGradient()
        {
            // Buttons
            btnNewGradient.Enabled = true;
            btnDeleteGradient.Enabled = false;

            // Group
            grpGradientInput.Enabled = false;
        }

        // Show gradient (enable/disable controls)
        private void ShowGradient(Data.Gradient gradient)
        {
            if (gradient == null)
            {
                ForbitEditingGradient();
                return;
            }

            AllowEditingGradient();


            if (((Data.Gradient)cboGradients.SelectedItem) != gradient)
            {
                cboGradients.SelectedItem = gradient; // TODO shoult not trigger an event
            }


            FillGradientControls(gradient);

            colorBand.SetGradient(gradient); // colorBand is plugin of graphViewHandler
            graphViewHandler.SetGraph(gradient.graph);
            graphViewHandler.RefreshPicture();
        }

        
        // Show gradient (move values into controls)
        private void FillGradientControls(Data.Gradient gradient)
        {
            if (gradient == null) return;

            // textbox
            txtName.Text = gradient.name;

            // Fill PointGrid
            updatingPoint = true;
            PointGridHandler.RefillGridPoints(grdPoints, gradient);
            PointGridHandler.SelectfirstGridRowsCells(grdPoints);
            PointGridHandler.SelectInformationFromCells(grdPoints, selection);
            updatingPoint = false;
            ShowGradientPoint(selection, false);
        }

        // Events
        private void cboGradient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (updatingGradient) return;
            ShowGradient((Data.Gradient)cboGradients.SelectedItem);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Data.Gradient gradient = getCurrentGradient();

            gradient.name = textBox.Text;
            updatingGradient = true;
            RefreshGradientCbo(getCurrentGradient());
            updatingGradient = false;
        }



        // Functions
        private void RefreshGradientCbo(Data.Gradient point)
        {
            Object entry = cboGradients.SelectedItem;
            cboGradients.Items.Remove(point);
            cboGradients.Items.Add(point);
            cboGradients.SelectedItem = entry;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmExport x = new FrmExport();
            x.SetGradient(this.getCurrentGradient());
            x.ShowDialog();
        }
    }
}
