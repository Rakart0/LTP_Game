using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    class CircleCollider : Collider
    {
        public GameObject ParentGameObject;
        public int radius { get; private set; }
        public Vector2f position { get; private set; }

        public void Push()
        {
            ParentGameObject.GetComponent<PhysicsBody>().Push();
        }

    }
}
