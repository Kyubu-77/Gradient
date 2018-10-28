using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace LED_Planer.Graph
{
    public class GraphViewHandler
    {
        // * - - - *
        // | 1 1 1 |
        // | 1 0 1 |
        // | 1 1 1 |
        // * - - - *
        private const int keyPointSize = 8; // | 1 0 1 |
        private const int keyPointSize_halbe = keyPointSize / 2;

        private const int anchorPointSize = 6; // | 1 0 1 |
        private const int anchorPointSize_halbe = anchorPointSize / 2;

        private const float modelViewLeftBorder = -0.1f; // 0.1 is space for rulers 
        private const float modelViewRightBorder = 1.1f;
        private const float modelViewBottomBorder = -0.2f;  // 0.2 is space for rulers  (the space for the ShowGradientAsColorbeamInView is outside)
        private const float modelViewTopBorder = 1.2f;

        private Vector2 GraphOffsetInPx = new Vector2(0 /* start at 0 but, lines starte at vRulerWidhtPX to have free space*/, Constants.hRulerHightPx + Constants.hColorbandHightPx);

        private Graph.Graph2D graph;
        private FrmGradient form;
        private PictureBox pictureBox;

        private Camera camera;
        public Camera Camera { get => camera; }

        private SelectInformation selection = new SelectInformation();
        public SelectInformation Selection { get => selection; }

        private List<GraphViewPlugin> plugins = new List<GraphViewPlugin>();

        // draw, select and snap options
        private Options options;
        private MouseStatus mouseStatus;

        // mouse handling move
        private Vector2 startPointScr;
        private Vector2 startPointScrNorm;
        private Vector2 startCamPos;
        private Dictionary<Bind.IMovable, Vector2> dragStartPositions = null;

        // mouse handling select
        private Rectangle selRectangle;
        private Bitmap unselectedImage;

        public GraphViewHandler(FrmGradient form, PictureBox pictureBox)
        {
            this.form = form;
            this.pictureBox = pictureBox;

            camera = new Camera();
            mouseStatus = MouseStatus.Up;

            selection.Clear();

            CenterCamera(); // reset camera
        }

        public void SetGraph(Graph2D graph)
        {
            this.graph = graph;

            selection.Clear();
            selection.AddKeys(graph.SelectFirstRGBPoint());

            CenterCamera(); // reset camera
        }

        public void Addplugin(GraphViewPlugin plugin)
        {
            plugins.Add(plugin);
        }


        /// <summary>
        /// Select all keys and anchors at position point and return them as List
        /// </summary>
        public List<Bind.ISelectable> GetSelectableObjectsAtScreenCoord(Vector2 point, bool checkAnchorsToo, bool OnlyFirst = true)
        {
            Vector2 sScr = new Vector2(point.X - keyPointSize_halbe, point.Y - keyPointSize_halbe);
            Vector2 eScr = new Vector2(point.X + keyPointSize_halbe, point.Y + keyPointSize_halbe);

            Vector2 s = camera.ScreenToWorld(sScr);
            Vector2 e = camera.ScreenToWorld(eScr);

            List<Bind.ISelectable> selectedKeys = new List<Bind.ISelectable>();
            if (graph == null) return selectedKeys;

            foreach (Data.Curve curve in graph.Curves)
            {
                foreach (Data.Key key in curve.GetKeys())
                {
                    Vector2 pos = key.Position;
                    if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                    {
                        selectedKeys.Add(key);
                    }

                    if (checkAnchorsToo)
                    {
                        if (key.getSegmentType() == Data.SegmentKind.Bezier)
                        {
                            pos = key.RightAnchor.Position;
                            if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                            {
                                selectedKeys.Add(key.RightAnchor);
                            }

                            pos = key.Right.LeftAnchor.Position;
                            if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                            {
                                selectedKeys.Add(key.Right.LeftAnchor);
                            }
                        }
                    }
                }
            }

            if (OnlyFirst && selectedKeys.Count > 0)
            {
                List<Bind.ISelectable> ret = new List<Bind.ISelectable>();
                ret.Add(selectedKeys[0]);
                return ret;
            }
            return selectedKeys;
        }


        /// <summary>
        /// Select all keys and anchors inside rectangle and return them as List
        /// </summary>
        /// <param name="selRectangle"></param>
        /// <param name="swapSelection"></param>
        public void SelectInScreenCoord(Rectangle selRectangle, bool swapSelection)
        {
            if (graph == null) return;
            Vector2 sScr = new Vector2(selRectangle.X, selRectangle.Y);
            Vector2 eScr = new Vector2(selRectangle.X + selRectangle.Width, selRectangle.Y + selRectangle.Height);

            Vector2 sTmp = camera.ScreenToWorldAndFlipY(sScr);
            Vector2 eTmp = camera.ScreenToWorldAndFlipY(eScr);

            // normalize point defining the rectangle
            Vector2 s = new Vector2(Math.Min(sTmp.X, eTmp.X), Math.Min(sTmp.Y, eTmp.Y));
            Vector2 e = new Vector2(s.X + Math.Abs(sTmp.X - eTmp.X), s.Y + Math.Abs(sTmp.Y - eTmp.Y));

            if (!swapSelection)
            {
                selection.Clear();
            }


            foreach (Data.Curve curve in graph.Curves)
            {
                foreach (Data.Key key in curve.GetKeys())
                {
                    Vector2 pos = key.Position;
                    if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                    {
                        if (swapSelection && key.IsSelected)
                        {
                            selection.DeleteKey(key);
                        }
                        else
                        {
                            selection.AddKey(key);
                        }
                    }

                    if (key.getSegmentType() == Data.SegmentKind.Bezier)
                    {

                        pos = key.RightAnchor.Position;
                        if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                        {
                            if (swapSelection && key.RightAnchor.IsSelected)
                            {
                                selection.DeleteAnchor(key.RightAnchor);
                            }
                            else
                            {
                                if (options.AllowSelectingAnchors)
                                {
                                    selection.AddAnchor(key.RightAnchor);
                                }
                            }

                        }

                        pos = key.Right.LeftAnchor.Position;
                        if ((s.X <= pos.X && pos.X <= e.X) && (s.Y <= pos.Y && pos.Y <= e.Y))
                        {
                            if (swapSelection && key.Right.LeftAnchor.IsSelected)
                            {
                                selection.DeleteAnchor(key.Right.LeftAnchor);
                            }
                            else
                            {
                                if (options.AllowSelectingAnchors)
                                {
                                    selection.AddAnchor(key.Right.LeftAnchor);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Center Camera show range X -0.1 to 1.1 and Y -0.2 to 1.2
        /// </summary>
        internal void CenterCamera()
        {
            camera.PositionInWorldCoordinates = new Vector2((modelViewLeftBorder + modelViewRightBorder) / 2.0f, (modelViewBottomBorder + modelViewTopBorder) / 2.0f);
            camera.Zoom = new Vector2(1.0f / (Math.Abs(modelViewLeftBorder) + Math.Abs(modelViewRightBorder)), 1.0f / (Math.Abs(modelViewBottomBorder) + Math.Abs(modelViewTopBorder)));
            RefreshCamera(pictureBox);
        }


        /// <summary>
        /// Refresh camera matrixes after the camera has been moved/centered or the graph picture size has been changed
        /// </summary>
        /// <param name="picGraph"></param>
        internal void RefreshCamera(PictureBox picGraph)  // e.g. if picGraph is resized
        {
            camera.ImageSize = new Vector2(picGraph.Width, picGraph.Height);
            camera.GraphAreaSize = new Vector2(picGraph.Width - GraphOffsetInPx.X, picGraph.Height - GraphOffsetInPx.Y);
            camera.GraphOffsetInPx = GraphOffsetInPx;
            camera.CalcultateMatrixes();
        }

        /// <summary>
        /// Trigger OnPoint event
        /// </summary>
        public void RefreshPicture()
        {
            pictureBox.Refresh();  // triggers paint event,  which calls DrawGraph
        }

        public void DrawGraph(Graphics graphics, bool ShowAnchors)
        {
            graphics.Clear(Color.LightGray);

            ShowGridLines(graphics);
            ShowCurves(graphics, ShowAnchors);

            foreach (GraphViewPlugin plugin in plugins)
            {
                plugin.Draw(graphics, camera);
            }
        }

        /// <summary>
        /// Calc the grid lines position in world coordinates, then draw the grid lines
        /// </summary>
        /// <param name="graphics"></param>
        private void ShowGridLines(Graphics graphics)
        {
            // define the rectangle where to fill the grid, this is done to calc only the grid lines which are going to be shown
            Vector2 maxLeftBottom = camera.ScreenToWorld(new Vector2(Constants.vRulerWidhtPX, /*Constants.hRulerHightPx + */ Constants.hColorbandHightPx));
            Vector2 maxRightTop = camera.ScreenToWorld(new Vector2(camera.ImageSize.X, camera.ImageSize.Y));

            Font drawFont = new Font("Verdana", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen penBlackBold = new Pen(Color.Black, 2);
            Pen penBlack = new Pen(Color.Black);
            Pen penDarkGray = new Pen(Color.DarkGray);
            Pen penWhite = new Pen(Color.White);
            Pen penDarkBlue = new Pen(Color.DarkBlue);

            int startIndex;
            int i;

            // Horizontal Grid Lines
            if (options.H_ShowGrid)
            {
                float startY = maxLeftBottom.Y;
                float endY = maxRightTop.Y;

                PointF p0;
                PointF p1;


                startIndex = (int)(startY / options.V_GridSpace);
                i = startIndex; // i may start negative
                float y = i * options.V_GridSpace;

                while (y <= endY)
                {
                    p0 = camera.WorldToScreenAndFlipY(new Vector2(maxLeftBottom.X, y));
                    p1 = camera.WorldToScreenAndFlipY(new Vector2(maxRightTop.X, y));

                    p0.X = 0; // overwrite vRuler space

                    if (i == 0)
                    {
                        // draw the X-Axis at Y = 0
                        graphics.DrawLine(penBlackBold, p0.X, p0.Y, p1.X, p1.Y);
                    }
                    else if (i == (Math.Round(1.0f / options.V_GridSpace)))
                    {
                        // draw the X-Axis at Y = 1
                        graphics.DrawLine(penDarkBlue, p0.X, p0.Y, p1.X, p1.Y);
                    }
                    else if (options.H_ShowMajorGrid && i % options.H_MayorLineEveryXth == 0)
                    {
                        // draw machor grid line
                        graphics.DrawLine(penBlack, p0.X, p0.Y, p1.X, p1.Y);
                    }
                    else if (options.MayorLinesOnly == false)
                    {
                        // draw default grid line
                        graphics.DrawLine(penDarkGray, p0.X, p0.Y, p1.X, p1.Y);
                    }


                    // draw text (pos calc done in screen space)
                    if (i % 2 == 0)
                    {
                        string text = y.ToString();
                        SizeF textSize = graphics.MeasureString(text, drawFont);
                        float textRightBoundary = Constants.vRulerWidhtPX - Constants.hRuler_SpaceBetweenRulerAndTextInX;
                        float textLeftBoundary = textRightBoundary - textSize.Width;

                        PointF drawPoint = new PointF(textLeftBoundary, p0.Y - textSize.Height + Constants.hRuler_SpaceBetweenRulerAndTextInY);
                        graphics.DrawString(text, drawFont, drawBrush, drawPoint);
                    }
                    i++;
                    y = i * options.V_GridSpace;
                }

                p0 = camera.FlipScreenPointY(new Vector2(0, Constants.hRulerHightPx + Constants.hColorbandHightPx));
                p1 = camera.FlipScreenPointY(new Vector2(camera.ImageSize.X, Constants.hRulerHightPx + Constants.hColorbandHightPx));
                graphics.DrawLine(penWhite, p0.X, p0.Y, p1.X, p1.Y);

            }

            // Vertical Grid Lines
            if (options.V_ShowGrid)
            {
                float startX = maxLeftBottom.X;
                float endX = maxRightTop.X;

                PointF p0;
                PointF p1;


                startIndex = (int)(startX / options.H_GridSpace);

                i = startIndex; // i may start negative
                float x = i * options.H_GridSpace;
                while (x <= endX)
                {
                    p0 = camera.WorldToScreenAndFlipY(new Vector2(x, maxLeftBottom.Y));
                    p1 = camera.WorldToScreenAndFlipY(new Vector2(x, maxRightTop.Y));
                    if (i == 0)
                    {
                        graphics.DrawLine(penBlackBold, p0.X, p0.Y, p1.X, p1.Y);
                    }
                    else if (i == (Math.Round(1.0f / options.H_GridSpace)))
                    {
                        graphics.DrawLine(penDarkBlue, p0.X, p0.Y, p1.X, p1.Y);

                    }
                    else if (options.V_ShowMajorGrid && (i % options.V_MayorLineEveryXth) == 0)
                    {
                        graphics.DrawLine(penBlack, p0.X, p0.Y, p1.X, p1.Y);
                    }
                    else if (options.MayorLinesOnly == false)
                    {
                        graphics.DrawLine(penDarkGray, p0.X, p0.Y, p1.X, p1.Y);
                    }

                    // draw text (pos calc done in screen space)
                    if (i % 2 == 0)
                    {
                        string text = x.ToString();
                        float textLeftBoundary = p0.X + Constants.vRuler_SpaceBetweenRulerAndTextInX;

                        PointF drawPoint = camera.FlipScreenPointY(new Vector2(textLeftBoundary, Constants.hRulerHightPx + Constants.hColorbandHightPx));
                        graphics.DrawString(text, drawFont, drawBrush, drawPoint);
                    }

                    i++;
                    x = i * options.H_GridSpace;
                }

                p0 = new PointF(Constants.vRulerWidhtPX, Constants.hRulerHightPx - Constants.hColorbandHightPx);
                p1 = new PointF(Constants.vRulerWidhtPX, camera.ImageSize.Y);
                graphics.DrawLine(penWhite, p0.X, p0.Y, p1.X, p1.Y);
            }
        }

        void ShowCurves(Graphics graphics, bool ShowAnchors)
        {
            if (graph == null) return;

            foreach (Data.Curve curve in graph.Curves)
            {
                ShowCurve(graphics, curve, ShowAnchors);
            }
        }

        void ShowCurve(Graphics graphics, Data.Curve curve, bool ShowAnchors)
        {
            curve.RefreshInterpolation();
            Data.Key[] keys = curve.GetKeys();
            for (int i = 0; i < keys.Length - 1; i++)
            {
                Data.Key key = keys[i];
                Data.SegmentInfo segmentInfo = key.SegmentInfo;

                Vector2[] segmentPoints = segmentInfo.points;

                List<PointF> lScreen = new List<PointF>();
                foreach (Vector2 p in segmentPoints)
                {
                    PointF v = camera.WorldToScreenAndFlipY(new Vector2(p.X, p.Y));
                    lScreen.Add(v);
                }

                Pen penBlack = new Pen(curve.Color, 1.75f);
                graphics.DrawLines(penBlack, lScreen.ToArray());
            }

            SolidBrush normalBrushKey = new SolidBrush(Color.White);
            SolidBrush selectedBrushKey = new SolidBrush(Color.Yellow);
            SolidBrush normalBrushAnchor = new SolidBrush(Color.White);
            SolidBrush selectedBrushAnchor = new SolidBrush(Color.Yellow);
            Pen anchorLine = new Pen(Color.DarkBlue);
            Pen pen = new Pen(Color.Black, 1f);

            //Show key point anchors
            if (ShowAnchors)
            {
                foreach (Data.Key key in curve.GetKeys())
                {
                    PointF v = camera.WorldToScreenAndFlipY(key.Position);

                    if (key.Left != null && key.Left.getSegmentType() == Data.SegmentKind.Bezier)
                    {
                        if (key.LeftAnchor != null)
                        {
                            PointF vA = camera.WorldToScreenAndFlipY(key.LeftAnchor.Position);
                            PointF v1A = new PointF((vA.X - anchorPointSize_halbe), (vA.Y - anchorPointSize_halbe));

                            SolidBrush brush = key.LeftAnchor.IsSelected == true ? selectedBrushAnchor : normalBrushAnchor;
                            graphics.DrawLine(anchorLine, v.X, v.Y, vA.X, vA.Y);
                            graphics.FillRectangle(brush, v1A.X, v1A.Y, anchorPointSize, anchorPointSize);
                            graphics.DrawRectangle(pen, v1A.X, v1A.Y, anchorPointSize, anchorPointSize);
                        }

                    }

                    if (key.getSegmentType() == Data.SegmentKind.Bezier)
                    {
                        if (key.RightAnchor != null)
                        {
                            PointF vB = camera.WorldToScreenAndFlipY(key.RightAnchor.Position);
                            PointF v1B = new PointF((vB.X - anchorPointSize_halbe), (vB.Y - anchorPointSize_halbe));

                            SolidBrush brush = key.RightAnchor.IsSelected == true ? selectedBrushAnchor : normalBrushAnchor;
                            graphics.DrawLine(anchorLine, v.X, v.Y, vB.X, vB.Y);
                            graphics.FillRectangle(brush, v1B.X, v1B.Y, anchorPointSize, anchorPointSize);
                            graphics.DrawRectangle(pen, v1B.X, v1B.Y, anchorPointSize, anchorPointSize);
                        }
                    }
                }
            }


            //Show key points
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            foreach (Data.Key key in curve.GetKeys())
            {
                PointF v = camera.WorldToScreenAndFlipY(key.Position);
                PointF v1 = new PointF((v.X - keyPointSize_halbe), (v.Y - keyPointSize_halbe));

                SolidBrush brush = key.IsSelected == true ? selectedBrushKey : normalBrushKey;
                graphics.FillRectangle(brush, v1.X, v1.Y, keyPointSize, keyPointSize);
                graphics.DrawRectangle(pen, v1.X, v1.Y, keyPointSize, keyPointSize);
            }
        }

        public void SetOptions(Options options)
        {
            this.options = options;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "pointScr")]
        public void MouseWheel(Vector2 pointScr, Vector2 pointScrNorm, float delta)
        {
            Vector2 target = camera.ScreenToWorld(pointScrNorm);
            Vector2 campos = camera.PositionInWorldCoordinates;

            if (delta > 0) // zoom in 
            {
                Vector2 offset = (target - campos) * 0.10f; // when moving the camera, 10 percent to target
                camera.PositionInWorldCoordinates = campos + offset;

                Vector2 zoomChange = camera.Zoom * 0.1f;
                camera.Zoom = camera.Zoom + zoomChange;
            }
            else // zoom out 
            {
                // disable no camera movement
                //Vector2 offset = (target - campos) * 0.1f; // when moving the camera, 10 percent to target
                //camera.PositionInWorldCoordinates = campos + offset;

                Vector2 zoomChange = camera.Zoom * 0.1f;
                camera.Zoom = camera.Zoom - zoomChange;
            }

            camera.CalcultateMatrixes();
            RefreshPicture();
        }

        public void MouseDown(MouseButtons button, MouseEventArgs e)
        {
            if (button == MouseButtons.Left)
            {
                mouseStatus = MouseStatus.Down;
                startPointScr = new Vector2(e.X, e.Y);
                startPointScrNorm = camera.FlipScreenY(new Vector2(e.X, e.Y)); ;
            }
            else if (button == MouseButtons.Right)
            {
                mouseStatus = MouseStatus.MovingCamera;
                startPointScr = new Vector2(e.X, e.Y);
                startPointScrNorm = camera.FlipScreenY(new Vector2(e.X, e.Y)); ;
                startCamPos = camera.PositionInWorldCoordinates;
                Cursor.Current = Cursors.Hand;
            }
        }

        public void MouseMove(Vector2 pointScr, Vector2 pointScrNorm)
        {
            if (mouseStatus == MouseStatus.Down)
            {
                if ((pointScrNorm - startPointScrNorm).Length() > Constants.DragDist)
                {
                    // check if a selectable object is below the mouse curser
                    List<Bind.ISelectable> preSel = GetSelectableObjectsAtScreenCoord(startPointScrNorm, options.AllowSelectingAnchors);

                    if (preSel.Count > 0)
                    {
                        // yes, start moving objects
                        mouseStatus = MouseStatus.Moving;
                        StartMovingKeysAndAnchors(preSel);
                    }
                    else
                    {
                        // no, start opening an selection rectangle
                        mouseStatus = MouseStatus.Selecting;
                        StartRectangleSelection();
                    }
                }
            }

            if (mouseStatus == MouseStatus.MovingCamera)
            {
                // when moving the camera, the scale is not changed, so we can use ScreenToWorld here
                Vector2 offset_Key = camera.ScreenToWorld(pointScrNorm) - camera.ScreenToWorld(startPointScrNorm);

                camera.PositionInWorldCoordinates = startCamPos - offset_Key;
                camera.CalcultateMatrixes();
                RefreshPicture();
            }
            else if (mouseStatus == MouseStatus.Moving)
            {
                // reset all objects to thier start positions, the mouse move is offset then just added to this start positions
                foreach (KeyValuePair<Bind.IMovable, Vector2> m in dragStartPositions)
                {
                    m.Key.SetPosition(m.Value);
                }

                // calc offsets for key and anchors
                Vector2 offset_Key = camera.ScreenToWorld(pointScrNorm) - camera.ScreenToWorld(startPointScrNorm);
                Vector2 offset_Anchor = camera.ScreenToWorld(pointScrNorm) - camera.ScreenToWorld(startPointScrNorm);

                // apply relative key snapping
                if (options.UseRelativeSnap)
                {
                    // relative key snapping
                    if (options.H_SnapKey && options.V_SnapKey)
                    {
                        float xW = options.H_SnapKeySpace;
                        float yW = options.V_SnapKeySpace;
                        offset_Key.X = (float)Math.Round(offset_Key.X / xW) * xW;
                        offset_Key.Y = (float)Math.Round(offset_Key.Y / yW) * yW;
                    }
                    else if (options.H_SnapKey)
                    {
                        float xW = options.H_SnapKeySpace;
                        offset_Key.X = (float)Math.Round(offset_Key.X / xW) * xW;
                    }
                    else if (options.V_SnapKey)
                    {
                        float yW = options.V_SnapKeySpace;
                        offset_Key.Y = (float)Math.Round(offset_Key.Y / yW) * yW;
                    }

                    // relative anchor snapping
                    if (options.H_SnapAnchor && options.V_SnapAnchor)
                    {
                        float xW = options.H_SnapAnchorSpace;
                        float yW = options.V_SnapAnchorSpace;
                        offset_Anchor.X = (float)Math.Round(offset_Key.X / xW) * xW;
                        offset_Anchor.Y = (float)Math.Round(offset_Key.Y / yW) * yW;
                    }
                    else if (options.H_SnapAnchor)
                    {
                        float xW = options.H_SnapAnchorSpace;
                        offset_Anchor.X = (float)Math.Round(offset_Key.X / xW) * xW;
                    }
                    else if (options.V_SnapAnchor)
                    {
                        float yW = options.V_SnapAnchorSpace;
                        offset_Anchor.Y = (float)Math.Round(offset_Key.Y / yW) * yW;
                    }
                }

                // move keys first
                foreach (Data.Key movable in selection.Keys)
                {
                    MoveKey(movable, offset_Key);
                }

                // move anchors second because the have contrains to keys
                foreach (Data.Anchor movable in selection.Anchors)
                {
                    SnapAnchor(movable, offset_Anchor, options.H_SnapAnchorSpace, options.V_SnapAnchorSpace);
                }

                // sort keys
                foreach (Data.Curve curve in graph.Curves)
                {
                    curve.SortPoints();
                }

                form.ShowGradientPoint(selection, false, true);
                RefreshPicture();
            }
            else if (mouseStatus == MouseStatus.Selecting)
            {
                Graphics g = Utils.getGraphics(pictureBox);

                // restore
                Rectangle cleanRectangle = new Rectangle(selRectangle.X, selRectangle.Y, selRectangle.Width + 1, selRectangle.Height + 1);
                g.DrawImage(unselectedImage, cleanRectangle.X, cleanRectangle.Y, cleanRectangle, GraphicsUnit.Pixel);

                // new selection
                selRectangle = new Rectangle((int)Math.Min(startPointScr.X, pointScr.X), (int)Math.Min(startPointScr.Y, pointScr.Y),
                                             (int)Math.Abs(startPointScr.X - pointScr.X), (int)Math.Abs(startPointScr.Y - pointScr.Y));

                RefreshPicture();
            }
        }


        private void StartRectangleSelection()
        {
            selRectangle = new Rectangle((int)startPointScr.X, (int)startPointScr.Y, 1, 1);
            Image bmp = Utils.getBitmap(pictureBox);
            unselectedImage = new Bitmap((Image)bmp.Clone());
        }

        private void StartMovingKeysAndAnchors(List<Bind.ISelectable> preSel)
        {
            bool atLeastKeyIsSel = false;
            foreach (Bind.ISelectable k in preSel)
            {
                if (k.IsSelected) atLeastKeyIsSel = true;
            }

            if (!atLeastKeyIsSel)
            {
                // no selectable item below the cursor is already selected,
                // clear the existing selection (for selectable items not below the cursor)
                selection.Clear();
                selection.AddItems(preSel.ToArray());

            }

            // store startposistions
            dragStartPositions = new Dictionary<Bind.IMovable, Vector2>();
            foreach (Data.Curve c in graph.Curves)
            {
                foreach (Data.Key key in c.GetKeys())
                {
                    dragStartPositions.Add(key, key.Position);
                    if (key.LeftAnchor != null) dragStartPositions.Add(key.LeftAnchor, key.LeftAnchor.Position);
                    if (key.RightAnchor != null) dragStartPositions.Add(key.RightAnchor, key.RightAnchor.Position);
                }
            }
        }

        private void MoveKey(Data.Key key, Vector2 offsW)
        {

            Vector2 tmpW = dragStartPositions[key] + offsW;
            if (!options.UseRelativeSnap)
            {
                if (options.H_SnapKey && options.V_SnapKey)
                {
                    tmpW.X = (float)Math.Round(tmpW.X / options.H_SnapKeySpace) * options.H_SnapKeySpace;
                    tmpW.Y = (float)Math.Round(tmpW.Y / options.V_SnapKeySpace) * options.V_SnapKeySpace;
                }
                else if (options.H_SnapKey)
                {
                    tmpW.X = (float)Math.Round(tmpW.X / options.H_SnapKeySpace) * options.H_SnapKeySpace;
                }
                else if (options.V_SnapKey)
                {

                    tmpW.Y = (float)Math.Round(tmpW.Y / options.V_SnapKeySpace) * options.V_SnapKeySpace;
                }
            }

            tmpW = Vector2.Clamp(tmpW, Constants.lu, Constants.ro);
            key.setPosition(tmpW, true);

            // move keys own anchors with restrictions form neighbour keys

            // recalc position of left anchor (if there is a left anchor to this key, the anchor is unselected , and a key on the left and the anchore poscals is not on auto
            if (key.LeftAnchor != null && key.LeftAnchor.IsSelected == false && key.LeftAnchor.PosCal == Data.AnchorPosition.RelativeToKeyPos)
            {
                Data.Anchor a = key.LeftAnchor;
                Vector2 aStartOffs = a.Position;
                if (dragStartPositions.ContainsKey(a))
                {
                    aStartOffs = dragStartPositions[a] - dragStartPositions[key];
                }


                //Vector2 idealNewAnchorPos = tmpW + aStartOffs;
                a.Position = tmpW + aStartOffs;
                //a.setPosition(Vector2.Clamp(idealNewAnchorPos, new Vector2(key.left.pos.X, Constants.lu.Y), new Vector2(key.pos.X, Constants.ro.Y)));
            }

            if (key.RightAnchor != null && key.RightAnchor.IsSelected == false && key.RightAnchor.PosCal == Data.AnchorPosition.RelativeToKeyPos)
            {
                Data.Anchor a = key.RightAnchor;
                Vector2 aStartOffs = a.Position;
                if (dragStartPositions.ContainsKey(a))
                {
                    aStartOffs = dragStartPositions[a] - dragStartPositions[key];
                }
                //Vector2 idealNewAnchorPos = tmpW + aStartOffs;
                a.Position = tmpW + aStartOffs;
                //a.setPosition(Vector2.Clamp(idealNewAnchorPos, new Vector2(key.pos.X, Constants.lu.Y), new Vector2(key.right.pos.X, Constants.ro.Y)));
            }

        }

        private void SnapAnchor(Data.Anchor anchor, Vector2 offsW, float snapH, float snapV)
        {
            Vector2 tmpW;

            if (dragStartPositions.ContainsKey(anchor))
            {
                tmpW = dragStartPositions[anchor] + offsW;
            }
            else
            {
                tmpW = anchor.Position;
                dragStartPositions.Add(anchor, anchor.Position);
            }

            if (!options.UseRelativeSnap)
            {
                if (options.H_SnapAnchor && options.V_SnapAnchor)
                {
                    tmpW.X = (float)Math.Round(tmpW.X / snapH) * snapH;
                    tmpW.Y = (float)Math.Round(tmpW.Y / snapV) * snapV;
                }
                else if (options.H_SnapAnchor)
                {
                    tmpW.X = (float)Math.Round(tmpW.X / snapH) * snapH;
                }
                else if (options.V_SnapAnchor)
                {
                    tmpW.Y = (float)Math.Round(tmpW.Y / snapV) * snapV;
                }
            }

            anchor.Position = tmpW;
            anchor.PosCal = Data.AnchorPosition.RelativeToKeyPos;
        }

        public void DrawSelRect(Graphics graphics)
        {
            if (mouseStatus == MouseStatus.Selecting)
            {
                Pen x = new Pen(Color.DarkGray);
                graphics.DrawRectangle(x, selRectangle);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "pointScr")]
        public void MouseUp(Vector2 pointScr, Vector2 pointScrNorm)
        {
            if (mouseStatus == MouseStatus.MovingCamera)
            {
                mouseStatus = MouseStatus.Up;
                Cursor.Current = Cursors.Default;
                RefreshPicture();
            }
            else if (mouseStatus == MouseStatus.Down)
            {
                List<Bind.ISelectable> preSel = GetSelectableObjectsAtScreenCoord(pointScrNorm, options.AllowSelectingAnchors);
                mouseStatus = MouseStatus.Up;
                                
                selection.Clear();
                selection.AddItems(preSel.ToArray());
                
                form.ShowGradientPoint(selection, false, true);
                RefreshPicture();
            }
            else if (mouseStatus == MouseStatus.Moving)
            {
                mouseStatus = MouseStatus.Up;
                form.ShowGradientPoint(selection, false, true);
                RefreshPicture();
            }
            else if (mouseStatus == MouseStatus.Selecting)
            {
                mouseStatus = MouseStatus.Up;

                SelectInScreenCoord(selRectangle, Control.ModifierKeys == Keys.Shift);

                form.ShowGradientPoint(selection, true);
                RefreshPicture();
            }
        }
    }
}
