using LED_Planer.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace LED_Planer
{
    public class Export
    {

        static public string Gen1001JsonRGBPoints(Gradient gradient)
        {
            string[] outPut = new string[1001];

            for (int i = 0; i <= 1000; i++)
            {
                Color c = gradient.GetColorAt(i * 0.001f);
                outPut[i] = "[" + c.R + "," + c.G + "," + c.B + "]";
            }

            string points = "[" + string.Join(",", outPut) + "]";

            return "{ \"Name\":\"" + gradient.name + "\"," + "\"Points\":" + points + "}";
        }
    }
}
