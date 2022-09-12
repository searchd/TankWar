using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;

namespace TankWar
{
    /// <summary>
    /// 存储坦克图片
    /// </summary>
    internal class TankImages
    {
        public static Bitmap[] MyTankImages = {Resources.MyTankUp, Resources.MyTankDown,
            Resources.MyTankLeft, Resources.MyTankRight};
        public static Bitmap[] TigerTankImages = {Resources.MyTankUp, Resources.MyTankDown,
            Resources.MyTankLeft, Resources.MyTankRight};
        public static Bitmap[] PantherTankImages = {Resources.SlowUp, Resources.SlowDown,
            Resources.SlowLeft, Resources.SlowRight};
        public static Bitmap[] StuGTankImages = {Resources.QuickUp, Resources.QuickDown,
            Resources.QuickLeft, Resources.QuickRight};
        public static Bitmap[] GrayTankImages = {Resources.GrayUp, Resources.GrayDown,
            Resources.GrayLeft, Resources.GrayRight};
        public static Bitmap[] GreenTankImages = {Resources.GreenUp, Resources.GreenDown,
            Resources.GreenLeft, Resources.GreenRight};
        public static Bitmap[] BulletImages = {Resources.BulletUp, Resources.BulletDown,
            Resources.BulletLeft, Resources.BulletRight};
        public static Bitmap[] ExpImages = {Resources.EXP1,Resources.EXP2,Resources.EXP3,
            Resources.EXP4, Resources.EXP5};
        static TankImages()
        {
            foreach (var item in BulletImages)
            {
                item.MakeTransparent();                    
            }
            foreach(var item in ExpImages)
            {
                item.MakeTransparent();
            }

        }
    }
}
