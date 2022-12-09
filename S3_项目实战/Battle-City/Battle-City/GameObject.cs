using System;
using System.Drawing;

namespace Battle_City
{
    abstract class GameObject : Object
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap Img { get; set; }
        public int T { get; set; }

        public GameObject() { }

        public void Draw()
        {
            Graphics g = GameFrameWork.graphics;
            g.DrawImage(GetImage(), X, Y);
        }

        protected abstract Bitmap GetImage();
    }
}
