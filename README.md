# TankWar 
以siki老师的游戏原理为基础，对siki老师的项目进行重构使其更加面向对象。<a href="https://www.bilibili.com/video/BV1jr4y1Q7kG/?spm_id_from=333.788.recommend_more_video.2&vd_source=7a5655176cf873c07351d19ba7ddfa1c">坦克大战 教程</a>
### 主要类介绍
 1、GameFramework 控制游戏的每一帧图像的生产。

 2、GameObejctManager  工具类 管理游戏对象：比如游戏对象的存储、游戏对象的创建、绘制、碰撞检测。

 3、GameObject 抽象类 所有游戏对象的父类，定义基本属性（坐标、长/宽度、图片）

 4、StaticObjec 所有不可移动对象的父类。

 5、MovableObject 所有可移动对象的父类。

 6、TankImages  用于管理所有的游戏对象要使用的图片。

 7、MapTypes 用于存储不同地图数组数据。
 
 ###  类结构图
 <img width="420" alt="企业微信截图_16629128307183" src="https://user-images.githubusercontent.com/50863104/189537913-6bfe30de-725e-4ad0-9226-95a26892514c.png">
