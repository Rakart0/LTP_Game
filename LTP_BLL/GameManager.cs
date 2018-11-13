using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class GameManager
    {
        Game game;
        LevelManager levelManager;
        ObjectRenderer objectRenderer;

        public void CreateGame(uint _w, uint _h, string _n)
        {
            game = new Game(_w, _h, _n, this);
            

            game.GameLoop();


        }

    }
}
