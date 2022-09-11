using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace TankWar
{
    internal class GameObjectManager
    {
        // 单例模式，该类不可实例化
        private GameObjectManager() { }
        private static List<StaticObject> brickWalls = new List<StaticObject>();
        private static List<StaticObject> steelWalls = new List<StaticObject>();
        private static StaticObject boss;
        private static MyTank myTank;
        private static List<BadTank> badCompany = new List<BadTank>();
        private static int framworkCount = 1;
        //用于存储所有的 游戏对象，便于统一处理
        private static List<GameObject> gameObjects = new List<GameObject>();
        //用于存储 玩家不可 穿越的对象
        private static List<GameObject> notPassObjects = new List<GameObject>();
        // 用于存储 子弹对象 
        private static List<Bullet> bullets = new List<Bullet>();
        // 使用同一个随机数对象，保证使用 同一个随机数种子
        private static Random rd = new Random();
        /// <summary>
        /// 类加载时，创建对象（地图元素、坦克对象、boss）
        /// </summary>
        static GameObjectManager()
        {
            CreateAllItem();
            ClassifyObejcts();
        }
        /// <summary>
        /// 用于创建所有的游戏对像
        /// </summary>
        private static void CreateAllItem()
        {
            CreateWalls();
            CreateBoss();
            CreateMyTank();
        } 
        /// <summary>
        /// 将游戏对象进行分类
        /// </summary>
        private static  void ClassifyObejcts()
        {
            AddGameObjects();
            AddNotPassObjects();
        }
        /// <summary>
        /// 将所有对象添加到同一集合，便于绘制
        /// </summary>
        private static void AddGameObjects()
        {
            gameObjects.AddRange(steelWalls);
            gameObjects.AddRange(brickWalls);
            gameObjects.Add(boss);
            gameObjects.Add(myTank);
        } 
        /// <summary>
        /// 将 玩家不和通过的对象添加到一个集合，便于碰撞检擦
        /// </summary>
        private static void AddNotPassObjects()
        {
            notPassObjects.AddRange(steelWalls);
            notPassObjects.AddRange(brickWalls);
            notPassObjects.Add(boss);

        }
        private static void CreateBoss()
        {
            boss = new StaticObject(210, 420, Resources.Boss);
        }
        private static void CreateMyTank()
        {
            myTank = new MyTank(150, 420,Direction.Up, TankImages.MyTankImages, 2, false);
        }
        /// <summary>
        /// 在三个出生点，随机选中一个，随机生产一辆坦克
        /// </summary>
        private static void CreateABadTank()
        {
            int index = rd.Next(0, 5);
            int x, y;
            Direction direction;
            Bitmap[] images;
            int speed;
            if (index == 0)
            {
                x = 0;
                y = 0;
                direction = Direction.Right;
                speed = 2;
                images = TankImages.TigerTankImages;
            } else if (index == 1)
            {
                x = 210;
                y = 0;
                direction = Direction.Down;
                speed = 2;
                images = TankImages.PantherTankImages;
            } else if(index == 2)
            {
                x = 420;
                y = 0;
                speed = 4;
                direction = Direction.Left;
                images = TankImages.StuGTankImages;
            }else if(index == 3)
            {
                x = 0;
                y = 195;
                speed = 2;
                direction = Direction.Right;
                images = TankImages.GrayTankImages;
            }
            else
            {
                x = 420;
                y = 195;
                speed = 2;
                direction = Direction.Left;
                images = TankImages.GreenTankImages;
            }
            BadTank badTank = new BadTank(x, y, direction, images, speed, true);
            ClassifyABadTank(badTank);
        }
        public static void CreateABullet(int x, int y,Source source, Direction direction)
        {
            Bullet bullet = new Bullet(x, y,source, direction, TankImages.BulletImages, 4);
            ClassifyABullet(bullet);
        }
         private static void ClassifyABullet(Bullet bullet)
        {
            bullets.Add(bullet);
            gameObjects.Add(bullet);
        }

        /// <summary>
        /// 归类 敌方坦克
        /// </summary>
        private static void ClassifyABadTank(BadTank badTank)
        {
            badCompany.Add(badTank);
            gameObjects.Add(badTank);
            notPassObjects.Add(badTank);
        }
        /// <summary>
        /// 每个60帧生产一个坦克
        /// </summary>
        private static void BornBadTank()
        {
            if (framworkCount == 60)
            {
                framworkCount = 0;
                CreateABadTank();
            }
            else
            {
                framworkCount++;
            }
        }

    /// <summary>
    /// 用于生产地图元素
    /// </summary>
    private static void CreateWalls()
        {
            WallType wallType;
            for (int i = 0; i < MapTypes.map1.GetLength(0); i++)
            {
                for (int j = 0; j < MapTypes.map1.GetLength(1); j++)
                {
                    //byte型数组元素转换为 枚举类型
                    wallType = (WallType)MapTypes.map1[i, j];
                    if (wallType == WallType.Brick)
                    {
                        brickWalls.Add(new StaticObject(j * 15, i * 15, Resources.wall));
                    }
                    else if (wallType == WallType.Stell)
                    {
                        steelWalls.Add(new StaticObject(j * 15, i * 15, Resources.steel));
                    }
                }
            }
        }

        /// <summary>
        /// 更新所有对象状态
        /// </summary>
        /// <param name="formGraphics">指定被绘制窗口的画板对象</param>
        public static void Update(Graphics imageCacheGraphics)
        {
            BornBadTank();
            for(int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(imageCacheGraphics);
            }
            //foreach 的底层使用的是迭代器， 当游戏线程在使用
            //迭代器的next()方法 访问下一个元素时，按键线程增加新子弹对象到其中，抛出异常。
            //foreach (GameObject item in gameObjects)
            //{
            //    item.Update(imageCacheGraphics);
            //}
        }        

        /// <summary>
        /// 方向按键按下
        /// </summary>
        /// <param name="e"></param>
        public static void KeyDown(KeyEventArgs e)
        {
            myTank.KeyDown(e);
        }

        public static void KeyUp(KeyEventArgs e)
        {
            myTank.KeyUp(e); 
        }
        
        /// <summary>
        /// 检测玩家是否将要碰撞到不可通过对象
        /// </summary>
        /// <param name="rectangle">未来位置的rectangele对象</param>
        /// <returns>即将触碰到的对象</returns>
        public static GameObject PlayerIsCollision(Rectangle rectangle)
        {
            foreach(GameObject obj in notPassObjects)
            {
                if (obj.GetRectangle().IntersectsWith(rectangle))
                {
                    return obj;
                }
            }
            return null;
        }
        /// <summary>
        /// 地方坦克检测碰撞 
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static GameObject BadTankIsCollision(Rectangle rectangle)
        {
            foreach(GameObject  obj in steelWalls)
            {
                if (obj.GetRectangle().IntersectsWith(rectangle))
                {
                    return obj;
                }
            }
            foreach(GameObject obj in brickWalls)
            {
                if (obj.GetRectangle().IntersectsWith(rectangle))
                {
                    return obj;
                }
            }
            if (boss.GetRectangle().IntersectsWith(rectangle))
            {
                return boss;
            }
            if (myTank.GetRectangle().IntersectsWith(rectangle))
            {
                return myTank;
            }
            return null;
        }
    }
}

