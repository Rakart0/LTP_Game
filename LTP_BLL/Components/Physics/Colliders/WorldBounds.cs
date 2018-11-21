using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class WorldBounds : Collider
    {
        int x1;
        int x2;
        int y1;
        int y2;
        

        public WorldBounds(int _x1, int _x2, int _y1, int _y2 )
        {
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
        }

        public override void CheckCollision(Collider c)
        {
            if (c is CircleCollider)
            {
                CheckCircleCollision(c as CircleCollider);
            }
        }

        public void CheckCircleCollision(CircleCollider c)
        {
            if (c.position.X - c.radius < x1)
            {
                c.ParentGameObject.pos.X = x1 + c.radius;

                if (c.ParentGameObject.GetComponent<PhysicsBody>() != null)
                {
                    c.PushX();
                }
            }
            else if (c.position.X + c.radius > x2)
            {
                c.ParentGameObject.pos.X = x2 - c.radius;

                if (c.ParentGameObject.GetComponent<PhysicsBody>() != null)
                {
                    c.PushX() ;
                }
            }

            if (c.position.Y + (c.radius) > y1)
            {
                c.ParentGameObject.pos.Y = y1 - c.radius;

                if (c.ParentGameObject.GetComponent<PhysicsBody>() != null)
                {
                    c.PushY();

                }
            }
            else if (c.position.Y - c.radius < y2)
            {
                c.ParentGameObject.pos.Y = y2 + c.radius;

                if (c.ParentGameObject.GetComponent<PhysicsBody>() != null)
                {
                    c.PushY();
                }
            }
        }

    }
}
