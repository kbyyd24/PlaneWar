using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class EnemyBullet
    {
        private int ebx;
        private int eby;
        private int movex;
        private int movey;
        private Image ebImage;

        public int ebX
        {
            get
            {
                return ebx;
            }
        }

        public int ebY
        {
            get
            {
                return eby;
            }
        }

        public EnemyBullet(int x, int y, int disX, int disY)
        {
            ebx = x;
            eby = y;
            ebImage = Resources.en_bul01;
            if (0 != disY)
            {
                double a = Math.Sqrt((disY) * (disY) + (disX) * (disX));
                movey = -(int)((disY) * 6 / a);
                movex = -(int)((disX) * 6 / a);
            }
            else
            {
                movey = 0;
                movex = 6;
            }

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(ebImage, new Point(ebx, eby));
        }

        public void Move()
        {
            ebx += movex;
            eby += movey;
        }
    }
}
