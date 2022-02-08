using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
    public class Node : IDrawable
    {
        public readonly Point location;
        public readonly Size size;
        public readonly Color color;

        public Node(Point location, Size size, Color color)
        {
            this.location = location;
            this.size = size;
            this.color = color;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), location.X, location.Y, size.Width, size.Height);
        }
    }
}
