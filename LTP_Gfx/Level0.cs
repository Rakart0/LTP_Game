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
        }

    }
}
