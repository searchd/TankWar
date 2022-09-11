using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;

namespace TankWar
{
    internal class StaticObject : GameObject
    {
        public StaticObject(int x, int y, Image img)
        {
            this.X = x;
            this.Y = y;
            this.SelfImage = img;
        }
    }
}
