using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class Level
    {
        public Vector2f StartingPoint { get; private set; }

        public Level(Vector2f _startingPoint)
        {
            StartingPoint = _startingPoint;
        }


        public virtual void Initialize()
        {

        }

    }
}
