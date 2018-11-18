using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class ObjectUpdater
    {
        private List<GameObject> updtatableGO;

        public ObjectUpdater()
        {
            updtatableGO = new List<GameObject>();
        }

        public void UpdateGameObjects()
        {
            foreach (GameObject go in updtatableGO)
            {
                go.Update();
            }
        }

        public void AddUpdatableObject(GameObject g)
        {
            updtatableGO.Add(g);
        }

    }
}
