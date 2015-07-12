using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace PlaneWar
{
    /*
     * 游戏类，进行游戏功能的调用
     * @author 高悦翔
     */
    class Game
    {
        Background background = new Background();
        Player player = new Player();
        List<Bullet> bulletList = new List<Bullet>();
        List<Enemy> enemyList = new List<Enemy>();
        List<EnemyBullet> ebList = new List<EnemyBullet>();
        SuperGun suGun = new SuperGun();
        BloodBox box = new BloodBox();
        Crasher crasher = new Crasher();
        Image gameOver = Resources.gameover;

        public void Move()
        {
            player.checkCoords();
            background.Move();
            player.MovePlane();
            ProduceBullet();
            ProduceEnemy();
            suGun.Move();
            box.Move();
            if (player.ChangeBlood(0))//玩家血量为0时，敌机不发射子弹
            {
                ProduceEnemyBullet();
            }
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (0 == rand.Next(500))
            {
                suGun.Exist = true;
            }
            if (0 == rand.Next(500))
            {
                box.Exist = true;
            }
        }

        public void Draw(Graphics e)
        {
            background.Draw(e);
            player.Draw(e);
            MoveEnemy(e);
            MoveBullet(e);
            MoveEnemyBullet(e);
            crasher.shootEnemy(e, bulletList, enemyList, player);
            crasher.shootPlayer(e, ebList, player);
            crasher.crashPlane(e, enemyList, player);
            crasher.getSuperGun(e, player, suGun);
            crasher.getBloodBox(e, player, box);
            if (!player.ChangeBlood(0))
            {
                e.DrawImage(gameOver, 5, 250);
            }
        }

        public void ProduceBullet()//玩家产生子弹
        {
            if (player.ChangeBlood(0))
            {
                if (Keyboard.IsKeyDown(Keys.J) || Keyboard.IsKeyDown(Keys.Space))
                {
                    suGun.checkTime(player);
                    if (!player.SuperGun)//是否获得霰弹枪
                    {
                        //当与前一个子弹距离达到一定值才会产生新子弹
                        if (0 == bulletList.Count)
                        {
                            bulletList.Add(new Bullet(player.PLANEX + 15, player.PLANEY - 10, 90, -20));
                        }
                        else
                        {
                            if (bulletList[bulletList.Count - 1].BulX == player.PLANEX + 15)
                            {
                                int i = player.PLANEY - 10 - bulletList[bulletList.Count - 1].BulY;
                                if (40 < i)
                                {
                                    bulletList.Add(new Bullet(player.PLANEX + 15, player.PLANEY - 10, 90, -20));
                                }
                            }
                            else
                            {
                                bulletList.Add(new Bullet(player.PLANEX + 15, player.PLANEY - 10, 90, -20));
                            }
                        }
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
        }

        public void MoveBullet(Graphics g)//画出并移动子弹
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(g);
                bulletList[i].Move();
                if (bulletList[i].BulY <= -10)
                {
                    bulletList.Remove(bulletList[i]);
                }
            }
        }

        public void ProduceEnemy()//随机产生敌机
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (0 == rand.Next(15))
            {
                int type = new Random(Guid.NewGuid().GetHashCode()).Next(3);
                enemyList.Add(new Enemy(type));
            }
        }

        public void MoveEnemy(Graphics g)//移动敌机
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

        public void ProduceEnemyBullet()//敌机产生子弹
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (0 == rand.Next(20))
                {
                    int x = enemyList[i].ENEMY_X + 20;
                    int y = enemyList[i].ENEMY_Y + 20;
                    int disX = x - (player.PLANEX + 20);
                    int disY = y - (player.PLANEY + 20);
                    EnemyBullet eb = new EnemyBullet(x, y, disX, disY);
                    ebList.Add(eb);
                }
            }
        }

        public void MoveEnemyBullet(Graphics g)//移动敌机子弹
        {
            for (int i = 0; i < ebList.Count; i++)
            {
                ebList[i].Draw(g);
                ebList[i].Move();
                if (630 < ebList[i].ebY || -10 > ebList[i].ebY)
                {
                    ebList.Remove(ebList[i]);
                }
                else if (-10 > ebList[i].ebX || 420 < ebList[i].ebX)
                {
                    ebList.Remove(ebList[i]);
                }
            }
        }
    }
}
