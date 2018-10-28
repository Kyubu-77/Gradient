using System.Collections.Generic;
using U = LED_Planer.Utils;

namespace LED_Planer
{

    public class SelectInformation
    {
        public List<Bind.ISelectable> KeysAndAnchors = new List<Bind.ISelectable>();

        public Data.Key[] Keys = new Data.Key[0];
        public Data.Key[] RedKeys = new Data.Key[0];
        public Data.Key[] GreenKeys = new Data.Key[0];
        public Data.Key[] BlueKeys = new Data.Key[0];

        public Data.Anchor[] Anchors = new Data.Anchor[0];


        public void AddKeys(IEnumerable<Data.Key> newItems)
        {
            foreach (Data.Key item in newItems)
            {
                AddKey(item);
            }
        }

        public void AddItems(Bind.ISelectable[] newItems)
        {
            foreach (Bind.ISelectable item in newItems)
            {
                if (item.GetType() == typeof(Data.Key))
                {
                    AddKey((Data.Key)item);
                }
                else
                {
                    AddAnchor((Data.Anchor)item);
                }
            }
        }



        public SelectInformation AddKey(Data.Key key)
        {
            key.IsSelected = true;

            U.AddToArray(ref Keys, key);
            KeysAndAnchors.Add(key);

            if (((Tag)key.Tag) == Tag.RED)
            {
                U.AddToArray(ref RedKeys, key);
            }
            else if (((Tag)key.Tag) == Tag.GREEN)
            {
                U.AddToArray(ref GreenKeys, key);
            }
            else if (((Tag)key.Tag) == Tag.BLUE)
            {
                U.AddToArray(ref BlueKeys, key);
            }
            return this;

        }

        public SelectInformation DeleteKey(Data.Key key)
        {
            key.IsSelected = false;

            U.RemoveFromArray(ref Keys, key);
            KeysAndAnchors.Remove(key);

            if (((Tag)key.Tag) == Tag.RED)
            {
                U.RemoveFromArray(ref RedKeys, key);
            }
            else if (((Tag)key.Tag) == Tag.GREEN)
            {
                U.RemoveFromArray(ref GreenKeys, key);
            }
            else if (((Tag)key.Tag) == Tag.BLUE)
            {
                U.RemoveFromArray(ref BlueKeys, key);
            }
            return this;

        }
        public void Clear()
        {
            foreach (Data.Key key in Keys)
            {
                key.IsSelected = false;
            }


            U.Empty(ref Keys);
            U.Empty(ref RedKeys);
            U.Empty(ref GreenKeys);
            U.Empty(ref BlueKeys);


            foreach (Data.Anchor a in Anchors)
            {
                a.IsSelected = false;
            }
            U.Empty(ref Anchors);

            KeysAndAnchors.Clear();
        }


        internal bool HaveSamePosX()
        {
            if (Keys.Length == 0) return true;

            float pos = Keys[0].Position.X;

            for (int i = 1; i < Keys.Length; i++)
            {
                if (Keys[i].Position.X != pos) return false;
            }

            return true;
        }


        public bool HaveSameSegmentType()
        {
            if (Keys.Length == 0) return true;

            Data.SegmentKind segmentType = Keys[0].getSegmentType();

            for (int i = 1; i < Keys.Length; i++)
            {
                if (Keys[i].getSegmentType() != Data.SegmentKind.None) // ignore the leftest keys of a curve because the have no segmentInfo
                {
                    if (Keys[i].getSegmentType() != segmentType) return false;
                }

            }

            return true;
        }

        static private bool HaveSameValue(Data.Key[] keys)
        {
            if (keys.Length == 0) return true;

            float pos = keys[0].Position.Y;

            for (int i = 1; i < keys.Length; i++)
            {
                if (keys[i].Position.Y != pos) return false;
            }

            return true;
        }

        public bool redKeysHaveSameRedValue()
        {
            return HaveSameValue(RedKeys);
        }

        internal bool greenKeysHaveSameRedValue()
        {
            return HaveSameValue(GreenKeys);
        }

        internal void AddAnchor(Data.Anchor anchor)
        {

            anchor.IsSelected = true;
            U.AddToArray(ref Anchors, anchor);
            KeysAndAnchors.Add(anchor);


        }

        internal void DeleteAnchor(Data.Anchor anchor)
        {

            anchor.IsSelected = false;
            U.RemoveFromArray(ref Anchors, anchor);
            KeysAndAnchors.Remove(anchor);


        }

        internal bool blueKeysHaveSameRedValue()
        {
            return HaveSameValue(BlueKeys);
        }

    }
}
