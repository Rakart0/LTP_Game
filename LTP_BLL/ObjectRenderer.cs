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
        public VertexArray v;
        
        List<Drawable> RenderedObjects;
        public RenderWindow targetWindow;

        public ObjectRenderer()
        {
            targetWindow = Game.RenderWindow;
            RenderedObjects = new List<Drawable>();
        }

        public void UpdateGfx()
        {
            foreach (Drawable drawnObject in RenderedObjects)
            {
                targetWindow.Draw(drawnObject);
            }

            v.Draw(targetWindow, RenderStates.Default);
            v.Clear();
        }

        public void AddRenderedObject(Drawable d)
        {
            RenderedObjects.Add(d);
        }
    }
}
