using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace LED_Planer
{

    public partial class FrmGradient : Form
    {
        // Events are trigged by programm and should not be processed
        bool updatingPoint = false;
        bool updatingGradient = false;
        bool selectingCell = false;

        Graph.GraphViewHandler graphViewHandler;
        Graph.ShowGradientAsColorbeamInView colorBand;
        List<Data.Gradient> gradients = new List<Data.Gradient>();
        SelectInformation selection; // shortcut to graphViewHandler.getSelection();

        public FrmGradient()
        {
            InitializeComponent();

            graphViewHandler = new Graph.GraphViewHandler(this, picGraph);
            colorBand = new Graph.ShowGradientAsColorbeamInView();
            graphViewHandler.Addplugin(colorBand);
            selection = graphViewHandler.Selection;
        }

        private void FrmGradient_Load(object sender, EventArgs e)
        {
            updatingPoint = true;
            cboSegment.Items.Add(Constants.None);
            cboSegment.Items.Add(Constants.Left);
            cboSegment.Items.Add(Constants.Right);
            cboSegment.Items.Add(Constants.Line);
            cboSegment.Items.Add(Constants.Bezier);

            //grdPoints.Columns.Add("Point", "Point");
            grdPoints.Columns.Add("R", "R");
            grdPoints.Columns.Add("G", "G");
            grdPoints.Columns.Add("B", "B");

            //grdPoints.he
            grdPoints.RowHeadersWidth = 100;
            foreach (DataGridViewColumn column in grdPoints.Columns)
            {
                column.Width = 40;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            updatingPoint = false;

            SetOptions();
            SetCurrentGradient(null);
            UpdatePictureGraphics();
        }

        private void picGraph_MouseDown(object sender, MouseEventArgs e)
        {
            graphViewHandler.MouseDown(e.Button, e);
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            Vector2 pointScr = new Vector2(e.X, e.Y);
            Vector2 pointScrNorm = graphViewHandler.Camera.FlipScreenY(pointScr);
            graphViewHandler.MouseMove(pointScr, pointScrNorm);
        }

        private void picGraph_MouseUp(object sender, MouseEventArgs e)
        {
            Vector2 pointScr = new Vector2(e.X, e.Y);
            Vector2 pointScrNorm = graphViewHandler.Camera.FlipScreenY(pointScr);
            graphViewHandler.MouseUp(pointScr, pointScrNorm);
        }

        private void picGraph_MouseWheel(object sender, MouseEventArgs e)
        {
            Vector2 pointScr = new Vector2(e.X, e.Y);
            Vector2 pointScrNorm = graphViewHandler.Camera.FlipScreenY(pointScr);
            graphViewHandler.MouseWheel(pointScr, pointScrNorm, e.Delta);
        }



        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            //int w = ((PictureBox)sender).Width;
            //int h = ((PictureBox)sender).Height;
            //e.Graphics.DrawLine(Pens.Red, 0, 0, w, h);
            graphViewHandler.DrawGraph(e.Graphics, cbxShowAnchors.Checked);
            graphViewHandler.DrawSelRect(e.Graphics);

        }

        private void picRed_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            FillSliderPic(e.Graphics, pb.Width, pb.Height, Color.Red, selection.RedKeys);
        }

        private void picGreen_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            FillSliderPic(e.Graphics, pb.Width, pb.Height, Color.Green, selection.GreenKeys);
        }

        private void picBlue_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            FillSliderPic(e.Graphics, pb.Width, pb.Height, Color.Blue, selection.BlueKeys);
        }

        private void SetOptions()
        {
            Options options = new Options();

            // settings
            options.SetShowAnchors(cbxShowAnchors.Checked);
            options.SetAllowSelectingAnchors(cbxAllowSelectingAnchors.Checked);

            // grid
            options.SetGrid_Show_H(cbxH_ShowGrid.Checked);
            options.SetGrid_Show_V(cbxV_ShowGrid.Checked);
            options.SetGrid_Space_H(txtH_GridSpace.Text);
            options.SetGrid_Space_V(txtV_GridSpace.Text);

            options.SetGrid_Majorlines_Show_H(cbxH_HighlightMainGrid.Checked);
            options.SetGrid_Majorlines_Show_V(cbxV_HighlightMainGrid.Checked);
            options.SetGrid_MayjorLine_EveryXth_H(txtH_MainLineEveryXth.Text);
            options.SetGrid_MayjorLine_EveryXth_V(txtV_MainLineEveryXth.Text);

            options.SetMainLinesOnly(cbxOnlyMain.Checked);

            // snap
            options.SetSnap_Key_H(cbxH_Snap.Checked);
            options.SetSnap_Key_V(cbxV_Snap.Checked);

            options.SetSnap_Key_Space_H(txtH_SnapKeySpace.Text);
            options.SetSnap_Key_Space_V(txtV_SnapKeySpace.Text);
            options.SetSnap_Use_Relative(cbxUseRelativeSnap.Checked);

            options.SetSnap_Anchor_H(cbxH_SnapAnchor.Checked);
            options.SetSnap_Anchor_V(cbxV_SnapAnchor.Checked);

            options.SetSnap_Anchor_Space_H(txtH_SnapAnchorSpace.Text);
            options.SetSnap_Anchor_Space_V(txtV_SnapAnchorSpace.Text);

            graphViewHandler.SetOptions(options);
        }

        private void cbxShowAnchors_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void txtH_MainLineEveryXth_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void txtV_MainLineEveryXth_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void txtV_GridSpace_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void txtH_GridSpace_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxV_HighlightMainGrid_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxH_HighlightMainGrid_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxV_GridShow_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxH_GridShow_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxOnlyMain_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
            picGraph.Refresh();
        }

        private void cbxH_SnapAnchor_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void cbxV_SnapAnchor_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void txtV_SnapAnchor_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void txtH_SnapAnchor_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void txtH_Snap_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void txtV_Snap_TextChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void cbxSnapRelative_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void cbxV_Snap_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void cbxH_Snap_CheckedChanged(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void btnCameraReset_Click(object sender, EventArgs e)
        {
            graphViewHandler.CenterCamera();
            graphViewHandler.RefreshPicture();
        }

        private void picGraph_Resize(object sender, EventArgs e)
        {
            graphViewHandler.RefreshCamera(picGraph);
            graphViewHandler.RefreshPicture();
        }

        private void picRed_Resize(object sender, EventArgs e)
        {
            ((PictureBox)sender).Refresh();
        }

        private void picGreen_Resize(object sender, EventArgs e)
        {
            ((PictureBox)sender).Refresh();
        }

        private void picBlue_Resize(object sender, EventArgs e)
        {
            ((PictureBox)sender).Refresh();
        }

        

        private void grdPoints_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine("RowIndex");
            Console.WriteLine(e.RowIndex);
            Console.WriteLine("ColumnIndex");
            Console.WriteLine(e.ColumnIndex);

            if (Control.ModifierKeys != Keys.Control)
            {
                grdPoints.ClearSelection();
            }

            bool allAlreadySelected = true;
            for (int i = 0; i < grdPoints.Rows.Count; i++)
            {
                if (!grdPoints.Rows[i].Cells[e.ColumnIndex].Selected )
                {
                    allAlreadySelected = false;
                }
            }

            bool targetSelectd = allAlreadySelected == true ? false : true;

            for (int i = 0; i < grdPoints.Rows.Count; i++)
            {
                grdPoints.Rows[i].Cells[e.ColumnIndex].Selected = targetSelectd;
            }
        }
    }
}




