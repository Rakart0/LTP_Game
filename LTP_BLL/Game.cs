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
    public class Game
    {
        public uint WindowWidth { get; private set; }
        public uint WindowHeight { get; private set; }

        public RenderWindow gameWindown;
        public ObjectRenderer ObjectRenderer { get; private set; }
        public ObjectUpdater ObjectUpdater { get; private set; }
        private GameManager gameManager;


        //To delete :
        Text fps_Text;

        

        public Game(uint _w, uint _h, string _name, GameManager _gm)
        {
            this.WindowWidth = _w;
            this.WindowHeight = _h;
            this.gameManager = _gm;

            gameWindown = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), _name);
            gameWindown.Closed += new EventHandler(CloseGame);

            ObjectRenderer = new ObjectRenderer(gameWindown);
            ObjectUpdater = new ObjectUpdater();
          
            Time.InitTime();
            InitInfo();

        }

        private void InitInfo()
        {

            fps_Text = new Text();

            fps_Text.Font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf");
            fps_Text.Position = new Vector2f(10, 20);
            fps_Text.CharacterSize = 12;
            fps_Text.Color = Color.White;
            ObjectRenderer.AddRenderedObject(fps_Text);
        }

        public void GameLoop()
        {
          



            while (gameWindown.IsOpen)
            {
                gameWindown.DispatchEvents();

                Time.UpdateTime();
                fps_Text.DisplayedString = "Fps :" + (1 / Time.DeltaTime).ToString();

                gameWindown.Clear(new Color(49, 49, 49));
                ObjectUpdater.UpdateGameObjects();
                ObjectRenderer.UpdateGfx();

                gameWindown.Display();
            }
        }

        private void CloseGame(object sender, EventArgs e)
        {
            gameWindown.Close();
        }



    }
}

