using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public static class Game
    {
        public static RenderWindow RenderWindow { get; private set; }
        public static GameWindow gameWindow { get; private set; }

        public static LevelManager LevelManager { get; private set; }


        public static PhysicsUpdater PhysicsUpdater { get; private set; }
        public static ObjectUpdater ObjectUpdater { get; private set; }
        public static ObjectRenderer ObjectRenderer { get; private set; }


        public static void CreateGame(uint _w, uint _h, string _n)
        {

            RenderWindow = new RenderWindow(new VideoMode(_w, _h), _n);
            ObjectUpdater = new ObjectUpdater();
            ObjectRenderer = new ObjectRenderer();
            PhysicsUpdater = new PhysicsUpdater();

            gameWindow = new GameWindow(_w, _h);
            LevelManager = new LevelManager();
        }

        public static void Update()
        {
            
         
            ObjectUpdater.UpdateGameObjects();
            ObjectRenderer.UpdateGfx();

        }

        public static void StartGame()
        {
            gameWindow.GameLoop();
        }

        public static void AddObjectToRenderQueue(Drawable d)
        {
            ObjectRenderer.AddRenderedObject(d);
        }

        public static void AddObjectToUpdateQueue(GameObject g)
        {
            ObjectUpdater.AddUpdatableObject(g);
        }

    }
}
