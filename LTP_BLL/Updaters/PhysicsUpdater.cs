using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class PhysicsUpdater
    {
        public List<GameObjectComponent> PhysicsObjects;
        public PhysicsUpdater()
        {
            PhysicsObjects = new List<GameObjectComponent>();
        }

        public void UpdatePhysics()
        {
            foreach (GameObjectComponent g in PhysicsObjects)
            {
                g.Update();
            }
        }

    }
}
