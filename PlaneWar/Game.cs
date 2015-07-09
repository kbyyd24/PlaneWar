using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlaneWar
{
    /*
     * 游戏的入口
     */
    public partial class Game : Form
    {
        Background bg = new Background();
        Player player = new Player();
        Boolean[] OnKey = new Boolean[4];

        public Game()
        {
            InitializeComponent();
            this.Size = new Size(420, 630);
            this.DoubleBuffered = true;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            bg.Move();
            this.Invalidate();//默认调用OnPaint(PaintEventArgs e)方法，需要重载；添加事件后调用Game_Point()方法
        }

        /* 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bg.Draw(e.Graphics);
            player.Draw(e.Graphics);
        }*/

        private void Game_KeyUp(object sender, KeyEventArgs e)//释放按键
        {
            Keys key = e.KeyCode;
            if (Keys.A == key || Keys.Left == key)
            {
                OnKey[0] = false;
            }
            else if (Keys.W == key || Keys.Up == key)
            {
                OnKey[1] = false;
            }
            else if (Keys.S == key || Keys.Down == key)
            {
                OnKey[2] = false;
            }
            else if (Keys.D == key || Keys.Right == key)
            {
                OnKey[3] = false;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)//按下按键
        {
            Keys key = e.KeyCode;
            if (Keys.A == key || Keys.Left == key)
            {
                OnKey[0] = true;
            }
            else if (Keys.W == key || Keys.Up == key)
            {
                OnKey[1] = true;
            }
            else if (Keys.S == key || Keys.Down == key)
            {
                OnKey[2] = true;
            }
            else if (Keys.D == key || Keys.Right == key)
            {
                OnKey[3] = true;
            }
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            if (OnKey[0])
            {
                player.MovePlane(-2, 0);
            }
            if (OnKey[1])
            {
                player.MovePlane(0, -2);
            }
            if (OnKey[2])
            {
                player.MovePlane(0, 2);
            }
            if (OnKey[3])
            {
                player.MovePlane(2, 0);
            }
            bg.Draw(e.Graphics);
            player.Draw(e.Graphics);
        }
    }
}
