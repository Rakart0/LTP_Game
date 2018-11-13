using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    class Game
    {
        public uint WindowWidth { get; private set; }
        public uint WindowHeight { get; private set; }

        public static RenderWindow gameWindown;
        public ObjectRenderer objectRenderer { get; private set; }
        private GameManager gameManager;

        

        public Game(uint _w, uint _h, string _name, GameManager _gm)
        {
            this.WindowWidth = _w;
            this.WindowHeight = _h;
            this.gameManager = _gm;

            gameWindown = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), _name);
            gameWindown.Closed += new EventHandler(CloseGame);

            objectRenderer = new ObjectRenderer(gameWindown);
          
            Time.InitTime();

        }
        public void GameLoop()
        {
          



            while (gameWindown.IsOpen)
            {
                gameWindown.DispatchEvents();

                Time.UpdateTime();


                gameWindown.Clear(new Color(49, 49, 49));

                objectRenderer.UpdateGfx();

                gameWindown.Display();
            }
        }

        private void CloseGame(object sender, EventArgs e)
        {
            gameWindown.Close();
        }



    }
}

