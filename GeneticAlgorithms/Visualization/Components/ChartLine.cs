using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization.Components
{
    public class ChartLine : IDrawable
    {
        private Color color;
        Point p1;
        Point p2;
        float width;
        public ChartLine(Point p1, Point p2, Color color, float width)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.color = color;
            this.width = width;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(new SolidBrush(color), width), p1, p2);
        }
    }
}
