using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visualization;
using Visualization.Conversion;

namespace GeneticAlgorithms
{
    public partial class TSPManipV2 : Form
    {
        SimpleTSPAlgorithmModel model;
        public TSPManipV2(SimpleTSPAlgorithmModel model)
        {
            this.model = model;
            InitializeComponent();
            graph_pb.Invalidate();
        }

        private void graph_pb_Paint(object sender, PaintEventArgs e)
        {
            int padding = 50;
            if (model.algorithm.Logger.History.Count > 0)
            {

                SimpleGraph graph = Converter.CoordinateGraphToSimpleGraph(
                    model.graph,
                    Math.Min(graph_pb.Width, graph_pb.Height)-padding,
                    model.algorithm.Logger.History.Last().HighestFitnessIndividual?.Solution
                    );

                graph.Draw(e.Graphics);
            }
            else
            {
                

                SimpleGraph graph = Converter.CoordinateGraphToSimpleGraph(
                    model.graph,
                    Math.Min(graph_pb.Width, graph_pb.Height) - padding
                    );

                graph.Draw(e.Graphics);
            }
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            model.EvolutionSimulation.Stop();

            this.pause_btn.Enabled = false;
            this.interval_tb.Enabled = true;
            this.play_btn.Enabled = true;
            this.evolve_btn.Enabled = true;
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
            this.evolve_btn.Enabled = false;

            int interval = int.Parse(this.interval_tb.Text);

            model.EvolutionSimulation = new TimedEvent(interval, new Action(async () =>
            {
                await model.Evolve();
                this.Invoke(new Action(() => this.Invalidate(true)));
            }));

            model.EvolutionSimulation.Start();
        }

        private async void evolve_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                await model.Evolve();
            });
            this.graph_pb.Invalidate();
        }

        private async void optimize_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                await model.Optimize();
            });

            this.graph_pb.Invalidate();
        }
    }
}
