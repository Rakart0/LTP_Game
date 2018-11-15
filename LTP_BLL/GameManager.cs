using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class GameManager
    {
        public Game game { get; private set; }
        public LevelManager LevelManager { get; private set; }
        public ObjectRenderer objectRenderer;
        public RenderWindow RenderWindow;
        public PhysicsUpdater PhysicsUpdater;

        public void CreateGame(uint _w, uint _h, string _n)
        {
            game = new Game(_w, _h, _n, this);
            LevelManager = new LevelManager(this);

            RenderWindow = game.gameWindown;
            objectRenderer = game.ObjectRenderer;
            PhysicsUpdater = game.PhysicsUpdater;
            


        }

        public void StartGame()
        {
            game.GameLoop();
        }

    }
}
