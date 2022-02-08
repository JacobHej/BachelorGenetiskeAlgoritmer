using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
    public class Graph : IDrawable
    {
        public List<Node> Nodes = new List<Node>();
        public List<Edge> Edges = new List<Edge>();

        public void Draw(Graphics g)
        {
            Nodes.ForEach(node => node.Draw(g));
            Edges.ForEach(edge => edge.Draw(g));
        }
    }
}
