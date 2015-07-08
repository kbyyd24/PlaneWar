using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneWar
{
    /*
     * 背景类，处理背景相关事件
     * param :
     * @ backgrounds : 背景图数组
     * @ Index : 随机数
     * @ pix_x, pix_y : 背景图起始坐标
     * @ imageHeight : 设置图片距离
     * @ planeOffset : 背景图偏移时间
     */
    public class Background
    {
        private Image[] backgrounds;
        private int Index;
        private int pix_x = 0;
        private int pix_y = 0;
        private const int imageHeight = 835;
        private const int planeOffset = 2;

        public int PIX_X
        {
            get
            {
                return pix_x;
            }
            set
            {
                pix_x = value;
            }
        }

        public int PIX_Y
        {
            get
            {
                return pix_y;
            }
            set
            {
                pix_y = value;
            }
        }

        public int INDEX
        {
            get
            {
                return Index;
            }
            set
            {
                Index = value;
            }
        }

        /*
         * 构造函数
         * 将背景图赋值给 backgrounds 属性
         * 给 Index 赋随机数
         */
        public Background()
        {
            backgrounds = new Image[4];
            Index = new Random().Next(0,4);

            backgrounds[0] = Resources.background1;
            backgrounds[1] = Resources.background2;
            backgrounds[2] = Resources.background3;
            backgrounds[3] = Resources.background4;
        }

        /*
         * 画出背景图
         */
        public void Draw(Graphics e)
        {
            e.DrawImage(backgrounds[Index], new Point(pix_x, pix_y - imageHeight));
            e.DrawImage(backgrounds[Index], new Point(pix_x, pix_y));
        }

        /*
         * 修改 y 坐标
         */
        public void Move()
        {
            pix_y += planeOffset;
            if (pix_y > imageHeight)
            {
                pix_y = 0;
            }
        }
    }
}
