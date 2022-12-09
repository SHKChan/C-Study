using System;
using System.Collections.Generic;
using System.Drawing;

namespace Battle_City
{
    enum Direction
    {
        Up = 0,
        Down,
        Left,
        Right
    }
    class MovableObejct : GameObject
    {
        public int Speed { get; set; }
        public Direction Dir { get; set; }
        public Bitmap[] imgArr = new Bitmap[4];

        public MovableObejct(int x, int y, int speed)
        {
            X = x;
            X = y;
            Speed = speed;
        }

        protected override Bitmap GetImage()
        {
            Bitmap imgTemp = imgArr[(int)Dir];
            imgTemp.MakeTransparent(Color.Black);
            return imgTemp;
        }
    }
}
