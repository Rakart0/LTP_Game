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

        public void PushY()
        {
            ParentGameObject.GetComponent<PhysicsBody>().PushY();
        }
        public void PushX()
        {
            ParentGameObject.GetComponent<PhysicsBody>().PushX();
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
            float DistanceBetweenCircles = MathFunction.Distance(position, circleCollider.position);
            float SumOfRadiuses = radius + circleCollider.radius;

            Vector2f v = new Vector2f((position.X - circleCollider.position.X), (position.Y - circleCollider.position.Y));

            if (DistanceBetweenCircles < SumOfRadiuses)
            {
                //ParentGameObject.GetComponent<CircleRenderer>().circle.FillColor = SFML.Graphics.Color.Blue;
                Vector2f normalized = MathFunction.NormalizeVector(v);

                //ICI CA BUG HOLA OHE

                circleCollider.gameObject.pos = new Vector2f(normalized.X * SumOfRadiuses, normalized.Y * SumOfRadiuses);
                

                ////Cétébien
                //ParentGameObject.GetComponent<PhysicsBody>().velocity.X += circleCollider.ParentGameObject.GetComponent<PhysicsBody>().velocity.X;
                //ParentGameObject.GetComponent<PhysicsBody>().velocity.Y += circleCollider.ParentGameObject.GetComponent<PhysicsBody>().velocity.Y;

                //circleCollider.ParentGameObject.GetComponent<PhysicsBody>().velocity.X += ParentGameObject.GetComponent<PhysicsBody>().velocity.X;
                //circleCollider.ParentGameObject.GetComponent<PhysicsBody>().velocity.Y += ParentGameObject.GetComponent<PhysicsBody>().velocity.Y;

            }
            else
            {
               // ParentGameObject.GetComponent<CircleRenderer>().circle.FillColor = SFML.Graphics.Color.Black;
            }

            //Console.WriteLine(MathFunction.Distance(position,circleCollider.position));
        }
    }
}
