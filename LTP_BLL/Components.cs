using SFML.Graphics;
using SFML.System;
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

        public RectRenderer(Vector2f _size, Vector2f _pos, Color _color, ObjectRenderer _objectRenderer)
        {
            rect = new RectangleShape();
            rect.Size = _size;
            rect.Position = _pos;
            rect.FillColor = _color;
            _objectRenderer.AddRenderedObject(rect);
        }
        public override void Update(float deltaTime)
        {
        }
    }
}
