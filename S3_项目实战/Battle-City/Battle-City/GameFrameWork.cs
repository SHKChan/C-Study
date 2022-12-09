using System;
using System.Drawing;

namespace Battle_City
{
    class GameFrameWork
    {
        public static Graphics graphics;
        public GameObjectManager Manager { get; private set; }

        public GameFrameWork()
        {
            GameFrameWork.graphics = null;
            Manager = new GameObjectManager();
        }

        public void Start()
        {
            Manager.CreateMap();
        }

        public void Update()
        {
            GameFrameWork.graphics.Clear(Color.Black);
            Manager.DrawMap();
        }
    }
}
