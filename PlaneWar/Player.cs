using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneWar
{
    class Player
    {
        private Image myplane;
        private Image redplane;
        private Image notredplane;
        private Image headImage;
        private int score = 0;
        private int blood = 100;
        private int plane_x = 175;
        private int plane_y = 500;
        private String name = "高悦翔";

        public int PLANEX
        {
            get
            {
                return plane_x;
            }
            set
            {
                plane_x = value;
            }
        }

        public int PLANEY
        {
            get
            {
                return plane_y;
            }
            set
            {
                plane_y = value;
            }
        }

        public Player()
        {
            redplane = Resources.planeRedTail;
            notredplane = Resources.plane;
            myplane = notredplane;
            headImage = Resources.head;
        }

        public void checkCoords()
        {
            if (plane_x > 362)
            {
                plane_x = 362;
            }
        }

        public void MovePlane()
        {
            myplane = myplane == redplane ? notredplane : redplane;

            if (Keyboard.IsKeyDown(Keys.A) || Keyboard.IsKeyDown(Keys.Left))
            {
                myplane = Resources.planeLeft;
                plane_x -= 13;
                if (plane_x < 0)
                {
                    plane_x = 0;
                }
            }
            if (Keyboard.IsKeyDown(Keys.D) || Keyboard.IsKeyDown(Keys.Right))
            {
                myplane = Resources.planeRight;
                plane_x += 13;
                if (plane_x > 370)
                {
                    plane_x = 370;
                }
            }
            if (Keyboard.IsKeyDown(Keys.W) || Keyboard.IsKeyDown(Keys.Up))
            {
                plane_y -= 13;
                if (plane_y < 0)
                {
                    plane_y = 0;
                }
            }
            if (Keyboard.IsKeyDown(Keys.S) || Keyboard.IsKeyDown(Keys.Down))
            {
                plane_y += 13;
                if (plane_y > 535)
                {
                    plane_y = 535;
                }
            }
        }

        public Boolean ChangeBlood(int change)
        {
            Boolean flag = false;
            if (0 < blood + change && 100 >= blood + change)
            {
                blood += change;
                flag = true;
            }
            else if (0 >= blood + change)
            {
                blood = 0;
                flag = false;
            }
            else if (100 < blood + change)
            {
                blood = 100;
                flag = true;
            }
            return flag;
        }

        public void ChangeScore(int change)
        {
            if (0 <= score + change)
            {
                score += change;
            }
        }

        public void Draw(Graphics g)
        {
            //画出飞机
            if (blood > 0)
            {
                g.DrawImage(myplane, new Point(plane_x, plane_y));
            }
            else if (blood <= 0)
            {
                g.DrawImage(myplane, new Point(0, -500));
            }
            //画出头像
            g.DrawImage(headImage, new Point(10, 10));
            
            //画出并填充血量条
            g.DrawRectangle(new Pen(Color.Black, 1), 10, 90, 101, 10);
            g.FillRectangle(Brushes.Red, 11, 91, blood, 9);

            //画出完整血量条并填充
            g.DrawRectangle(new Pen(Color.Blue, 1), 10, 110, 101, 10);
            g.FillRectangle(Brushes.Green, 11, 111, 100, 9);

            //显示信息
            g.DrawString("Player: " + name, new Font("微软雅黑", 9, FontStyle.Bold), Brushes.Yellow, new Point(10, 130));
            g.DrawString("Score: " + score, new Font("微软雅黑", 9, FontStyle.Bold), Brushes.Yellow, new Point(10, 150));
        }
    }
}
