using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class CircleRenderer : GameObjectComponent
    {
        public CircleShape circle;
        public GameObject parentGameobject;

        public CircleRenderer(GameObject _parentGo, uint _radius, Color _color)
        {
            parentGameobject = _parentGo; ;

            circle = new CircleShape();
            circle.Origin = new Vector2f(_radius, _radius);
            circle.Radius = _radius;
            circle.Position = parentGameobject.pos;
            circle.FillColor = _color;
            circle.SetPointCount(16);
            Game.ObjectRenderer.AddRenderedObject(circle);
            
        }

        public override void Update()
        {
            circle.Position = parentGameobject.pos;
        }

    }
}
