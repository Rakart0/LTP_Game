using SFML.Graphics;
using SFML.System;
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
        public Vector2f pos;
        

        public GameObject(Vector2f _pos)
        {
            Components = new List<GameObjectComponent>();
            pos = _pos;
            Game.AddObjectToUpdateQueue(this);
        }
        public virtual void Update()
        {
            foreach (GameObjectComponent c in Components)
            {
                c.Update();
            }
        }

        public void AddComponent(GameObjectComponent c)
        {
            Components.Add(c);
        }
        

    }
}
