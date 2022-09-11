using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    internal class BadTank : MovableObject
    {
        private static Random random = new Random();
        public BadTank()
        {
        }
        public BadTank(int x, int y,Direction direction, Bitmap[] images, int speed, bool isMoving) : base(x, y, direction, images, speed, isMoving)
        {
            IsPress = true;
        }
        /// <summary>
        /// 移动确认
        /// </summary>
        public override void MoveCheck()  {
            CheckBorder();
            while (!IsMoving)
            {
                ChangeDirection();
                CheckBorder();
            }
            CheckCollied();
            while (!IsMoving)
            {
                ChangeDirection();
                CheckCollied();
            }
        }
        /// <summary>
        /// 下一个位置是否将碰撞不可通过物体
        /// </summary>
        /// <returns></returns>
        public override void CheckCollied()
        {
            //下一个位置的 Rectangel
            Rectangle willRect = GetRectangle();
            switch (Direction)
            {
                case Direction.Up: willRect.Y -= Speed; break;
                case Direction.Down: willRect.Y += Speed; break;
                case Direction.Left: willRect.X -= Speed; break;
                case Direction.Right: willRect.X += Speed; break;
            }
            if (GameObjectManager.BadTankIsCollision(willRect) != null)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
            }
        }
        /// <summary>
        /// 改变坦克的方向, 随机改变
        /// </summary>
        public void ChangeDirection()
        {
            // 方式一  缺点是坦克在分叉路口总是向同一个地方变道
            //int dir = (int) Direction;
            //dir++;
            //dir %= 4;
            //Direction = (Direction) dir;

            Direction dir;
            do
            {
                dir = (Direction) random.Next(0, 4);
            } while (dir ==  Direction);
            Direction = dir;
        }
    }
}
