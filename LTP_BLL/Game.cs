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
        public PhysicsUpdater PhysicsUpdater;

        private float timeUntilNextUpdate = 0f;
        private const float TARGETFPS = 60;
        private float fixedTimeStep = 1 / TARGETFPS;
        //To delete :
        Text fps_Text;
        Text physicsFPSText;

        

        public Game(uint _w, uint _h, string _name, GameManager _gm)
        {
            this.WindowWidth = _w;
            this.WindowHeight = _h;
            this.gameManager = _gm;

            gameWindown = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), _name);
            gameWindown.Closed += new EventHandler(CloseGame);

            ObjectRenderer = new ObjectRenderer(gameWindown);
            ObjectUpdater = new ObjectUpdater();
            PhysicsUpdater = new PhysicsUpdater();

            Time.InitTime();
            InitInfo();

        }

        private void InitInfo()
        {

            fps_Text = new Text
            {
                Font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf"),
                Position = new Vector2f(10, 20),
                CharacterSize = 12,
                Color = Color.White
            };
            ObjectRenderer.AddRenderedObject(fps_Text);

            physicsFPSText = new Text
            {
                Font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf"),
                Position = new Vector2f(10, 40),
                CharacterSize = 12,
                Color = Color.White
            };
            ObjectRenderer.AddRenderedObject(physicsFPSText);


        }

        public void GameLoop()
        {
          
            //Essai game lock à 60fps


            while (gameWindown.IsOpen)
            {



                gameWindown.DispatchEvents();

                Time.UpdateTime();
                fps_Text.DisplayedString = "Fps :" + (1 / Time.DeltaTime).ToString();
                gameWindown.Clear(new Color(49, 49, 49));

                if (timeUntilNextUpdate >= fixedTimeStep)
                {
                    physicsFPSText.DisplayedString = "Physics Fps :" + (1 / timeUntilNextUpdate).ToString();

                    PhysicsUpdater.UpdatePhysics();
                    timeUntilNextUpdate = 0;
                }
                else
                {
                    timeUntilNextUpdate += Time.DeltaTime;
                }

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

