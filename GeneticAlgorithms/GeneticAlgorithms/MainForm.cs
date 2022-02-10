using IOParsing;
using Visualization;
using Visualization.Conversion;
using Common;
using Algorithms;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.BitStuff;

namespace GeneticAlgorithms
{
    public partial class MainForm : Form
    {
        private MainFormModel model;
        private TimedEvent timedEvent;

        public MainForm()
        {
            model = new MainFormModel();
            InitializeComponent();
            this.files_lb.Items.AddRange(model.Files.Keys.ToArray());
        }

        #region Paint events
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            this.files_lb.Items.Clear();
            this.files_lb.Items.AddRange(model.Files.Keys.ToArray());
        }

        private void graph_pb_Paint(object sender, PaintEventArgs e)
        {
            if (model.EvaluatedGraph == null) return;

            int padding = 20;

            SimpleGraph graph = Converter.ConvertToSimpleGraph(
                model.EvaluatedGraph,
                new Point(graph_pb.Width / 2, graph_pb.Height / 2),
                Math.Min(graph_pb.Width, graph_pb.Height) / 2 - padding);

            graph.Draw(e.Graphics);
        }

        private void timesEvaluated_lbl_Paint(object sender, PaintEventArgs e)
        {
            this.timesEvaluated_lbl.Text = "Times Evaluated: " + model.TimesEvaluated;
        }
        #endregion

        private void evaluate_btn_Click(object sender, EventArgs e)
        {
            model.EvaluateGraph();
            this.Invalidate(true);
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
                model.EvaluateGraph();
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
            model.Clear();
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

        private GenericAlgorithmBase<BitStringIndividual> algorithm = new GenericAlgorithmBase<BitStringIndividual>(
            new RandomSelectionBitStringCrossover(),
            new OneOverNBitStringMutation(),
            new OneMaxFitnessCalculator(),
            new BitStringPopulation(2, 1000),
            new RandomBitStringSelector(),
            new LoggerBase<BitStringIndividual>());

        private void test_btn_Click(object sender, EventArgs e)
        {
            algorithm.Optimize(new Predicate<GenericAlgorithmBase<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness == 1000;
            }));
        }

    }
}