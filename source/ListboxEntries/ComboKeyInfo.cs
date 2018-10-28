using C = LED_Planer.Constants;
using System;

namespace LED_Planer.LBE
{

    /// <summary>
    /// An entry in the combobox cboPoints. An entry contains all key on a certain x-position.
    /// E.g there may be an RED key, a GREEN key and serveral BLUE keys at the x-position
    /// </summary>
    public class ComboKeyInfo
    {
        public Data.Key[][] keys = new Data.Key[3][];
        float pos;
        string text;

        public string Text { get => text; set => text = value; }

        public ComboKeyInfo(Data.Key key, string text)
        {
            keys[C.RED] = new Data.Key[0];
            keys[C.GREEN] = new Data.Key[0];
            keys[C.BLUE] = new Data.Key[0];

            AddKey(key);

            this.text = text;
        }

        public void AddKey(Data.Key key)
        {
            pos = key.Position.X;
            Array.Resize(ref keys[key.Tag], keys[key.Tag].Length + 1);
            keys[key.Tag][keys[key.Tag].Length - 1] = key;
        }


        public override string ToString()
        {
            return pos.ToString() + " - " + text;
        }


        public Data.Key[] getAllKeys()
        {
            Data.Key[] ret = new Data.Key[keys[C.RED].Length + keys[C.GREEN].Length + keys[C.BLUE].Length];
            keys[C.RED].CopyTo(ret, 0);
            keys[C.GREEN].CopyTo(ret, keys[C.RED].Length);
            keys[C.BLUE].CopyTo(ret, keys[C.RED].Length + keys[C.GREEN].Length);
            return ret;
        }
    }
}
