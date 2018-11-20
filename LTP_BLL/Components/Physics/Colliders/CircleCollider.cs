using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class CircleCollider : Collider
    {
        public GameObject ParentGameObject;
        public int radius { get; private set; }
        public Vector2f position { get; private set; }

        public CircleCollider(GameObject _parentGo, int _radius)
        {
            ParentGameObject = _parentGo;
            radius = _radius;
            position = ParentGameObject.pos;
        }

        public void Push()
        {
            ParentGameObject.GetComponent<PhysicsBody>().Push();
        }

        public override void Update()
        {
            position = ParentGameObject.pos;

        }

        public override void CheckCollision(Collider c)
        {
            if (c is CircleCollider)
            {
                CheckCircleCollision(c as CircleCollider);
            }
        }

        private void CheckCircleCollision(CircleCollider circleCollider)
        {
            if(MathFunction.Distance(position, circleCollider.position) < (radius + circleCollider.radius))
            {
                ParentGameObject.GetComponent<CircleRenderer>().circle.FillColor = SFML.Graphics.Color.Blue;
            }
            else
            {
                ParentGameObject.GetComponent<CircleRenderer>().circle.FillColor = SFML.Graphics.Color.Black;
            }
            //Console.WriteLine(MathFunction.Distance(position,circleCollider.position));
        }
    }
}
