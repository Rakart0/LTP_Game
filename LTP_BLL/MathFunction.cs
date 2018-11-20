using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public static class MathFunction
    {
        public static float Distance(Vector2f a, Vector2f b)
        {
            float t1 = (float)Math.Pow((a.X - b.X), 2);
            float t2 = (float)Math.Pow((a.Y - b.Y), 2);
            float t3 = t1 + t2;
           
            float test = (float)Math.Sqrt(t3);

          
            return test;
            
        }

    }
}
