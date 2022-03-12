using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
    public class Line : IDrawable
    {
        private FilledCircle node1;
        private FilledCircle node2;
        private Color color;

        public Line(FilledCircle node1, FilledCircle node2, Color color)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.color = color;
        }

        public void Draw(Graphics g)
        {
            Point point1 = new Point(node1.location.X + (node1.size.Height / 2), node1.location.Y + (node1.size.Width / 2));
            Point point2 = new Point(node2.location.X + (node2.size.Height / 2), node2.location.Y + (node2.size.Width / 2));
            g.DrawLine(new Pen(new SolidBrush(color),2), point1, point2);
        }
    }
}
