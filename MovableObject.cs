using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;

namespace TankWar
{
    internal abstract class MovableObject : GameObject
    { 

        private Direction direction;
        //存储四个方向的图片
        protected Bitmap[] images = new Bitmap[4];
        public Direction Direction {
            protected get
            {
                return direction; 
            }
            set
            {
                direction = value;
                SetImage();
            }
        }
        public int Speed { get; set; }
        //下一个位置是否可以移动
        protected bool IsMoving;
        //是否按下按键
        protected bool IsPress;
        public MovableObject()
        {

        }
        public MovableObject(int x, int y,Direction direction, Bitmap[] images, int speed, bool isMoving)
        {
            this.X = x;
            this.Y = y;
            this.images = images;

            Direction = direction;
            Speed = speed;
            IsMoving = isMoving;
        }

        /// <summary>
        /// 更新对象状态
        /// </summary>
        /// <param name="graphics">指定的画布</param>
        public override void Update(Graphics graphics)
        {
            Move();
            base.Update(graphics);
        }

        /// <summary>
        /// 根据 Direction属性设置 不同朝向的坦克图片
        /// </summary>
        /// <returns></returns>
        public void SetImage()
        {
            switch (Direction)
            {
                case Direction.Up: SelfImage = images[0]; break;
                case Direction.Down: SelfImage = images[1]; break;  
                case Direction.Left: SelfImage = images[2];break;
                case Direction.Right: SelfImage = images[3];break;
            }
        }
        /// <summary>
        /// 移动前检测
        /// </summary>
        public abstract void MoveCheck();
        public abstract void CheckCollied();


        /// <summary>
        /// 边界检测
        /// </summary>
        public void CheckBorder()
        {
            switch (Direction)
            {
                case Direction.Up: if (Y - Speed < 0) IsMoving = false; else IsMoving = true;
                    break;
                case Direction.Down:
                    if (Y + Speed + Height > 450) IsMoving = false;else IsMoving = true;
                    break;
                case Direction.Left:
                    if (X - Speed < 0) IsMoving = false;else IsMoving = true;
                    break;
                case Direction.Right:
                    if (X + Speed + Width > 450) IsMoving = false;else IsMoving = true;
                    break;
            }
        }
        /// <summary>
        /// 移动tank
        /// </summary>
        public void Move()
        {
            //如果没有按下 W A S D键，及时 isMoving 为true 也不可移动
            // 用于我方坦克，敌方坦克始终为 true
            if (!IsPress) return;
            MoveCheck();
            if (IsMoving)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        Y -= Speed;
                        break;
                    case Direction.Down:
                        Y += Speed; 
                        break;
                    case Direction.Left: 
                         X -= Speed;
                        break;
                    case Direction.Right:
                        X += Speed;
                        break;
                }
            }
        }

    }
}
