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
            TankSource = tanksource;
            Speed = speed;
            images = bulletImages;
            Direction = direction;
            X = x - Width / 2;
            Y = y - Height / 2;
        }

        public override void CheckCollied()
        {
            throw new NotImplementedException();
        }

        public override void MoveCheck()
        {
            throw new NotImplementedException();
        }
    }
}
