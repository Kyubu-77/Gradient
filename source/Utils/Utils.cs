using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LED_Planer
{
    public enum Tag
    {
        RED = 0,
        GREEN = 1,
        BLUE = 2
    }

    static class Utils
    {
        public static Image getBitmap(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                pictureBox.Image = bmp; //assign the picturebox.Image property to the bitmap created
            }
            return pictureBox.Image;
        }

        public static Graphics getGraphics(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                pictureBox.Image = bmp; //assign the picturebox.Image property to the bitmap created
            }
            Graphics g;
            g = Graphics.FromImage(pictureBox.Image);
            return g;
        }


        public static void DrawHorizontalGradient(Graphics graphics, int width, int height, Color from, Color to)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, 0),
                from,
                to);
            
            graphics.FillRectangle(linGrBrush, new RectangleF(0, 0, width, height));
        }

        public static void DrawMarker(Graphics graphics, Data.Key[] keys)
        {
            int s = 5;
            int s2 = s * 2;
            int h = (int)Math.Sqrt((s2 * s2) - (s * s));

            Brush b = keys.Length == 1 ? Constants.BrushOne : Constants.BrushMany;

            foreach (Data.Key key in keys)
            {
                int x = (int)(graphics.ClipBounds.Width * key.Position.Y);
                Point[] dOben = new Point[]
                {
                    new Point (x-s,0),
                    new Point (x+s,0),
                    new Point (x, h ),

                };
                graphics.FillPolygon(b, dOben);

                Point[] dUnten = new Point[]
                {
                    new Point (x-s,(int)graphics.ClipBounds.Height),
                    new Point (x+s,(int)graphics.ClipBounds.Height),
                    new Point (x,(int) graphics.ClipBounds.Height-h ),
                };

                graphics.FillPolygon(b, dUnten);
            }
        }

        public static float LimitTextZeroToOne(string text)
        {
            try
            {
                float position = (float)Convert.ToDouble(text);
                if (position < 0)
                {
                    return 0f;
                }
                else if (position > 1)
                {
                    return 1f;
                }
                return position;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static byte LimitTextZeroTo255(string text)
        {
            try
            {
                byte position = Convert.ToByte(text);
                if (position < 0)
                {
                    return 0;
                }
                else if (position > 255)
                {
                    return 255;
                }
                return position;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static float LimitFloatZeroToOne(float position)
        {
            if (position < 0)
            {
                return 0f;
            }
            else if (position > 1)
            {
                return 1f;
            }
            return position;
        }

        public static Data.Key GetRightestKey(Data.Key[] keys)
        {
            Data.Key rightestSelPoint = null;
            foreach (Data.Key key in keys)
            {
                if (rightestSelPoint == null || key.Position.X > rightestSelPoint.Position.X)
                {
                    rightestSelPoint = key;
                }
            }
            return rightestSelPoint;
        }

        public static void AddToArray<T>(ref T[] array, T key)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = key;
        }

        public static void RemoveFromArray<T>(ref T[] source, T key)
        {
            int index = Array.IndexOf(source, key);
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            source = dest;
        }

        public static void Empty<T>(ref T[] array)
        {
            Array.Resize(ref array, 0);
        }

        public static void Insert<T>(ref T[] array, int insertPosition, T key)
        {
            Array.Resize(ref array, array.Length + 1);

            for (int i = array.Length - 1; i > insertPosition; i--)
            {
                array[i] = array[i - 1];
            }
            array[insertPosition] = key;
        }

        public static void Remove<T>(T[] array, T entry)
        {
            int index = Array.FindIndex(array, p => p.Equals(entry));

            for (int i = index; i > array.Length; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }
    }
}
