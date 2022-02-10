using Common;
using System.Drawing;
using Visualization;

namespace Algorithms
{
    public class RandomWalk
    {
        private Graph graphToOptimize;
        public RandomWalk(Graph graph)
        {
            this.graphToOptimize = graph;
        }

        public Graph Evaluate()
        {
            Graph optimizedGraph = new Graph();

            // generate random walk
            Random random = new Random();
            int[] path = Enumerable.Range(0, graphToOptimize.Verticies.Count).OrderBy(item => random.Next()).ToArray();

            // Select first node
            int start = path[0];

            Vertex vertexFrom = graphToOptimize.Verticies[start];
            Vertex newVertexFrom = new Vertex();
            optimizedGraph.Verticies.Add(newVertexFrom);

            int indexPrev = start;

            // Create graph
            for (int i = 1; i < path.Count(); i++)
            {
                int index = path[i];

                // Add edge from previous to new
                // ignoring weight
                Edge edge = vertexFrom.Edges[index > indexPrev ? index - 1 : index];
                newVertexFrom.Edges.Add(edge);

                // Update previous node and vertex
                indexPrev = index;
                vertexFrom = graphToOptimize.Verticies[index];
                newVertexFrom = new Vertex();
                optimizedGraph.Verticies.Add(newVertexFrom);
            }

            // add edge back to first vertex
            newVertexFrom.Edges.Add(vertexFrom.Edges.FirstOrDefault(e => e.Vertex == start));
            var t = optimizedGraph.Verticies.Select(v => v.Edges[0].Vertex).Distinct();
            return optimizedGraph;
        }

        // worked before now broken so i save working verison
        private SimpleGraph WalkRandom(Graph graph, int scale)
        {
            Point center = new Point(scale, scale);
            double degreesPerIndex = 360.0 / graph.Verticies.Count;

            Point c = new Point(center.X + (int)Math.Sin(degreesPerIndex), center.Y + (int)Math.Cos(degreesPerIndex));

            SimpleGraph visualGraph = new SimpleGraph();

            // generate random walk
            Random random = new Random();
            IEnumerable<int> path = Enumerable.Range(0, graph.Verticies.Count).OrderBy(item => random.Next());

            // Select first node
            int start = path.First();
            int[] arrayPath = path.Skip(1).ToArray();

            Vertex vertexFrom = graph.Verticies[start];
            int x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * start) * scale);
            int Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * start) * scale);
            FilledCircle nodeFrom = new FilledCircle(
                new Point(x, Y),
                new Size(20, 20),
                Color.Blue);

            visualGraph.Nodes.Add(nodeFrom);

            // Create graph
            for (int i = 0; i < arrayPath.Count(); i++)
            {
                int index = arrayPath[i];

                // Create and add new node
                x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * index) * scale);
                Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * index) * scale);
                FilledCircle nodeTo = new FilledCircle(
                    new Point(x, Y),
                    new Size(10, 10),
                    Color.Red);
                visualGraph.Nodes.Add(nodeTo);

                visualGraph.Edges.Add(new Line(nodeFrom, nodeTo, Color.Red));

                vertexFrom = graph.Verticies[index];
                nodeFrom = nodeTo;
            }
            return visualGraph;
        }

    }
}