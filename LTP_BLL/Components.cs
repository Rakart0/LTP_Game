using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    #region Rendering
    public class RectRenderer : GameObjectComponent
    {
        public RectangleShape rect;
        public GameObject ParentGo;

        public RectRenderer(GameObject _parentGo,Vector2f _size, Color _color, ObjectRenderer _objectRenderer)
        {
            ParentGo = _parentGo;
            rect = new RectangleShape();
            rect.Size = _size;
            rect.Position = ParentGo.pos;
            rect.FillColor = _color;
            _objectRenderer.AddRenderedObject(rect);
        }
        public override void Update()
        {
            rect.Position = ParentGo.pos;

        }
    }

    public class CircleRenderer : GameObjectComponent
    {
        public CircleShape circle;
        public GameObject ParentGo;
        
        public CircleRenderer(GameObject _parentGo, uint _radius, Color _color, ObjectRenderer _objectRenderer)
        {
            ParentGo = _parentGo;;
            
            circle = new CircleShape();
            circle.Radius = _radius;
            circle.Position = ParentGo.pos;
            circle.FillColor = _color;
            circle.SetPointCount(16);

            _objectRenderer.AddRenderedObject(circle);
        }

        public override void Update()
        {
            circle.Position = ParentGo.pos;
        }

    }
    #region poubelle
    //En fait c'était de la merde
    //public class QuickCircle : GameObjectComponent
    //{

    //    public GameObject ParentGO;
    //    int index;
    //    VertexArray va;

    //    public QuickCircle(GameObject _parentGo, uint _radius, int numberOfVerts, VertexArray _vertexArray, Color _c, int _index)
    //    {
    //        A FINIR OU PAS JE SAIS PAS TROP

    //        ParentGO = _parentGo;
    //        index = _index;

    //        int n = (numberOfVerts * 2);
    //        Vector2f[] checker = new Vector2f[n];
    //        int triangleCount = 0;

    //        for (int i = 0; i < n; i++)
    //        {
    //            if % 3 => mettre le vert au centre

    //            if ((float)i % 4f == 0f)
    //            {
    //                if (i != 0)
    //                {
    //                    triangleCount++;
    //                }
    //                checker[i] = new Vector2f(0, 0);
    //                _vertexArray.Append(new Vertex(ParentGO.pos, _c));

    //            }

    //            else
    //            {
    //                float angle = (i - (2 * triangleCount)) * (float)(Math.PI * 2) / numberOfVerts;

    //                float circleX = ParentGO.pos.X + _radius * (float)Math.Cos(angle);
    //                float circleY = ParentGO.pos.Y + _radius * (float)Math.Sin(angle);


    //                checker[i] = new Vector2f(circleX - ParentGO.pos.X, circleY - ParentGO.pos.Y);

    //                _vertexArray.Append(new Vertex(new Vector2f(circleX, circleY), _c));
    //            }


    //        }
    //    }

    //    public override void Update()
    //    {
    //        va.Draw(r, r, r)
    //    }
    //}
    #endregion
    #endregion

    #region Movement
    public class InputMoveable : GameObjectComponent
    {
        public GameObject ParentGo;
        private float speed;
        public InputMoveable(GameObject _parentGo, float _speed)
        {
            ParentGo = _parentGo;
            speed = _speed;
        }
        public override void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                ParentGo.pos.Y -= speed*Time.DeltaTime;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                ParentGo.pos.Y += speed * Time.DeltaTime;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                ParentGo.pos.X -= speed * Time.DeltaTime;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                ParentGo.pos.X += speed * Time.DeltaTime;
            }

        }
    }

    public class PhysicsBody : GameObjectComponent
    {
        public GameObject ParentGameObject;

        public Vector2f velocity;
        const float GRAVITY = 9.8f;
        public float friction = 0.75f;

        //En dur pour les test
        public float size;

        public PhysicsBody(GameObject _parentGo)
        {
            ParentGameObject = _parentGo;
            velocity.X = 0;
            velocity.Y = 0;
        }

        public override void Update()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                ParentGameObject.pos.Y = 300;
                velocity.Y = 0;
            }



            //Sale pour le moment
            if (ParentGameObject.pos.Y >= (600-(size*2)) && velocity.Y > 0)
            {
                velocity.Y *= - 0.5f;
            }
            else
            {
                velocity.Y += GRAVITY * Time.FixedTimeStep;

            }

 

            ParentGameObject.pos.X += velocity.X;
            ParentGameObject.pos.Y += velocity.Y;
            Console.WriteLine(velocity.Y.ToString());

        }

    }
    #endregion
}
