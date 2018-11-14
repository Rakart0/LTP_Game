using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace LTP_BLL
{
    public class ObjectRenderer
    {
        List<Drawable> RenderedObjects;
        public RenderWindow targetWindow;

        public ObjectRenderer(RenderWindow _targetWindow)
        {
            targetWindow = _targetWindow;
            RenderedObjects = new List<Drawable>();
        }

        public void UpdateGfx()
        {
            foreach (Drawable drawnObject in RenderedObjects)
            {
                targetWindow.Draw(drawnObject);
            }
        }

        public void AddRenderedObject(Drawable d)
        {
            RenderedObjects.Add(d);
        }
    }
}
