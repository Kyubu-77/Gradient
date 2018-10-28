using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED_Planer.Data
{
    public enum SegmentKind : int
    {
        None = 0,
        UseLeft = 1,
        UseRight = 2,
        Line = 3,
        Bezier = 4,
    }
}
