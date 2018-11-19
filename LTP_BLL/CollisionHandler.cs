using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    class CollisionHandler
    {
        //Actually a list of colliders
        List<Collider> DynamicColliders;
        List<Collider> StaticColliders;

        public void AddStaticCollider() //(Collider c)
        {
        }

        public void AddDynamicCollider()
        {
        }

        public void CheckCollisions()
        {
            //Check Dynamic against Statics
            foreach (Collider c in DynamicColliders)
            {
            }
            //Check Dynamic against Dynamic
            //Constructor for each type of collider
        }

    }
}
