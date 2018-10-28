using System;
using System.Collections.Generic;
using LED_Planer.Data;

namespace LED_Planer.Graph
{
    public class Graph2D
    {
        private List<Data.Curve> curves;
        public List<Data.Curve> Curves { get => curves; }

        public Graph2D()
        {
            curves = new List<Data.Curve>();
        }

        public void AddCurve(Data.Curve curve)
        {
            curves.Add(curve);
        }

        internal List<Key> SelectFirstRGBPoint()
        {
            List<Key> ret = new List<Key>();
            foreach (Curve curve in curves)
            {
                Key[] keys = curve.GetKeys();
                keys[0].IsSelected = true;
                ret.Add(keys[0]);
            }
            return ret;
        }
    }
}
