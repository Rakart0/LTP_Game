using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTP_BLL;
using SFML.Graphics;
using SFML.System;

namespace LTP_Gfx
{
    public class Player
    {

        GameObject gameobject;

        public Player()
        {
            gameobject = new GameObject(new Vector2f(0, 300));

            //RectRenderer rc = new RectRenderer(gameobject, new Vector2f(50, 50), new Color(224, 131, 38));
            //gameobject.AddComponent(rc);

            CircleRenderer c = new CircleRenderer(gameobject, 25, new Color(224, 131, 38));
            gameobject.AddComponent(c);

            PhysicsBody p = new PhysicsBody(gameobject);
            p.friction = 0.5f;
            gameobject.AddComponent(p);

            InputMoveable im = new InputMoveable(gameobject, 50000);
            gameobject.AddComponent(im);

            CircleCollider circleCollider = new CircleCollider(gameobject, 25);
            gameobject.AddComponent(circleCollider);
            Game.CollisionHandler.AddDynamicCollider(circleCollider);
        }
    }
    
public class Ball
    {
        GameObject gameObject;

        public Ball(Vector2f pos, Color _color, int _size, float _friction)
        {
            gameObject = new GameObject(pos);


            CircleRenderer c = new CircleRenderer(gameObject, (uint)_size, _color);
            gameObject.AddComponent(c);

            PhysicsBody p = new PhysicsBody(gameObject);
            //p.size = _size;
            p.friction = _friction;
            gameObject.AddComponent(p);


            CircleCollider circleCollider = new CircleCollider(gameObject, _size);
            gameObject.AddComponent(circleCollider);
            Game.CollisionHandler.AddDynamicCollider(circleCollider);

        }
    }


    public class SimpleBall
    {
        GameObject gameObject;

        public SimpleBall(Vector2f _pos, Color _color, int _size)
        {
            gameObject = new GameObject(_pos);


            CircleRenderer c = new CircleRenderer(gameObject, (uint)_size, _color);
            gameObject.AddComponent(c);
            

        }
    }



    public class Quickball
    {
        GameObject go;

        public Quickball(Vector2f _pos, int r, VertexArray va, Color _c, int index)
        {
            go = new GameObject( _pos);

            CircleBatch c = new CircleBatch(go,(uint)r,16, va, _c, index);
            go.AddComponent(c);


            PhysicsBody p = new PhysicsBody(go);
            //p.size = r;
            p.friction = 0.75f;
            go.AddComponent(p);

            CircleCollider circleCollider = new CircleCollider(go, r);
            go.AddComponent(circleCollider);
            Game.CollisionHandler.AddDynamicCollider(circleCollider);


        }

    }
   

}
