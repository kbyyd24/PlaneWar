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
    public partial class GameForm : Form
    {
        Game game = new Game();

        public GameForm()
        {
            InitializeComponent();
            this.Size = new Size(420, 630);
            this.DoubleBuffered = true;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            game.Move();
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
            Keyboard.KeyUp(e.KeyCode);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)//按下按键
        {
            Keyboard.KeyDown(e.KeyCode);
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }
    }
}
