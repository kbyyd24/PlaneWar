using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneWar
{
    /*
     * 游戏的入口
     */
    public partial class Game : Form
    {
        Background bg = new Background();

        public Game()
        {
            InitializeComponent();
            this.Size = new Size(420, 630);
            this.DoubleBuffered = true;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            bg.Move();
            Graphics g = this.CreateGraphics();
            bg.Draw(g);
        }
        /*
        public void Game_Paint(object sender, PaintEventArgs e)
        {
            bg.Draw(e.Graphics);
        }*/
    }
}
