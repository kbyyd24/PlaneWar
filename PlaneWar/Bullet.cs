using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    /*
     * 子弹类
     * @author 高悦翔
     */
    class Bullet
    {
        //static double pi = Math.PI;
        private int bullet_x;
        private int bullet_y;
        private int angle;
        private int distance;
        private Image bulletImage;

        public int BulX
        {
            get
            {
                return bullet_x;
            }
        }
        public int BulY
        {
            get
            {
                return bullet_y;
            }
        }
        public Image BulletImage
        {
            get
            {
                return bulletImage;
            }
        }

        public Bullet(int x, int y, int angle, int distance)
        {
            bullet_x = x;
            bullet_y = y;
            this.angle = angle;
            this.distance = distance;
            switch (this.angle)
            {
                case 90:
                    bulletImage = Resources.bul02;//直角子弹
                    bullet_y -= 17;
                    break;
                case 60:
                    bulletImage = Resources.bul02_30;//三十度角
                    bullet_x += 10;
                    bullet_y -= 17;
                    break;
                case -60:
                    bulletImage = Resources.bul02__30;//60
                    bullet_x -= 10;
                    bullet_y -= 17;
                    break;
                case 30:
                    bulletImage = Resources.bul02_60;//60
                    bullet_x += 20;
                    bullet_y -= 12;
                    break;
                case -30:
                    bulletImage = Resources.bul02__60;//60
                    bullet_x -= 20;
                    bullet_y -= 12;
                    break;
                default:
                    break;
            }
            if (bullet_y < -10)
            {
                bullet_y = -20;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bulletImage, new Point(bullet_x, bullet_y));
        }

        public void Move()//移动子弹，需改进
        {
            switch (this.angle)
            {
                case 90:
                    bullet_y -= 17;
                    break;
                case 60:
                    bullet_x += 10;
                    bullet_y -= 17;
                    break;
                case -60:
                    bullet_x -= 10;
                    bullet_y -= 17;
                    break;
                case 30:
                    bullet_x += 20;
                    bullet_y -= 12;
                    break;
                case -30:
                    bullet_x -= 20;
                    bullet_y -= 12;
                    break;
                default:
                    break;
            }
            if (bullet_y < -10)
            {
                bullet_y = -20;
            }
        }
    }
}
