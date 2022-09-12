using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    enum GameState
    {
        Runing, Over
    }
    internal class GameFramework
    {
         // 缓冲图片中的 画布对象 
        private static Graphics imageCachGraphics;

        private static GameState gameState = GameState.Runing;
        //生产一张和屏幕一样大小的空白位图
        private static Bitmap bitmap = new Bitmap(450, 450);
        static GameFramework()
        {
            //获取该图片的 画布对象
            imageCachGraphics = Graphics.FromImage(bitmap);
        }
        private GameFramework() { } //单例模式 不能实例化
        /// <summary>
        /// 返回 缓冲图片中的画布对象
        /// </summary>
        /// <returns></returns>
        public static Graphics getImageCachGraphics()
        {
            return imageCachGraphics;
        }
        public static void Start()
        {
            Update();
        }
        public static Image Update()
        {
            imageCachGraphics.Clear(Color.Black);
            //清除整个图面，并填充背景色
            //更新游戏对象状态
            if (GameState.Runing == gameState)
            {
                GameObjectManager.Update(imageCachGraphics);
            }else if(GameState.Over == gameState)
            {
                Image gameOverImage = Properties.Resources.GameOver;
                int x = (450 - gameOverImage.Width ) / 2;
                int y = (450 - gameOverImage.Height )/ 2;
                imageCachGraphics.DrawImage(gameOverImage, new Point(x , y));
            }
            return bitmap;
        }
        public static void ChargeGameState(GameState state)
        {
            gameState = state;
        }
    }
}
