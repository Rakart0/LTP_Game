using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class PhysicsUpdater
    {
        public List<PhysicsBody> PhysicsObjects;
        public PhysicsUpdater()
        {
            PhysicsObjects = new List<PhysicsBody>();
        }

        public void UpdatePhysics()
        {
            foreach (PhysicsBody g in PhysicsObjects)
            {
                g.UpdatePhysics();
            }
        }

    }
}
