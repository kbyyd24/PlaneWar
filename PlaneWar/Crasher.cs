using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class Crasher
    {
        public void shootEnemy(Graphics g, List<Bullet> bulletList, List<Enemy> enemyList, Player player)//击中敌机
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                //创建子弹的矩形变量
                Rectangle bues = new Rectangle(bulletList[i].BulX, bulletList[i].BulY, bulletList[i].BulletImage.Width, bulletList[i].BulletImage.Height);
                for (int j = 0; j < enemyList.Count; j++)
                {
                    //创建敌机矩形变量
                    Rectangle emes = new Rectangle(enemyList[j].ENEMY_X, enemyList[j].ENEMY_Y, enemyList[j].PLANE.Width, enemyList[j].PLANE.Height);
                    if (emes.IntersectsWith(bues))//敌机碰撞测试
                    {
                        bulletList.Remove(bulletList[i]);
                        if (1 == enemyList[j].Blood)//判断敌机血量是否会减为0
                        {
                            player.ChangeScore(enemyList[j].Score);
                            Bomb bomb = new Bomb(enemyList[j].ENEMY_X, enemyList[j].ENEMY_Y);
                            enemyList.Remove(enemyList[j]);
                            bomb.Draw(g);//画出爆炸效果
                            bomb.bombplay();//音效效果
                        }
                        else
                        {
                            enemyList[j].Blood = enemyList[j].Blood - 1;
                        }
                    }
                }
            }
        }

        public void shootPlayer(Graphics g, List<EnemyBullet> ebList, Player player)//被击中
        {
            Rectangle playRec = new Rectangle(player.PLANEX, player.PLANEY, player.Myplane.Width, player.Myplane.Height);
            for (int i = 0; i < ebList.Count; i++)
            {
                Rectangle ebRec = new Rectangle(ebList[i].ebX, ebList[i].ebY, ebList[i].EBimage.Width, ebList[i].EBimage.Height);
                if (ebRec.IntersectsWith(playRec))
                {
                    ebList.Remove(ebList[i]);
                    player.ChangeBlood(-5);
                    if (!player.ChangeBlood(0))//判断玩家血量
                    {
                        Bomb bomb = new Bomb(player.PLANEX, player.PLANEY);
                        bomb.Draw(g);
                        bomb.bombplay();
                    }
                }
            }
        }

        public void crashPlane(Graphics g, List<Enemy> enemyList, Player player)//玩家与敌机碰撞
        {
            Rectangle playRec = new Rectangle(player.PLANEX, player.PLANEY, player.Myplane.Width, player.Myplane.Height);
            for (int i = 0; i < enemyList.Count; i++)
            {
                Rectangle ebRec = new Rectangle(enemyList[i].ENEMY_X, enemyList[i].ENEMY_Y, enemyList[i].PLANE.Width, enemyList[i].PLANE.Height);
                if (ebRec.IntersectsWith(playRec))
                {
                    Bomb bomb = new Bomb(enemyList[i].ENEMY_X, enemyList[i].ENEMY_Y);
                    enemyList.Remove(enemyList[i]);
                    bomb.Draw(g);
                    bomb.bombplay();
                    player.ChangeBlood(-10);
                    if (!player.ChangeBlood(0))
                    {
                        Bomb bomb2 = new Bomb(player.PLANEX, player.PLANEY);
                        bomb2.Draw(g);
                        bomb2.bombplay();
                    }
                }
            }
        }

        public void getSuperGun(Graphics g, Player player, SuperGun gun)
        {
            Rectangle plaRec = new Rectangle(player.PLANEX, player.PLANEY, player.Myplane.Width, player.Myplane.Height);
            Rectangle gunRec = new Rectangle(gun.GunX, gun.GunY, gun.Gun.Width, gun.Gun.Height);
            if (gunRec.IntersectsWith(plaRec))
            {
                player.getSuperGun();
                gun.getGun();
                gun.Exist = false;
            }
            else
            {
                gun.Draw(g);
            }
        }

        public void getBloodBox(Graphics g, Player player, BloodBox box)
        {
            Rectangle plaRec = new Rectangle(player.PLANEX, player.PLANEY, player.Myplane.Width, player.Myplane.Height);
            Rectangle boxRec = new Rectangle(box.BoxX, box.BoxY, box.Box.Width, box.Box.Height);
            if (boxRec.IntersectsWith(plaRec) && player.ChangeBlood(0) && box.Exist)
            {
                player.ChangeBlood(20);
                box.getBox();
                box.Exist = false;
            }
            else
            {
                box.Draw(g);
            }
        }
    }
}
