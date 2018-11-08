using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPT_Game_BLL
{
    public class World
    {
        public World(int _width, int _height)
        {
            Width = _width;
            Height = _height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string WorldID { get; private set; }
    }
}
