namespace LED_Planer.Data
{
    /// <summary>
    /// Used to define how the bezier control points(anchors) are affected when moving the curve control point
    /// </summary>
    public enum AnchorPosition : int
    {
        RelativeToKeyPos = 0, // anchors keep same releative poisition to the curve conrol pont
        AutoOnQuarter,        // anchors are moved to 25% of the segment for left anchors and 75% for right
        InLineWithOtherKey
    }
}
