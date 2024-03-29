﻿using Common;
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

        public static SimpleGraph CoordinateGraphToSimpleGraph(CoordinateGraph g, int scale, int[] solution = null)
        {
            float minX = g.Verticies[0].X, minY = g.Verticies[0].Y, maxX = g.Verticies[0].X, maxY = g.Verticies[0].Y;
            PointF p;
            //Calculate width and height of Coordinate graph;
            for (int i = 1; i<g.Verticies.Length; i++)
            {
                p = g.Verticies[i];
                minX = Math.Min(minX, p.X);
                maxX = Math.Max(maxX, p.X);
                minY = Math.Min(minY, p.Y);
                maxY = Math.Max(maxY, p.Y);
            }

            float width = maxX - minX;
            float height = maxY - minY;

            SimpleGraph graph = new SimpleGraph();
            int x;
            int y;

            if (solution == null)
            {
                for (int i = 0; i < g.Verticies.Length; i++)
                {
                    p = g.Verticies[i];
                    x = (int)Math.Round((p.X - minX) * scale / width);
                    y = (int)Math.Round((p.Y - minY) * scale / height);
                    FilledCircle node = new FilledCircle(
                        new Point(x, y),
                        new Size(10, 10),
                        Color.Gray);
                    graph.Nodes.Add(node);
                }
                return graph;
            }

            //Calculate the first node on the solution tour
            int index = solution[0];
            p = g.Verticies[index];
            x = (int)Math.Round((p.X-minX) * scale / width);
            y = (int)Math.Round((p.Y-minY) * scale / height);
            FilledCircle nodeFrom = new FilledCircle(
                new Point(x, y),
                new Size(10, 10),
                Color.Gray);
            graph.Nodes.Add(nodeFrom);
            FilledCircle startNode = nodeFrom;
            int prevIndex = index;
            Color color;

            //Go through calculating all other nodes on solution tour and add edges between new and previous
            for (int i = 1; i < solution.Length; i++)
            {
                index = solution[i];

                if(g.OptimalSolution == null)
                {
                    color = Color.FromArgb(100, Color.Gray);
                    //
                } else if(
                    g.OptimalSolution[g.OptimalSolutionLookUp[prevIndex]+1<g.OptimalSolution.Length ? 
                        g.OptimalSolutionLookUp[prevIndex] + 1 
                        : 0
                    ]  == index ||
                    g.OptimalSolution[g.OptimalSolutionLookUp[prevIndex] - 1 >= 0 ?
                        g.OptimalSolutionLookUp[prevIndex] - 1
                        : g.OptimalSolution.Length - 1
                    ] == index
                    )
                {
                    color = Color.LawnGreen;
                } else
                {
                    color = Color.FromArgb(100, Color.Gray);
                }

                p = g.Verticies[index];
                x = (int)Math.Round((p.X - minX) * scale / width);
                y = (int)Math.Round((p.Y - minY) * scale / height);

                FilledCircle nodeTo = new FilledCircle(
                    new Point(x, y),
                    new Size(10, 10),
                    Color.Gray);
                graph.Nodes.Add(nodeTo);

                graph.Edges.Add(new Line(nodeFrom, nodeTo, color));
                nodeFrom = nodeTo;
                prevIndex = index;
            }

            if (g.OptimalSolution == null)
            {
                color = Color.FromArgb(100, Color.Gray);
                //
            }
            else if (
              g.OptimalSolution[g.OptimalSolutionLookUp[prevIndex] + 1 < g.OptimalSolution.Length ?
                  g.OptimalSolutionLookUp[prevIndex] + 1
                  : 0
              ] == solution[0] ||
              g.OptimalSolution[g.OptimalSolutionLookUp[prevIndex] - 1 >= 0 ?
                  g.OptimalSolutionLookUp[prevIndex] - 1
                  : g.OptimalSolution.Length - 1
              ] == solution[0]
              )
            {
                color = Color.LawnGreen;
            }
            else
            {
                color = Color.FromArgb(100, Color.Gray);
            }

            //Add edge back to the beginning
            graph.Edges.Add(new Line(nodeFrom, startNode, color));
            return graph;
        }
    }
}
