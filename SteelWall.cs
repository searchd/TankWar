using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    internal class SteelWall:StaticObject
    {
       public SteelWall()
        {

        }
        public SteelWall(int x, int y, Image selfImage) : base(x, y, selfImage)
        {

        }
    }
}
