using IOParsing;
using System.Xml;
using Visualization;
using Common;

namespace GeneticAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Visualization.Graph graph;


        private void Draw()
        {
            this.Size = new System.Drawing.Size(1000, 800);
            this.Refresh();
            Graphics g = this.CreateGraphics();
            graph.Draw(g);
        }

        private void WalkRandom(Common.Graph graph)
        {
            int scale = 400;
            Point center = new Point(scale, scale);
            double degreesPerIndex = 360.0 / graph.Verticies.Count;

            Point c = new Point(center.X + (int) Math.Sin(degreesPerIndex), center.Y + (int) Math.Cos(degreesPerIndex));

            Visualization.Graph visualGraph = new Visualization.Graph();

            // generate random walk
            Random random = new Random();
            IEnumerable<int> path = Enumerable.Range(0, graph.Verticies.Count).OrderBy(item => random.Next());
            
            // Select first node
            int start = path.First();
            int[] arrayPath = path.Skip(1).ToArray();

            Vertex vertexFrom = graph.Verticies[start];
            int x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * start) * scale);
            int Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * start) * scale);
            Node nodeFrom = new Node(
                new Point(x,Y),
                new Size(20, 20), 
                Color.Blue);
            int indexPrev = start;

            visualGraph.Nodes.Add(nodeFrom);

            // Create graph
            for (int i = 0; i < arrayPath.Count(); i++)
            {
                int index = arrayPath[i];

                // Create and add new node
                x = (int)Math.Round(center.X + Math.Sin(degreesPerIndex * index) * scale);
                Y = (int)Math.Round(center.Y + Math.Cos(degreesPerIndex * index) * scale);
                Node nodeTo = new Node(
                    new Point(x, Y),
                    new Size(10, 10),
                    Color.Red);
                visualGraph.Nodes.Add(nodeTo);

                // Add edge from previous to new
                // ignoring weight
                Common.Edge edge = vertexFrom.Edges[index > indexPrev ? index - 1 : index];                

                visualGraph.Edges.Add(new Visualization.Edge(nodeFrom, nodeTo));

                // Update previous node and vertex
                indexPrev = index;
                vertexFrom = graph.Verticies[index];
                nodeFrom = nodeTo;
            }

            this.graph = visualGraph;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WalkRandom(new Parser().LoadGraph());
            Draw();
        }
    }
}