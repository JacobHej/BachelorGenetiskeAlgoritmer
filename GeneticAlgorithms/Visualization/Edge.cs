using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
    public class Edge : IDrawable
    {
        private Node node1;
        private Node node2;

        public Edge(Node node1, Node node2)
        {
            this.node1 = node1;
            this.node2 = node2;
        }

        public void Draw(Graphics g)
        {
            Point point1 = new Point(node1.location.X + (node1.size.Height / 2), node1.location.Y + (node1.size.Width / 2));
            Point point2 = new Point(node2.location.X + (node2.size.Height / 2), node2.location.Y + (node2.size.Width / 2));
            g.DrawLine(Pens.Red, point1, point2);
        }
    }
}
