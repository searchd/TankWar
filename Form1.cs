using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWar
{
    public partial class Form1 : Form
    {
        private Thread gameMainThread;
        public Form1()
        {
            InitializeComponent();
            Graphics windowGraphics = this.CreateGraphics();
            gameMainThread = new Thread(() =>
            {
                GameFramework.Start();
                while (true)
                {
                    //获取绘制好的一帧图片
                    Image anFramwork = GameFramework.Update(); // 游戏 后台
                    //将该帧图片绘制在主窗口上
                    windowGraphics.DrawImage(anFramwork, 0, 0);
                    Thread.Sleep(1000/60);// FPS 设计大概每秒钟刷新 60次；
                }
            }); ;
            gameMainThread.Start();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameMainThread.Abort(); // 在主窗体关闭后，终止游戏后台线程
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
