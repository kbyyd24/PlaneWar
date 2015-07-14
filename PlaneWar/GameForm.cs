using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneWar
{
    /*
     * 游戏的入口
     * @author 高悦翔
     */
    public partial class GameForm : Form
    {
        Game game;//通过Game的对象处理游戏的事务
        private int flag = 0;
        serverConnecter conn;

        public GameForm()//构造函数，设置好窗口大小
        {
            InitializeComponent();
            this.Size = new Size(420, 630);
            this.DoubleBuffered = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            begin(true);
            rank.Visible = false;
        }

        public void timer1_Tick(object sender, EventArgs e)//timer驱动的方法，时间片到达时触发
        {
            if (1 == flag || 2 == flag)
            {
                game.Move();
                this.Invalidate();//默认调用OnPaint(PaintEventArgs e)方法，需要重载；添加事件后调用Game_Point()方法
            }
        }

        /* 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bg.Draw(e.Graphics);
            player.Draw(e.Graphics);
        }*/

        private void Game_Paint(object sender, PaintEventArgs e)//调用画图方法
        {
            if (1 == flag && null != game)
            {
                game.Draw(e.Graphics);
                if (!game.Blood)
                {
                    tName.Text = game.PName;
                    begin(true);
                    flag = 2;
                }
            }
            else if (2 == flag)
            {
                game.Draw(e.Graphics);
            }
        }
        private void Game_KeyUp(object sender, KeyEventArgs e)//释放按键
        {
            Keyboard.KeyUp(e.KeyCode);
            if (null != game)
            game.bulletFlag = true;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)//按下按键
        {
            Keyboard.KeyDown(e.KeyCode);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "C:\\Users\\悦翔\\Desktop\\Resources\\background.mp3";
            conn = new serverConnecter(tName.Text);
            conn.ReadXML();
        }
        
        private void beginGame_Click(object sender, EventArgs e)
        {
            game = new Game(tName.Text);
            flag = 1;
            begin(false);
        }

        private void begin(Boolean status)
        {
            beginGame.Visible = status;
            title.Visible = status;
            lName.Visible = status;
            tName.Visible = status;
            rank_button.Visible = status;
        }

        private void rank_button_Click(object sender, EventArgs e)
        {
            if (beginGame.Visible)
            {
                rank.Text = "";
                List<Players> players = conn.Res.players;
                for (int i = 0; i < players.Count; i++)
                {
                    rank.Text += players[i].rank + ":    " + players[i].userName + "\n        " + players[i].score + "\n";
                }
                begin(false);
                rank.Visible = true;
                back.Visible = true;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            rank.Visible = false;
            back.Visible = false;
            begin(true);
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ('p' == e.KeyChar || 'P' == e.KeyChar)
            {
                if (3 != flag)
                {
                    flag = 3;
                }
                else
                {
                    flag = 1;
                }
            }
        }
    }
}
