using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace LTP_BLL
{
    #region Rendering
  

 
 
    public class CircleBatch : GameObjectComponent
    {
        /// <summary>
        /// Create a circle that is vertex array compatible. Number of verts must be a multiple of 4.
        /// </summary>

        //Todo : Autoriser la modification des différents paramètres (couleur, size)

        public GameObject parentGameobject;
        public Vertex[] vertices { get; private set; }


        public int index;
        public VertexArray va;

        private Vector2f LastParentPos;
        private int actualNumberOfVerts;
        

        public CircleBatch(GameObject _parentGo, uint _radius, int numberOfVerts, VertexArray _vertexArray, Color _c, int _index)
        {
            va = _vertexArray;

            parentGameobject = _parentGo;
            LastParentPos = parentGameobject.pos;
            index = _index;

            actualNumberOfVerts = (numberOfVerts * 2);
            int triangleCount = 0;
            vertices = new Vertex[actualNumberOfVerts];

            for (int i = 0; i < actualNumberOfVerts; i++)
            {
                if ((float)i % 4f == 0f)
                {
                    if (i != 0)
                    {
                        triangleCount++;
                    }
                    vertices[i] = new Vertex(parentGameobject.pos, _c);
                    _vertexArray.Append(new Vertex(parentGameobject.pos, _c));

                }

                else
                {
                    float angle = (i - (2 * triangleCount)) * (float)(Math.PI * 2) / numberOfVerts;

                    float circleX = parentGameobject.pos.X + _radius * (float)Math.Cos(angle);
                    float circleY = parentGameobject.pos.Y + _radius * (float)Math.Sin(angle);



                    vertices[i] = new Vertex(new Vector2f(circleX, circleY), _c);
                    _vertexArray.Append(new Vertex(new Vector2f(circleX, circleY), _c));
                    
                }


            }
        }

        public override void Update()
        {           
            float newX = LastParentPos.X - parentGameobject.pos.X;
            float newY = LastParentPos.Y - parentGameobject.pos.Y;
    

            for (int i = 0; i < actualNumberOfVerts; i++)
                {
                int t = i + (actualNumberOfVerts * index);
                vertices[i].Position.X -= newX;
                vertices[i].Position.Y -= newY;
                va.Append(vertices[i]);
                }

            LastParentPos = parentGameobject.pos;
            }

        }
    
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

            //Console.WriteLine(ParentGo.pos);

        }
    }

    #endregion
}
