using System;
using System.Collections.Generic;
using System.Drawing;

namespace Battle_City
{
    class GameObjectManager : Object
    {
        private List<GameObject> objList;
        private ImmovableType[,] Map { get; set; }
        public int MapSzCoorX { get; private set; }
        public int MapSzCoorY { get; private set; }
        public int MapSzPixelX { get; private set; }
        public int MapSzPixelY { get; private set; }

        public int Coor2Pixel(double sz, int t)
        {
            if (Convert.ToBoolean(t))
                return (int)(sz * ImmovableObject.sz.Width);
            else
                return (int)(sz * ImmovableObject.sz.Height);
        }

        public int Pixel2Coor(double sz, int t)
        {
            if (Convert.ToBoolean(t))
                return (int)(sz / ImmovableObject.sz.Width);
            else
                return (int)(sz / ImmovableObject.sz.Height);
        }

        public GameObjectManager()
        {
            MapSzCoorX = 26;
            MapSzCoorY = 28;
            int MapSzPixelX = Coor2Pixel(MapSzCoorX, 0);
            int MapSzPixelY = Coor2Pixel(MapSzCoorY, 1);
            Map = new ImmovableType[MapSzPixelX, MapSzPixelY];
            objList = new List<GameObject>();
        }

        public void CreateMap()
        {
            //top wall
            CreateObjectList(2, 2, 4, 11, ImmovableType.Wall);
            CreateObjectList(6, 2, 8, 11, ImmovableType.Wall);
            CreateObjectList(10, 2, 12, 9, ImmovableType.Wall);
            CreateObjectList(14, 2, 16, 9, ImmovableType.Wall);
            CreateObjectList(18, 2, 20, 11, ImmovableType.Wall);
            CreateObjectList(22, 2, 24, 11, ImmovableType.Wall);

            //bottom wall
            CreateObjectList(2, 17, 4, 26, ImmovableType.Wall);
            CreateObjectList(6, 17, 8, 26, ImmovableType.Wall);
            CreateObjectList(10, 15, 12, 22, ImmovableType.Wall);
            CreateObjectList(14, 15, 16, 22, ImmovableType.Wall);
            CreateObjectList(18, 17, 20, 26, ImmovableType.Wall);
            CreateObjectList(22, 17, 24, 26, ImmovableType.Wall);

            //middle wall
            CreateObjectList(4, 13, 8, 15, ImmovableType.Wall);
            CreateObjectList(18, 13, 22, 15, ImmovableType.Wall);
            CreateObjectList(10, 11, 12, 13, ImmovableType.Wall);
            CreateObjectList(14, 11, 16, 13, ImmovableType.Wall);
            CreateObjectList(12, 16, 14, 18, ImmovableType.Wall);

            //steel
            CreateObjectList(0, 14, 2, 15, ImmovableType.Steel);
            CreateObjectList(24, 14, 26, 15, ImmovableType.Steel);
            CreateObjectList(12, 4, 14, 6, ImmovableType.Steel);
            CreateObjectList(12, 18, 14, 20, ImmovableType.Steel);

            //boss
            CreateObjectList(11, 25, 15, 26, ImmovableType.Wall);
            CreateObjectList(11, 26, 12, 28, ImmovableType.Wall);
            CreateObjectList(14, 26, 15, 28, ImmovableType.Wall);
            CreateObjectList(12, 26, 13, 27, ImmovableType.Boss);
        }

        private void CreateObjectList(double r1, double c1, double r2, double c2, ImmovableType type)
        {
            int width = ImmovableObject.sz.Width;
            int height = ImmovableObject.sz.Height;

            int x1 = Coor2Pixel(r1, 0);
            int y1 = Coor2Pixel(c1, 0);
            int x2 = Coor2Pixel(r2, 0);
            int y2 = Coor2Pixel(c2, 0);

            for (int x = x1; x < x2; x+= height)
            {
                for (int y = y1; y < y2; y += width)
                {
                    int coorX = Pixel2Coor(x, 0);
                    int coorY = Pixel2Coor(y, 1);
                    Map[coorX, coorY] = type;
                    if (ImmovableType.Boss == type)
                    {
                        Map[coorX + 1, coorY] = type;
                        Map[coorX, coorY + 1] = type;
                        Map[coorX + 1, coorY + 1] = type;
                    }
                    objList.Add(new ImmovableObject(x, y, type));
                }
            }
        }

        public void DrawMap()
        {
            foreach (var item in objList)
            {
                item.Draw();
            }
        }
    }
}
