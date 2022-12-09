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

        public ImmovableObject(int x, int y, ImmovableType t)
        {
            this.X = x;
            this.Y = y;
            this.T = (int)t;
            switch (t)
            {
                case ImmovableType.Wall:
                    this.Img = Resources.wall;
                    break;
                case ImmovableType.Steel:
                    this.Img = Resources.steel;
                    break;
                case ImmovableType.Boss:
                    this.Img = Resources.boss;
                    break;
                default:
                    this.Img = Resources.wall;
                    break;
            }
        }

        protected override Bitmap GetImage()
        {
            return this.Img;
        }
    }
}
