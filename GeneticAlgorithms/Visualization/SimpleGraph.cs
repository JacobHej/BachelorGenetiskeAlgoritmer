using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
    public class SimpleGraph : IDrawable
    {
        public List<FilledCircle> Nodes = new List<FilledCircle>();
        public List<Line> Edges = new List<Line>();

        public void Draw(Graphics g)
        {
            Nodes.ForEach(node => node.Draw(g));
            Edges.ForEach(edge => edge.Draw(g));
        }
    }
}
