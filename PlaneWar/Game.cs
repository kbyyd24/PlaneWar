using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PlaneWar
{
    class Game
    {
        Background background = new Background();
        Player player = new Player();
        List<Bullet> bulletList = new List<Bullet>();
        bool IsGetsGun = false;

        public void Move()
        {
            player.checkCoords();
            background.Move();
            player.MovePlane();
            ProdueBullet();
        }

        public void Draw(Graphics e)
        {
            background.Draw(e);
            player.Draw(e);
            MoveBullet(e);
        }

        public void ProdueBullet()
        {
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.J))
            {
                if (!IsGetsGun)
                {
                    bulletList.Add(new Bullet(player.PLANEX + 12, player.PLANEY - 10, 90, -20));
                }
            }
        }

        public void MoveBullet(Graphics g)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(g);
                bulletList[i].Move();
                if (bulletList[i].bullet_y < 0)
                {
                    bulletList.Remove(bulletList[i]);
                }
            }
        }
    }
}
