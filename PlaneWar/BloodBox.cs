using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class BloodBox
    {
        private Boolean exist;
        private int boxX;
        private int boxY = 0;
        private Image box;

        public int BoxX
        {
            get
            {
                return boxX;
            }
        }
        public int BoxY
        {
            get
            {
                return boxY;
            }
        }
        public Image Box
        {
            get
            {
                return box;
            }
        }
        public Boolean Exist
        {
            get
            {
                return exist;
            }
            set
            {
                exist = value;
            }
        }

        public BloodBox()
        {
            box = Resources.bloodbox;
        }

        private void resetX()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            boxX = rand.Next(20, 340);
        }

        public void getBox()
        {
            resetX();
        }

        public void Draw(Graphics g)
        {
            if (exist)
            {
                g.DrawImage(box, new Point(boxX, boxY));
            }
        }

        public void Move()
        {
            if (exist)
            {
                boxY += 10;
                if (650 < boxY)
                {
                    boxY = 0;
                    exist = false;
                    resetX();
                }
            }
            else
            {
                boxY = 0;
                resetX();
            }
        }
    }
}
