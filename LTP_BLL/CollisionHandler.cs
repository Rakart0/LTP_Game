using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class CollisionHandler
    {
        //Actually a list of colliders
        List<Collider> DynamicColliders;
        List<Collider> StaticColliders;

        public CollisionHandler()
        {
            DynamicColliders = new List<Collider>();
            StaticColliders = new List<Collider>();
        }

        public void AddStaticCollider(Collider c) //(Collider c)
        {
            StaticColliders.Add(c);
        }

        public void AddDynamicCollider(Collider c)
        {
            DynamicColliders.Add(c);
        }

        public void CheckCollisions()
        {
            //Check Dynamic against Statics

            foreach (Collider staticCollider in StaticColliders)
            {

                foreach (Collider c in DynamicColliders)
                {
                    //Type cType = c.GetType();
                    //Type.GetType(c)
                    staticCollider.CheckCollision(c);
                }
            }

            for (int i = 0; i < DynamicColliders.Count; i++)
            {
                for (int j = 0; j < DynamicColliders.Count; j++)
                {
                    if (i != j)
                    {
                        DynamicColliders[i].CheckCollision(DynamicColliders[j]);
                    }
                }
            }

            //Check Dynamic against Dynamic
            //Constructor for each type of collider
        }

    }
}
