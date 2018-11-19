using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    class WorldBounds : Collider
    {
        int x1;
        int x2;
        int y1;
        int y2;

        public GameObject ParentGameObject;

        public WorldBounds(int _x1, int _x2, int _y1, int _y2, GameObject _parentGameObject)
        {
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
            ParentGameObject = _parentGameObject;
        }
        
        public override void CheckCollision(CircleCollider c)
        {
            if (c.position.X < x1)
            { }
            else if (c.position.X > x2)
            { }
            else if (c.position.Y + c.radius > y1)
            { c.Push(); }
            else if (c.position.Y - c.radius < y2)
            { c.Push(); }
        }

    }
}
