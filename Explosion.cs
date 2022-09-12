using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    internal class Explosion:StaticObject
    {
        private Image[] ExpImages;
        private int index = 0;
        private int count = 0;
        private int speed = 1; 
        public Explosion(int x, int y, Image[] images)
        {
            this.ExpImages = images;
            SelfImage = ExpImages[0];
            this.X = x - Width/2;
            this.Y = y - Height/2;
        }
        public Explosion() { }

        public void ChangeImage ()
        {
            if(count == ExpImages.Length)
            {
                IsDestory = true;
                return;
            }
            index = count / speed;
            SelfImage = ExpImages[index];
            count++;
        }
        public override void DrawSelf(Graphics graphics)
        {
            ChangeImage();
            base.DrawSelf(graphics);
        }
    }
}
