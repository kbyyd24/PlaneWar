using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PlaneWar
{
    class Game
    {
        Background background = new Background();
        Player player = new Player();

        public void Move()
        {
            player.checkCoords();
            background.Move();
            player.MovePlane();
        }

        public void Draw(Graphics e)
        {
            background.Draw(e);
            player.Draw(e);
        }
    }
}
