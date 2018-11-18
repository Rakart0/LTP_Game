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
        public GameObject parentGameObject;

        public RectRenderer(GameObject _parentGo, Vector2f _size, Color _color)
        {
            parentGameObject = _parentGo;
            rect = new RectangleShape();
            rect.Size = _size;
            rect.Position = parentGameObject.pos;
            rect.FillColor = _color;
            Game.ObjectRenderer.AddRenderedObject(rect);
        }
        public override void Update()
        {

            rect.Position = parentGameObject.pos;

        }
    }
}
