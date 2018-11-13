using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTP_BLL;

namespace LTP_Gfx
{
    class Program
    {
        static GameManager gm;
        
        static void Main(string[] args)
        {
            gm = new GameManager();
            gm.CreateGame(800, 600, "LTP Michael Harouchi");
        }
    }
}
