using Battle_City.Properties;
using System;
using System.Drawing;

namespace Battle_City
{
    enum ImmovableType
    {
        Empty = 0,
        Wall = 1,
        Steel = 2,
        Boss = 3
    }

    class ImmovableObject : GameObject
    {
        public static Size sz = new Size(15, 15);
        public static bool isBossDraw = false;

        public ImmovableObject(int x, int y, ImmovableType t)
        {
            X = x;
            Y = y;
            T = (int)t;
            switch (t)
            {
                case ImmovableType.Wall:
                    Img = Resources.wall;
                    break;
                case ImmovableType.Steel:
                    Img = Resources.steel;
                    break;
                case ImmovableType.Boss:
                    Img = Resources.boss;
                    break;
                default:
                    Img = Resources.wall;
                    break;
            }
        }

        protected override Bitmap GetImage()
        {
            return Img;
        }
    }
}
