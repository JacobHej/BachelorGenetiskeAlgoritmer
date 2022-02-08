using IOParsing;
using Visualization;
using Common;

namespace GeneticAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1000, 800);
        }

        private SimpleGraph graph = new SimpleGraph();


        private void Draw()
        {
            Graphics g = this.CreateGraphics();
            graph.Draw(g);
        }

        private async Task WalkRandom(Graph graph)
        {
            await Task.Run(async () =>
            {
                int scale = 400;
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
                int indexPrev = start;

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

                    // Add edge from previous to new
                    // ignoring weight
                    Edge edge = vertexFrom.Edges[index > indexPrev ? index - 1 : index];

                    visualGraph.Edges.Add(new Line(nodeFrom, nodeTo, Color.Red));

                    // Update previous node and vertex
                    indexPrev = index;
                    vertexFrom = graph.Verticies[index];
                    nodeFrom = nodeTo;
                }

                this.graph = visualGraph;
            });
        }

        bool flag = false;
        TimedEvent te;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                te.Stop();
            } else
            {
                TimedEvent timedEvent = new TimedEvent(500, new Action(async () =>
                                   {
                                       await WalkRandom(new Parser().LoadGraph());
                                       count++;
                                       this.Invalidate();
                                   }));
                te = timedEvent;
                te.Start();
            }

            flag = !flag;
        }

        int count = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            this.button1.Text = "" + count;
            Draw();
        }
    }
}