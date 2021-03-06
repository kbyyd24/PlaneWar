﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneWar
{
    /*
     * 键盘类，处理键盘事件
     * @author 高悦翔
     */
    class Keyboard
    {
        private static List<Keys> listKey = new List<Keys>();

        public static void KeyUp(Keys key)
        {
            listKey.Remove(key);
        }

        public static void KeyDown(Keys key)
        {
            if (!listKey.Contains(key))
            {
                listKey.Add(key);
            }
        }

        public static bool IsKeyDown(Keys key)
        {
            return listKey.Contains(key);
        }
    }
}
