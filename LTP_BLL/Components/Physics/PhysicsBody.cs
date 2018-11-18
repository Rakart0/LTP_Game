using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{

    public class PhysicsBody : GameObjectComponent
    {
        public GameObject ParentGameObject;

        public Vector2f velocity;
        const float GRAVITY = 9.8f;
        public float friction = 0.75f;

        //En dur pour les test
        public float size;

        public PhysicsBody(GameObject _parentGo)
        {
            ParentGameObject = _parentGo;
            velocity.X = 0;
            velocity.Y = 0;

            Game.PhysicsUpdater.PhysicsObjects.Add(this);

        }

        public override void Update()
        {
            


            //Sale pour le moment
            if (ParentGameObject.pos.Y >= (600 - (size)))
            {
                velocity.Y = -velocity.Y * friction;
            }
            else
            {
            velocity.Y += GRAVITY * Time.FixedTimeStep;
            }



            ParentGameObject.pos.X += velocity.X;
            ParentGameObject.pos.Y += velocity.Y;

        }

    }
}
