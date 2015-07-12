using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class SuperGun
    {
        private DateTime createTime;
        private int ts = 0;
        private Boolean exist;
        private int gunX;
        private int gunY = 0;
        private Image gun;

        public int GunX
        {
            get
            {
                return gunX;
            }
        }
        public int GunY
        {
            get
            {
                return gunY;
            }
            set
            {
                gunY = value;
            }
        }
        public Image Gun
        {
            get
            {
                return gun;
            }
        }
        public Boolean Exist
        {
            set
            {
                exist = value;
            }
        }

        public SuperGun()
        {
            gun = Resources.shotgun;
        }

        public void getGun()
        {
            createTime = System.DateTime.Now;
            resetX();
        }

        private void resetX()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            gunX = rand.Next(20, 340);
        }

        public void checkTime(Player player)
        {
            DateTime nowTime = System.DateTime.Now;
            ts = nowTime.Subtract(createTime).Seconds;
            if (10 < ts)
            {
                player.loseGun();
            }
        }

        public void Draw(Graphics g)
        {
            if (exist)
            {
                g.DrawImage(gun, new Point(gunX, gunY));
            }
        }

        public void Move()
        {
            if (exist)
            {
                gunY += 10;
                if (650 < gunY)
                {
                    gunY = 0;
                    exist = false;
                    resetX();
                }
            }
            else
            {
                gunY = 0; 
                resetX();
            }
        }
    }
}
