using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    enum Source
    {
       MyTank, BadTank
    }
    internal class Bullet : MovableObject
    {
        public Source TankSource{get; set;}

        public Bullet() { }

        public Bullet(int x, int y,Source tanksource, Direction direction, Bitmap[] bulletImages, int speed)
        {
            this.X = x;
            this.Y = y;
            TankSource = tanksource;
            Speed = speed;
            images = bulletImages;

            Direction = direction;

            IsPress = true;
        }
        public override void CheckCollied()
        {
            GameObjectManager.BulletCollision(this);    
        }

        public override void MoveCheck()
        {
            CheckBorder();
            //碰撞边界时，改变isDestroy = ture
            if (!IsMoving)
            {
                IsDestory = true;
                return;
            }
            CheckCollied();
        }
    }
}
