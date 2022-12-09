using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Battle_City
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private GameFrameWork frameWork;
        //双缓冲技术防止闪烁
        private Graphics graphics; //再在窗体上绘制位图
        private Bitmap bitmap; //先绘制在位图上

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            frameWork = new GameFrameWork();
            graphics = CreateGraphics();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            GameFrameWork.graphics = Graphics.FromImage(bitmap);

            thread = new Thread(new ThreadStart(GameMainThread));
            thread.Start();
        }

        public void GameMainThread()
        {
            //GameFrameWork
            frameWork.Start();

            int sleepTime = 1000 / 60;
            while (true)
            {
                frameWork.Update();
                graphics.DrawImage(bitmap, 0, 0);
                Thread.Sleep(sleepTime); //FPS set to 60
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}
