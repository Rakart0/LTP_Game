using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class ObjectUpdater
    {
        public List<GameObject> updtatableGO;

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

    }
}
