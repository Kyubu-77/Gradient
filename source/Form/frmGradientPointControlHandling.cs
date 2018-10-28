using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LED_Planer
{
    public partial class FrmGradient : Form
    {

        // New
        private void btnAddNewPoint_Click(object sender, EventArgs e)
        {
            Data.Gradient gradient = getCurrentGradient();

            float newPointsPosition = 0.5f;

            Data.Key rightestSelPoint = Utils.GetRightestKey(selection.Keys);
            if (rightestSelPoint != null)
            {

                // check if there is an unselected point to the right on the same color curve as the rightest point
                Data.Key rightNeighbour = gradient.FindFirstKeyRightOf(rightestSelPoint);

                if (rightNeighbour != null)
                {
                    newPointsPosition = (rightestSelPoint.Position.X + rightNeighbour.Position.X) * 0.5f;
                }
            }


            //create point
            Data.Key[] newKeys = gradient.AddKeysAtPositionX(newPointsPosition, Color.FromArgb(255, 50, 150, 250));

            // select new point
            selection.Clear();
            selection.AddKeys(newKeys);

            ShowGradientPoint(selection, false, true);
            graphViewHandler.RefreshPicture();
        }


        // Delete
        private void btnDeleteGradientPoint_Click(object sender, EventArgs e)
        {
            Data.Gradient gradient = getCurrentGradient();

            if (selection.Keys.Length == 0) return;

            foreach (Data.Key key in selection.Keys)
            {
                gradient.DeleteKey(key);
            }


            selection.Clear();
            ShowGradientPoint(selection, false, true);
            graphViewHandler.RefreshPicture();
        }

        // Allow input
        private void AllowPointInputs()
        {
            btnAddNewPoint.Enabled = true;
            btnDeletePoint.Enabled = true;

            grpPointInput.Enabled = true;
        }

        // Disable input
        private void NoPointInputs()
        {
            btnAddNewPoint.Enabled = true;
            btnDeletePoint.Enabled = false;

            grpPointInput.Enabled = false;
        }

        // Show gradient (enable/disable controls)
        public void ShowGradientPoint(SelectInformation selectInformation, bool updateListBoxSelection, bool refillListBox = false)
        {
            if (refillListBox)
            {
                updatingPoint = true;
                PointGridHandler.RefillGridPoints(grdPoints, getCurrentGradient());
                updatingPoint = false;
            }

            if (refillListBox || updateListBoxSelection)
            {
                updatingPoint = true;
                grdPoints.ClearSelection();
                PointGridHandler.SelectGridCellsFromSelection(grdPoints, selectInformation);
                grdPoints.Refresh();
                updatingPoint = false;
            }

            if (selectInformation.Keys.Length == 0)
            {
                UpdatePictureGraphics();
                NoPointInputs();
                return;
            }

            AllowPointInputs();


            FillGradientPointControls(selectInformation);

            UpdatePictureGraphics();
        }

        private void FillGradientPointControls(SelectInformation selectInformation)
        {
            updatingPoint = true;

            if (selectInformation.HaveSamePosX())
            {
                float pos = selectInformation.Keys[0].Position.X;
                txtPosition.Text = pos.ToString("0.000");

                if ((pos >= 0) && (pos <= 1.0))
                {
                    tbrPosition.Value = (int)(pos * 1000);
                }
            }
            else
            {
                txtPosition.Text = "multi";
                tbrPosition.Value = 0;
            }

            if (selectInformation.redKeysHaveSameRedValue())
            {
                if (selectInformation.RedKeys.Length > 0)
                {
                    txtRed.Enabled = true;
                    picRed.Enabled = true;

                    float r = selectInformation.RedKeys[0].Position.Y;
                    txtRed.Text = ((byte)(r * 255)).ToString();
                }
                else
                {
                    txtRed.Enabled = false;
                    picRed.Enabled = false;
                }
            }

            if (selectInformation.greenKeysHaveSameRedValue())
            {
                if (selectInformation.GreenKeys.Length > 0)
                {
                    txtGreen.Enabled = true;
                    picGreen.Enabled = true;

                    float r = selectInformation.GreenKeys[0].Position.Y;
                    txtGreen.Text = ((byte)(r * 255)).ToString();

                }
                else
                {
                    txtGreen.Enabled = false;
                    picGreen.Enabled = false;
                }
            }
            if (selectInformation.blueKeysHaveSameRedValue())
            {
                if (selectInformation.BlueKeys.Length > 0)
                {
                    txtBlue.Enabled = true;
                    picBlue.Enabled = true;

                    float r = selectInformation.BlueKeys[0].Position.Y;
                    txtBlue.Text = ((byte)(r * 255)).ToString();
                }
                else
                {
                    txtBlue.Enabled = false;
                    picBlue.Enabled = false;
                }
            }



            if (selectInformation.Keys.Length == 0)
            {
                cboSegment.Enabled = false;
            }
            else
            {
                if (selectInformation.HaveSameSegmentType())
                {
                    if (selectInformation.Keys[0].getSegmentType() == Data.SegmentKind.None)
                    {
                        cboSegment.Enabled = false;
                    }
                    else
                    {
                        cboSegment.Enabled = true;
                        foreach (Data.Key key in selectInformation.Keys)
                        {
                            Data.SegmentKind tpye = key.getSegmentType();
                            if (tpye != Data.SegmentKind.None)
                            {
                                // look for a key with a valid segment
                                if (tpye == Data.SegmentKind.UseLeft)
                                {
                                    cboSegment.SelectedItem = Constants.Left;
                                }
                                if (tpye == Data.SegmentKind.UseRight)
                                {
                                    cboSegment.SelectedItem = Constants.Right;
                                }
                                if (tpye == Data.SegmentKind.Line)
                                {
                                    cboSegment.SelectedItem = Constants.Line;
                                }
                                if (tpye == Data.SegmentKind.Bezier)
                                {
                                    cboSegment.SelectedItem = Constants.Bezier;
                                }


                                break;
                            }
                        }
                    }
                }

                else
                {
                    cboSegment.Enabled = false;
                }

            }


            updatingPoint = false;
        }


        // Control events

        private void grdPoints_SelectionChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;
            if (selectingCell) return;

            PointGridHandler.SelectInformationFromCells(grdPoints, selection);

            ShowGradientPoint(selection, false);
            graphViewHandler.RefreshPicture();

        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;

            TextBox textBox = (TextBox)sender;
            float position = Utils.LimitTextZeroToOne(textBox.Text);
            foreach (Data.Key key in selection.Keys) // Anchors will be updated in recalc
            {
                key.Position.X = position;
            }

            getCurrentGradient().SortPoints();

            updatingPoint = true;

            tbrPosition.Value = (int)(position * 1000);
            PointGridHandler.RefillGridPoints(grdPoints, getCurrentGradient());
            grdPoints.ClearSelection();
            PointGridHandler.SelectGridCellsFromSelection(grdPoints, selection);
            graphViewHandler.RefreshPicture();

            updatingPoint = false;
        }

        private void tbrPosition_Scroll(object sender, EventArgs e)
        {
            if (updatingPoint) return;

            TrackBar trackBar = (TrackBar)sender;
            float position = trackBar.Value / 1000.0f;

            position = Utils.LimitFloatZeroToOne(position);
            foreach (Data.Key key in selection.Keys) // Anchors will be updated in recalc
            {
                key.Position.X = position;
            }

            getCurrentGradient().SortPoints();

            updatingPoint = true;

            txtPosition.Text = position.ToString("0.000");
            PointGridHandler.RefillGridPoints(grdPoints, getCurrentGradient());
            grdPoints.ClearSelection();
            PointGridHandler.SelectGridCellsFromSelection(grdPoints, this.selection);
            grdPoints.Refresh();
            graphViewHandler.RefreshPicture();

            updatingPoint = false;
        }


        private void picRed_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            updatingPoint = true;

            PictureBox pictureBox = (PictureBox)sender;
            float position = Utils.LimitFloatZeroToOne(1.0f / pictureBox.Width * e.X);
            foreach (Data.Key key in selection.RedKeys)
            {
                key.Position.Y = position;
                key.IsDirty = true;
            }
            getCurrentGradient().RedCurve.IsDirty = true;

            txtRed.Text = ((byte)(position * 255)).ToString();

            picRed.Refresh();
            FillGradientPointColorPic();

            graphViewHandler.RefreshPicture();
            updatingPoint = false;
        }


        private void picGreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            updatingPoint = true;

            PictureBox pictureBox = (PictureBox)sender;
            float position = Utils.LimitFloatZeroToOne(1.0f / pictureBox.Width * e.X);
            foreach (Data.Key key in selection.GreenKeys)
            {
                key.Position.Y = position;
                key.IsDirty = true;
            }
            getCurrentGradient().GreenCurve.IsDirty = true;

            txtGreen.Text = ((byte)(position * 255)).ToString();

            picGreen.Refresh();
            FillGradientPointColorPic();

            graphViewHandler.RefreshPicture();
            updatingPoint = false;
        }

        private void picBlue_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            updatingPoint = true;

            PictureBox pictureBox = (PictureBox)sender;
            float position = Utils.LimitFloatZeroToOne(1.0f / pictureBox.Width * e.X);
            foreach (Data.Key key in selection.BlueKeys)
            {
                key.Position.Y = position;
                key.IsDirty = true;
            }
            getCurrentGradient().BlueCurve.IsDirty = true;

            txtBlue.Text = ((byte)(position * 255)).ToString();

            picBlue.Refresh();
            FillGradientPointColorPic();

            graphViewHandler.RefreshPicture();
            updatingPoint = false;
        }

        private void txtRed_TextChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;

            TextBox textBox = (TextBox)sender;
            byte position = Utils.LimitTextZeroTo255(textBox.Text);
            textBox.Text = position.ToString();

            foreach (Data.Key key in selection.RedKeys)
            {
                key.Position.Y = (float)(position / 255.0);
                key.IsDirty = true;
            }
            getCurrentGradient().RedCurve.IsDirty = true;


            picRed.Refresh();
            FillGradientPointColorPic();
            graphViewHandler.RefreshPicture();
        }

        private void txtGreen_TextChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;

            TextBox textBox = (TextBox)sender;
            byte position = Utils.LimitTextZeroTo255(textBox.Text);
            textBox.Text = position.ToString();

            foreach (Data.Key key in selection.GreenKeys)
            {
                key.Position.Y = (float)(position / 255.0);
                key.IsDirty = true;
            }
            getCurrentGradient().GreenCurve.IsDirty = true;

            picGreen.Refresh();
            FillGradientPointColorPic();

            graphViewHandler.RefreshPicture();
        }

        private void txtBlue_TextChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;

            TextBox textBox = (TextBox)sender;
            byte position = Utils.LimitTextZeroTo255(textBox.Text);
            textBox.Text = position.ToString();

            foreach (Data.Key key in selection.BlueKeys)
            {
                key.Position.Y = (float)(position / 255.0);
                key.IsDirty = true;
            }
            getCurrentGradient().BlueCurve.IsDirty = true;

            picBlue.Refresh();
            FillGradientPointColorPic();

            graphViewHandler.RefreshPicture();
        }

        private void cboSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingPoint) return;
            ComboBox comboBox = (ComboBox)sender;
            LBE.ComboSegmentType st = (LBE.ComboSegmentType)comboBox.SelectedItem;


            if (st.Value == Data.SegmentKind.None)
            {
                cboSegment.SelectedIndex = -1;
            }
        }

        private void cboSegment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (updatingPoint) return;
            ComboBox comboBox = (ComboBox)sender;
            LBE.ComboSegmentType st = (LBE.ComboSegmentType)comboBox.SelectedItem;

            foreach (Data.Key key in selection.Keys) // Anchors will be updated in recalc
            {
                if (key.getSegmentType() != Data.SegmentKind.None)
                {
                    key.setSegmentType(st.Value);
                    key.IsDirty = true;
                    getCurrentGradient().GetCurveByTag(key.Tag).IsDirty = true;
                }

            }

            graphViewHandler.RefreshPicture();
        }
    }
}
