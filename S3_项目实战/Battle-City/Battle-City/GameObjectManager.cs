using Battle_City.Properties;
using System;
using System.Collections.Generic;

namespace Battle_City
{
    class GameObjectManager : Object
    {
        private ImmovableType[,] map;
        private List<GameObject> objList;
        int winW;
        int winH;

        public GameObjectManager()
        {
            this.winW = ImmovableObject.sz.Width * 26;
            this.winH = ImmovableObject.sz.Height * 28;
            this.map = new ImmovableType[this.winW, this.winH];
            this.objList = new List<GameObject>();
        }

        public void CreateMap()
        {
            //top wall
            CreateObjectList(1, 1, 2, 5.5, ImmovableType.Wall);
            CreateObjectList(3, 1, 4, 5.5, ImmovableType.Wall);
            CreateObjectList(5, 1, 6, 4.5, ImmovableType.Wall);
            CreateObjectList(7, 1, 8, 4.5, ImmovableType.Wall);
            CreateObjectList(9, 1, 10, 5.5, ImmovableType.Wall);
            CreateObjectList(11, 1, 12, 5.5, ImmovableType.Wall);

            //bottom wall
            CreateObjectList(1, 8.5, 2, 13, ImmovableType.Wall);
            CreateObjectList(3, 8.5, 4, 13, ImmovableType.Wall);
            CreateObjectList(5, 7.5, 6, 11, ImmovableType.Wall);
            CreateObjectList(7, 7.5, 8, 11, ImmovableType.Wall);
            CreateObjectList(9, 8.5, 10, 13, ImmovableType.Wall);
            CreateObjectList(11, 8.5, 12, 13, ImmovableType.Wall);

            //middle wall
            CreateObjectList(2, 6.5, 4, 7.5, ImmovableType.Wall);
            CreateObjectList(9, 6.5, 11, 7.5, ImmovableType.Wall);
            CreateObjectList(5, 5.5, 6, 6.5, ImmovableType.Wall);
            CreateObjectList(7, 5.5, 8, 6.5, ImmovableType.Wall);
            CreateObjectList(6, 8, 7, 9, ImmovableType.Wall);

            //boss
            CreateObjectList(5.5, 12.5, 7.5, 14, ImmovableType.Wall);
            CreateObjectList(6, 13, 6.5, 13.5, ImmovableType.Boss);

            //steel
            CreateObjectList(0, 7, 1, 7.5, ImmovableType.Steel);
            CreateObjectList(12, 7, 13, 7.5, ImmovableType.Steel);
            CreateObjectList(6, 2, 7, 3, ImmovableType.Steel);
            CreateObjectList(6, 9, 7, 10, ImmovableType.Steel);
        }

        private void CreateObjectList(double r1, double c1, double r2, double c2, ImmovableType type)
        {
            int width = ImmovableObject.sz.Width;
            int height = ImmovableObject.sz.Height;

            int x1 = (int) (r1 * height * 2);
            int y1 = (int)(c1 * width * 2);
            int x2 = (int)(r2 * height * 2);
            int y2 = (int)(c2 * width * 2);

            for (int x = x1; x < x2; x+= height)
            {
                for (int y = y1; y < y2; y += width)
                {
                    map[x, y] = (ImmovableType)type;
                    this.objList.Add(new ImmovableObject(x, y, map[x, y]));
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
