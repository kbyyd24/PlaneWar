using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    class Player
    {
        private Image myplane;
        private Image headImage;
        private int score = 0;
        private int blood = 100;
        private int plane_x = 181;
        private int plane_y = 500;
        private String name = "高悦翔";

        public Player()
        {
            myplane = Resources.plane;
            headImage = Resources.head;
        }

        public void MovePlane(int x, int y)
        {
            if (0 <= plane_x + x && 363 >= plane_x + x)
            {
                plane_x += x;
            }
            if (0 <= plane_y + y && 540 >= plane_y + y)
            {
                plane_y += y;
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
            //画出飞机和头像
            g.DrawImage(myplane, new Point(plane_x, plane_y));
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
