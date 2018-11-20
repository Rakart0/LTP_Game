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
    public class GameWindow
    {
        public uint WindowWidth { get; private set; }
        public uint WindowHeight { get; private set; }
        
        PhysicsUpdater PhysicsUpdater;

        private float TimeElapsedThisPhysicFrame = 0f;
        private const float TARGETFPS = 60;
        //To delete :
        Text fps_Text;
        Text physicsFPSText;

        RenderWindow renderWindow;

        

        public GameWindow(uint _w, uint _h)
        {
            WindowWidth = _w;
            WindowHeight = _h;

            renderWindow = Game.RenderWindow;
            PhysicsUpdater = Game.PhysicsUpdater;
            Time.InitTime();
            InitInfo();

            renderWindow.Closed += new EventHandler(CloseGame);

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
            Game.AddObjectToRenderQueue(fps_Text);

            physicsFPSText = new Text
            {
                Font = new Font(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "/arial.ttf"),
                Position = new Vector2f(10, 40),
                CharacterSize = 12,
                Color = Color.White
            };
            Game.AddObjectToRenderQueue(physicsFPSText);


        }

        public void GameLoop()
        {
          
            //Essai game lock à 60fps


                float t = 0f;
            int numberOfFrameThisSecond = 0;
            while (renderWindow.IsOpen)
            {



                renderWindow.DispatchEvents();
                
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
                renderWindow.Clear(new Color(49, 49, 49));
                if (TimeElapsedThisPhysicFrame >= Time.FixedDeltaTime)
                {

                    Time.FixedTimeStep = TimeElapsedThisPhysicFrame;
                    Game.CollisionHandler.CheckCollisions();

                    PhysicsUpdater.UpdatePhysics();
                    TimeElapsedThisPhysicFrame = 0;
                }
                else
                {
                    TimeElapsedThisPhysicFrame += Time.DeltaTime;
                }

                Game.Update();

                renderWindow.Display();

            }
        }

        private void CloseGame(object sender, EventArgs e)
        {
            renderWindow.Close();
        }



    }
}

