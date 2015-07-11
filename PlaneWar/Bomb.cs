using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class Bomb
    {
        //SoundPlayer sp = new SoundPlayer();
        private Image[] bombImage;
        private Point loc;

        public Point Loc
        {
            get
            {
                return loc;
            }
        }

        public Bomb(int x, int y)
        {
            loc = new Point(x, y);
            bombImage = new Image[6];
            bombImage[0] = Resources.bomb0;
            bombImage[1] = Resources.bomb1;
            bombImage[2] = Resources.bomb2;
            bombImage[3] = Resources.bomb3;
            bombImage[4] = Resources.bomb4;
            bombImage[5] = Resources.bomb5;
            //sp.Stream = Resoutces.bombsound;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bombImage[0], loc);
            g.DrawImage(bombImage[1], loc);
            g.DrawImage(bombImage[2], loc);
            g.DrawImage(bombImage[3], loc);
            g.DrawImage(bombImage[4], loc);
            g.DrawImage(bombImage[5], loc);
        }

        public void bombplay()
        {
            //sp.Play();
        }

    }
}
