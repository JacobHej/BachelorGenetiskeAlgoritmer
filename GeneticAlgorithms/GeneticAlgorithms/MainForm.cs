using IOParsing;
using Visualization;
using Visualization.Conversion;
using Common;
using Algorithms;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.BitStuff;
using Visualization.Components;

namespace GeneticAlgorithms
{
    public partial class MainForm : Form
    {
        private MainFormModel model;
        SimpleBitStringAlgorithmModel modelAlgo;
        private TimedEvent timedEvent;
        private bool GraphOrBit = false;

        public MainForm()
        {
            InitializeComponent();

            model = new MainFormModel();
            this.files_lb.Items.AddRange(model.Files.Keys.ToArray());

            modelAlgo = new SimpleBitStringAlgorithmModel();
        }

        #region Paint events
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            this.files_lb.Items.Clear();
            this.files_lb.Items.AddRange(model.Files.Keys.ToArray());
        }

        private void graph_pb_Paint(object sender, PaintEventArgs e)
        {
            if (GraphOrBit)
            {
                if (model.EvaluatedGraph == null) return;

                int padding = 20;

                SimpleGraph graph = Converter.ConvertToSimpleGraph(
                    model.EvaluatedGraph,
                    new Point(graph_pb.Width / 2, graph_pb.Height / 2),
                    Math.Min(graph_pb.Width, graph_pb.Height) / 2 - padding);

                graph.Draw(e.Graphics);
            }
            else
            {
                if (modelAlgo.algorithm.Logger.History.Count > 0)
                {
                    Chart chart = new Chart(200, 400, new Point(50, 50), "Latest Population");
                    chart.values.AddRange(modelAlgo.algorithm.Logger.History.Last().IndividualFitness.Values.Select(v => (double)v).ToList());
                    chart.Draw(e.Graphics);

                    Chart chartBest = new Chart(200, 400, new Point(50, 450), "Best Of Each Population");
                    modelAlgo.algorithm.Logger.History.ForEach(v => chartBest.values.Add(v.HighestFitness));
                    chartBest.Draw(e.Graphics);
                }
            }           
        }

        private void timesEvaluated_lbl_Paint(object sender, PaintEventArgs e)
        {
            this.timesEvaluated_lbl.Text = "Times Evaluated: " + model.TimesEvaluated;
        }
        #endregion

        private void evaluate_btn_Click(object sender, EventArgs e)
        {
            if (GraphOrBit)
            {
                model.EvaluateGraph();
                this.Invalidate(true);
            }
            else
            {
                modelAlgo.algorithm.Evolve();
                this.graph_pb.Invalidate();
            }
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.interval_tb.Text) || this.interval_tb.Text.Any(c => !char.IsDigit(c)))
            {
                this.interval_tb.Text = "Please enter a valid interval";
                this.interval_tb.BackColor = Color.Red;
                return;
            }
            else
            {
                this.interval_tb.BackColor = Color.White;
            }

            this.interval_tb.Enabled = false;
            this.play_btn.Enabled = false;
            this.pause_btn.Enabled = true;
            this.evaluate_btn.Enabled = false;

            int interval = int.Parse(this.interval_tb.Text);

            timedEvent = new TimedEvent(interval, new Action(() =>
            {
                if (GraphOrBit)
                {
                    model.EvaluateGraph();
                }
                else
                {
                    modelAlgo.algorithm.Evolve();
                }

                this.Invoke(new Action(() => this.Invalidate(true)));
            }));

            timedEvent.Start();
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            timedEvent.Stop();

            this.pause_btn.Enabled = false;
            this.interval_tb.Enabled = true;
            this.play_btn.Enabled = true;
            this.evaluate_btn.Enabled = true;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            if (GraphOrBit)
            {
                model.Clear();
            }
            else
            {
                modelAlgo.algorithm = new GenericAlgorithmBase<BitStringIndividual>(
                    new RandomSelectionBitStringCrossover(),
                    new OneOverNBitStringMutation(),
                    new OneMaxFitnessCalculator(),
                    new BitStringPopulation(20, 100),
                    new RandomBitStringSelector(),
                    new LoggerBase<BitStringIndividual>());
            }

            this.graph_pb.Invalidate();
        }

        private void files_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListBox lb && lb.SelectedItem is string s && !string.IsNullOrEmpty(s))
            {
                model.LoadGraph(s);
                this.loadedFile_lbl.Text = "Loaded File: " + s;
            }
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            modelAlgo.algorithm.Optimize(new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness == 100;
            }));

            this.graph_pb.Invalidate();
        }

        private void bit_btn_Click(object sender, EventArgs e)
        {
            this.bit_btn.Enabled = false;
            this.graph_btn.Enabled = true;
            GraphOrBit = false;
        }

        private void graph_btn_Click(object sender, EventArgs e)
        {
            this.bit_btn.Enabled = true;
            this.graph_btn.Enabled = false;
            GraphOrBit = true;
        }
    }
}