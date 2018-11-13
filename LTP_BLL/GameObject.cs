using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class GameObject
    {
        public List<GameObjectComponent> Components { get; private set; }

        public GameObject()
        {
            Components = new List<GameObjectComponent>();
        }
        public void Update(float deltaTime)
        {
            foreach (GameObjectComponent c in Components)
            {
                c.Update(deltaTime);
            }
        }

        public void AddComponent(GameObjectComponent c)
        {
            Components.Add(c);
        }
        

    }
}
