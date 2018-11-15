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

        public Player(GameManager _gm)
        {
            gameobject = new GameObject(_gm, new Vector2f(0, 300));
            
            RectRenderer rc = new RectRenderer(gameobject,new Vector2f(50, 50), new Color(224, 131, 38), _gm.objectRenderer);
            gameobject.AddComponent(rc);

            InputMoveable im = new InputMoveable(gameobject,300);
            gameobject.AddComponent(im);

        }
    }

    public class Ball
    {
        GameObject gameObject;

        public Ball(GameManager _gm, Vector2f pos, byte cR, byte cr2, byte cr3, int rS, float rF)
        {
            gameObject = new GameObject(_gm, pos);


            CircleRenderer c = new CircleRenderer(gameObject, (uint)rS, new Color(cR, cr2, cr3), _gm.objectRenderer);
            gameObject.AddComponent(c);

            PhysicsBody p = new PhysicsBody(gameObject);
            p.size = rS;
            p.friction = rF;
            _gm.PhysicsUpdater.PhysicsObjects.Add(p);

        }
    }

}
