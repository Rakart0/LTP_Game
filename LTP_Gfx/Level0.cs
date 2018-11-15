using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTP_BLL;
using SFML.System;


namespace LTP_Gfx
{
    public class Level0 : Level
    {
        Vector2f startingPoint;

        public Level0(Vector2f _startingPoint) : base(_startingPoint)
        {
            startingPoint = _startingPoint;
            
        }

        public override void Initialize(GameManager _gm)
        {
            Player player = new Player(_gm);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Vector2f r = new Vector2f(rnd.Next(0, 750), rnd.Next(50, 400));
                int rc = rnd.Next(0, 255);
                int rc2 = rnd.Next(0, 255);
                int rc3 = rnd.Next(0, 255);
                int rS = rnd.Next(10, 30);
                float rF = (float) rnd.Next(75, 99) / 100f;
                Ball b = new Ball(_gm, r, (byte)rc, (byte)rc2,(byte)rc3, rS, rF);

            }
        }

    }
}
