using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
using System.Windows.Forms;

namespace TankWar
{
    internal class MyTank:MovableObject
    {
        private int startX;
        private int startY;
              public MyTank()
        {

        }
        public MyTank(int x, int y,Direction direction, Bitmap[] images, int speed, bool isMoving):base(x, y, direction, images, speed, isMoving)
        {
            startX = x; startY = y;            IsPress = false;
        }
        public override void MoveCheck()
        {
            // 如果已经将超出边界，不再进行碰撞检测 
            CheckBorder();
            if (!IsMoving) return;
            CheckCollied();
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
            if (GameObjectManager.PlayerIsCollision(willRect) != null)
            {
                IsMoving = false;
            }
        }

        public void KeyDown(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    Direction = Direction.Up;
                    IsMoving = true;
                    IsPress = true;
                    break;
                case Keys.S:
                    Direction = Direction.Down;
                    IsMoving = true;
                    IsPress = true;
                    break;
                case Keys.A:
                    Direction = Direction.Left;
                    IsMoving = true;
                    IsPress = true;
                    break;
                case Keys.D:
                    Direction = Direction.Right;
                    IsMoving = true;
                    IsPress = true;
                    break;
                case Keys.Space:
                    Attack();
                    break;
            }
        }
        public void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A ||
                e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                IsPress = false; 
            } 
        }
        /// <summary>
        /// 产生一个子弹
        /// </summary>
        private void Attack()
        {
            int x, y;
            //将子弹中心定在，坦克的左上角
            x = this.X - 11;
            y = this.Y - 11;
            if (Direction == Direction.Up)
            {
                x += Width / 2;  
            }
            else if (Direction == Direction.Down)
            {
                x += Width / 2;  
                y += Height; 
            }
            else if (Direction == Direction.Left)
            {
                y += Height / 2;
            }
            else if (Direction == Direction.Right)
            {
                x += Width;
                y += Height / 2;
            }
            GameObjectManager.CreateABullet(this.X, this.Y, Source.MyTank, Direction,Speed + 2);
        }
        /// <summary>
        /// 坦克恢复到初始状态
        /// </summary>
        public void Reset()
        {
            X = startX;
            Y = startY;
            Direction = Direction.Up;    
        }
    }
}
