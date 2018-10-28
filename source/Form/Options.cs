using System;

namespace LED_Planer
{
    // move snap grid to front
    public class Options
    {
        // settings
        public bool ShowAnchors;
        public bool AllowSelectingAnchors;

        internal void SetShowAnchors(bool b) { ShowAnchors = b; }
        internal void SetAllowSelectingAnchors(bool b) { AllowSelectingAnchors = b; }

        // grid

        public bool H_ShowGrid;
        public bool V_ShowGrid;

        public float H_GridSpace;
        public float V_GridSpace;

        public bool H_ShowMajorGrid;
        public bool V_ShowMajorGrid;

        public int H_MayorLineEveryXth;
        public int V_MayorLineEveryXth;

        public bool MayorLinesOnly;


        internal void SetGrid_Show_H(bool b) { H_ShowGrid = b; }
        internal void SetGrid_Show_V(bool b) { V_ShowGrid = b; }
        internal void SetGrid_Space_H(String text) { H_GridSpace = (float)Convert.ToDouble(text); }
        internal void SetGrid_Space_V(object text) { V_GridSpace = (float)Convert.ToDouble(text); }

        internal void SetGrid_Majorlines_Show_H(bool b) { H_ShowMajorGrid = b; }
        internal void SetGrid_Majorlines_Show_V(bool b) { V_ShowMajorGrid = b; }
        internal void SetGrid_MayjorLine_EveryXth_H(String text) { H_MayorLineEveryXth = Convert.ToInt16(text); }
        internal void SetGrid_MayjorLine_EveryXth_V(string text) { V_MayorLineEveryXth = Convert.ToInt16(text); }
        internal void SetMainLinesOnly(bool b) { MayorLinesOnly = b; }

        // snap
        public bool H_SnapKey;
        public bool V_SnapKey;

        public float H_SnapKeySpace;
        public float V_SnapKeySpace;
        public bool UseRelativeSnap;

        public bool H_SnapAnchor;
        public bool V_SnapAnchor;

        public float H_SnapAnchorSpace;
        public float V_SnapAnchorSpace;

        internal void SetSnap_Key_H(bool b) { H_SnapKey = b; }
        internal void SetSnap_Key_V(bool b) { V_SnapKey = b; }
        internal void SetSnap_Key_Space_H(String b) { H_SnapKeySpace = (float)Convert.ToDouble(b); }
        internal void SetSnap_Key_Space_V(String b) { V_SnapKeySpace = (float)Convert.ToDouble(b); }
        internal void SetSnap_Use_Relative(bool b) { UseRelativeSnap = b; }

        internal void SetSnap_Anchor_H(bool b) { H_SnapAnchor = b; }
        internal void SetSnap_Anchor_V(bool b) { V_SnapAnchor = b; }
        internal void SetSnap_Anchor_Space_H(String b) { H_SnapAnchorSpace = (float)Convert.ToDouble(b); }
        internal void SetSnap_Anchor_Space_V(String b) { V_SnapAnchorSpace = (float)Convert.ToDouble(b); }
        
    }

}
