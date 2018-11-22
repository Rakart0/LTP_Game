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

        private bool isPhysics;

        public bool IsPhysics

        {
            get { return isPhysics; }
            set { isPhysics = value; }
        }



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

        public T GetComponent<T>() where T : GameObjectComponent
        {
            foreach (GameObjectComponent c in Components)
            {
                if(c.GetType().Equals(typeof (T)))
                {
                    return (T)c;
                }
            }
            return null;
        }
        

    }
}
