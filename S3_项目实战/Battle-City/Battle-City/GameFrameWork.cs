using System;
using System.Drawing;

namespace Battle_City
{
    class GameFrameWork
    {
        public static Graphics graphics;
        private GameObjectManager manager;

        public GameFrameWork()
        {
            GameFrameWork.graphics = null;
            this.manager = new GameObjectManager();
        }

        public void Start()
        {
            this.manager.CreateMap();
        }

        public void Update()
        {
            GameFrameWork.graphics.Clear(Color.Black);
            this.manager.DrawMap();
        }
    }
}
