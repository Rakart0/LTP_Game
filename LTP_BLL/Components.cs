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
        public override void Update(float deltaTime)
        {
            rect.Position = ParentGo.pos;

        }
    }

    public class InputMoveable : GameObjectComponent
    {
        public GameObject ParentGo;
        private float speed;
        public InputMoveable(GameObject _parentGo, float _speed)
        {
            ParentGo = _parentGo;
            speed = _speed;
        }
        public override void Update(float deltaTime)
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
}
