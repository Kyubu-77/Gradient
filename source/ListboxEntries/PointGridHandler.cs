using System.Collections.Generic;
using System.Windows.Forms;

namespace LED_Planer
{
    public class PointGridHandler
    {

        public static void SelectfirstGridRowsCells(DataGridView grdPoints)
        {
            grdPoints.Rows[0].Selected = true;
            foreach (DataGridViewCell cell in grdPoints.Rows[0].Cells)
            {
                cell.Selected = true;
            }
        }

        public static void SelectInformationFromCells(DataGridView grdPoints, SelectInformation selectInformation)
        {
            selectInformation.Clear();
            foreach (DataGridViewRow row in grdPoints.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Selected)
                    {
                        if (cell.Tag != null)
                        {
                            // only R, G, B cells have tag pointing to key
                            foreach (Data.Key key in ((Data.Key[])cell.Tag))
                            {
                                selectInformation.AddKey(key);
                            }
                        }
                    }

                }
            }
        }
        

        public static void SelectGridCellsFromSelection(DataGridView grdPoints, SelectInformation selectInformation)
        {
            foreach (DataGridViewRow row in grdPoints.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Tag != null)
                    {
                        foreach (Data.Key key in ((Data.Key[])cell.Tag))
                        {
                            if (selectInformation.KeysAndAnchors.Contains(key))
                            {
                                cell.Selected = true;
                            }
                        }
                    }
                }
            }
        }


        private static string GetCellText(Data.Key[] r)
        {
            string ret = "";

            if (r.Length == 0)
            {
                ret = "";

            }
            else if (r.Length == 1)
            {
                ret = "*";
            }
            else
            {
                ret = "" + r.Length;
            }
            return ret;
        }

        public static void RefillGridPoints(DataGridView grdPoints, Data.Gradient gradient)
        {
            // fill grid
            grdPoints.Rows.Clear();

            foreach (KeyValuePair<float, LBE.ComboKeyInfo> pos in gradient.getUniqueKeyPositions())
            {
                Data.Key[] r = pos.Value.keys[Constants.RED];
                Data.Key[] g = pos.Value.keys[Constants.GREEN];
                Data.Key[] b = pos.Value.keys[Constants.BLUE];
                string[] xxx = new string[3];

                xxx[0] = GetCellText(r);
                xxx[1] = GetCellText(g);
                xxx[2] = GetCellText(b);


                int insertPos = grdPoints.Rows.Add(xxx);
                grdPoints.Rows[insertPos].HeaderCell.Value = pos.Key.ToString();
                grdPoints.Rows[insertPos].Cells[0].Tag = r;
                grdPoints.Rows[insertPos].Cells[1].Tag = g;
                grdPoints.Rows[insertPos].Cells[2].Tag = b;
            }
        }


    }
}
