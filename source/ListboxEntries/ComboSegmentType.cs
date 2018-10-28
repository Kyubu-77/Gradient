namespace LED_Planer.LBE
{
    public class ComboSegmentType
    {
        private string text;
        private Data.SegmentKind value;
        public Data.SegmentKind Value { get => value; set => this.value = value; }

        public ComboSegmentType(string text, Data.SegmentKind segmentType)
        {
            this.text = text;
            value = segmentType;
        }

        public override string ToString()
        {
            return text;
        }
    }
}

