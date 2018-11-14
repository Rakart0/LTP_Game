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
        

        public GameObject(GameManager _gm, Vector2f _pos)
        {
            Components = new List<GameObjectComponent>();
            pos = _pos;
            _gm.game.ObjectUpdater.updtatableGO.Add(this);
        }
        public virtual void Update(float deltaTime)
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
