using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTP_BLL;
using SFML.Graphics;
using SFML.System;


namespace LTP_Gfx
{
    public class Level0 : Level
    {
        Vector2f startingPoint;
        WorldBounds w;
        public Level0(Vector2f _startingPoint) : base(_startingPoint)
        {
            startingPoint = _startingPoint;
            
        }

        public override void Initialize()
        {
            Console.WriteLine("Initializing");

            Random rnd = new Random();
            VertexArray va = new VertexArray(PrimitiveType.Quads);

             w = new WorldBounds(0, 800, 600, 0);
            Game.CollisionHandler.AddStaticCollider(w);
            Console.WriteLine("Added worldBounds");

            //Quickball q = new Quickball(new Vector2f(400, 300), 25, va, Color.Black, 0);
            Ball b = new Ball(new Vector2f(400, 300), Color.Black, 25, 0.75f);

            //int minBallSize = 10;
            //int maxBallSize = 20;

            //for (int i = 0; i < 100; i++)
            //{
            //    Vector2f r = new Vector2f(rnd.Next(0 + maxBallSize, 800 - maxBallSize), rnd.Next(50, 400));
            //    int rc = rnd.Next(0, 255);
            //    int rc2 = rnd.Next(0, 255);
            //    int rc3 = rnd.Next(0, 255);
            //    Color c = new Color((byte)rc, (byte)rc2, (byte)rc3);
            //    int rS = rnd.Next(minBallSize, maxBallSize);
            //    float rF = (float)rnd.Next(75, 90) / 100f;

            //    Quickball q = new Quickball(r, rS, va, c, i);
            //    //Ball b = new Ball(r, c, rS, rF);

            //}

            Game.ObjectRenderer.v = va;

            Player player = new Player();
          
        }

    }
}
