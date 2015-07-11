using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class Enemy
    {
        private int enemy_x;
        private int enmey_y = 0;
        private int blood;
        private int score;
        private Image plane;

        public int ENEMY_X
        {
            get
            {
                return enemy_x;
            }
        }
        public int ENEMY_Y
        {
            get
            {
                return enmey_y;
            }
        }
        public Image PLANE
        {
            get
            {
                return plane;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
        }
        public int Blood
        {
            get
            {
                return blood;
            }
            set
            {
                blood -= value;
            }
        }

        public Enemy(int type)
        {
            if (0 == type)
            {
                plane = Resources.fighterYellow;
                enemy_x = new Random(Guid.NewGuid().GetHashCode()).Next(330);
                blood = 1;
                score = 1;
            }
            else if (1 == type)
            {
                plane = Resources.fighterRed;
                enemy_x = new Random(Guid.NewGuid().GetHashCode()).Next(332);
                blood = 2;
                score = 2;
            }
            else if (2 == type)
            {
                plane = Resources.fighterGreen;
                enemy_x = new Random(Guid.NewGuid().GetHashCode()).Next(336);
                blood = 3;
                score = 3;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(plane, new Point(enemy_x, enmey_y));
        }

        public void Move()
        {
            enmey_y += 6 - score ;
        }

    }
}
