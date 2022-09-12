using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankWar
{
    abstract class GameObject
    {
        //位置信息
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        private Image selfImage;
        private bool isDestory;
        public bool IsDestory {
            get
            {
                return isDestory;
            }
            set
            {
                isDestory = value;
            }
        }
            
        /// <summary>
        /// 设置图片属性时，同时赋予对象高度
        /// </summary>
        public Image SelfImage
        {
            get { return selfImage; }
            set
            {
                selfImage = value;
                Width = selfImage.Width;
                Height = selfImage.Height;
            }
        }
       /// <summary>
       /// 生产游戏对象的矩形对象，用于碰撞检测
       /// </summary>
       /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
        /// <summary>
        /// 绘制自身图片
        /// </summary>
        public virtual void DrawSelf(Graphics graphics)
        {
            graphics.DrawImage(SelfImage,X, Y);
        }

        public virtual void Update(Graphics graphics)
        {
            DrawSelf(graphics);
        }
    }
}
