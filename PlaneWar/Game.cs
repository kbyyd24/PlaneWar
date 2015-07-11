using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneWar
{
    class Game
    {
        Background background = new Background();
        Player player = new Player();
        List<Bullet> bulletList = new List<Bullet>();
        List<Enemy> enemyList = new List<Enemy>();
        bool IsGetsGun = false;

        public void Move()
        {
            player.checkCoords();
            background.Move();
            player.MovePlane();
            ProduceBullet();
            ProduceEnemy();
        }

        public void Draw(Graphics e)
        {
            background.Draw(e);
            MoveEnemy(e);
            MoveBullet(e);
            player.Draw(e);
        }

        public void ProduceBullet()
        {
            if (Keyboard.IsKeyDown(Keys.J) || Keyboard.IsKeyDown(Keys.Space))
            {
                if (!IsGetsGun)
                {
                    bulletList.Add(new Bullet(player.PLANEX + 15, player.PLANEY - 10, 90, -20));
                }
                else
                {
                    bulletList.Add(new Bullet(player.PLANEX + 15, player.PLANEY - 10, 90, -20));
                    bulletList.Add(new Bullet(player.PLANEX + 6, player.PLANEY - 10, 60, -20));
                    bulletList.Add(new Bullet(player.PLANEX + 5, player.PLANEY - 10, -60, -20));
                    bulletList.Add(new Bullet(player.PLANEX + 5, player.PLANEY - 5, -30, -20));
                    bulletList.Add(new Bullet(player.PLANEX - 5, player.PLANEY - 5, 30, -20));
                }
            }
        }

        public void MoveBullet(Graphics g)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(g);
                bulletList[i].Move();
                if (bulletList[i].bullet_y <= -10)
                {
                    bulletList.Remove(bulletList[i]);
                }
            }
        }

        public void ProduceEnemy()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (0 == rand.Next(30))
            {
                int type = new Random(Guid.NewGuid().GetHashCode()).Next(3);
                enemyList.Add(new Enemy(type));
            }
        }

        public void MoveEnemy(Graphics g)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Draw(g);
                enemyList[i].Move();
                if (630 <= enemyList[i].ENEMY_Y)
                {
                    enemyList.Remove(enemyList[i]);
                }
            }
        }
    }
}
