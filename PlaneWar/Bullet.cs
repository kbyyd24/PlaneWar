using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class Bullet//子弹
    {
        //static double pi = Math.PI;
        public int bullet_x;
        public int bullet_y;
        public int angle;
        public int distance;
        public Image bulletImage;

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

        public void Move()
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
