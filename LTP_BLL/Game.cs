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

        private float TimeElapsedThisPhysicFrame = 0f;
        private const float TARGETFPS = 60;
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


                float t = 0f;
            int numberOfFrameThisSecond = 0;
            while (gameWindown.IsOpen)
            {



                gameWindown.DispatchEvents();
                
                Time.UpdateTime();
                if (t >= 0.5f)
                {
                fps_Text.DisplayedString = "Fps :" + (numberOfFrameThisSecond / t).ToString();
                    physicsFPSText.DisplayedString = "Physics Fps :" + (1 / Time.FixedTimeStep).ToString();
                    t = 0f;
                    numberOfFrameThisSecond = 0;

                }
                else
                {
                    t += Time.DeltaTime;
                    numberOfFrameThisSecond++;
                }
                gameWindown.Clear(new Color(49, 49, 49));
                if (TimeElapsedThisPhysicFrame >= Time.FixedDeltaTime)
                {

                    Time.FixedTimeStep = TimeElapsedThisPhysicFrame;

                    PhysicsUpdater.UpdatePhysics();
                    TimeElapsedThisPhysicFrame = 0;
                }
                else
                {
                    TimeElapsedThisPhysicFrame += Time.DeltaTime;
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

