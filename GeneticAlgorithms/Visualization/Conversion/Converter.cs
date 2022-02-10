using Common;
using System.Drawing;

namespace Visualization.Conversion
{
    public class Converter
    {
        public static SimpleGraph ConvertToSimpleGraph(Graph g, Point center, int scale, int[] solution = null)
        {
            if (solution == null)
            {
                Random random = new Random();
                solution = Enumerable.Range(0, g.Verticies.Count).OrderBy(item => random.Next()).ToArray();
            }

            SimpleGraph graph = new SimpleGraph();
            double degreesPerIndex = 360.0 / g.Verticies.Count;
            int index = 0;

            // find first vertex
            Vertex vertex = g.Verticies[0];

            int x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * index) * scale);
            int Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * index) * scale);

            FilledCircle nodeFrom = new FilledCircle(
                new Point(x, Y),
                new Size(20, 20),
                Color.Blue);
            graph.Nodes.Add(nodeFrom);

            //traverse graph
            while (index++ < g.Verticies.Count)
            {
                Edge edge = vertex.Edges[0];
                vertex = g.Verticies[edge.Vertex];

                x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * solution[edge.Vertex]) * scale);
                Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * solution[edge.Vertex]) * scale);
                FilledCircle nodeTo = new FilledCircle(
                    new Point(x, Y),
                    new Size(10, 10),
                    Color.Red);
                graph.Nodes.Add(nodeTo);

                // Add edge from previous to new
                // ignoring weight
                graph.Edges.Add(new Line(nodeFrom, nodeTo, Color.Red));
                nodeFrom = nodeTo;
            }

            return graph;
        }
    }
}
