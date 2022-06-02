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
            if (model.SelectedGeneration != null)
            {

                SimpleGraph graph = Converter.CoordinateGraphToSimpleGraph(
                    model.graph,
                    Math.Min(graph_pb.Width, graph_pb.Height)-padding,
                    model.SelectedGeneration.HighestFitnessIndividual?.Solution
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
            pauseClick();
        }

        private void pauseClick()
        {
            if (model.EvolutionSimulation != null)
            {
                model.EvolutionSimulation.Stop();
            }

            this.restart_btn.Enabled = true;
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

            this.restart_btn.Enabled = false;
            this.interval_tb.Enabled = false;
            this.play_btn.Enabled = false;
            this.pause_btn.Enabled = true;
            this.evolve_btn.Enabled = false;

            int interval = int.Parse(this.interval_tb.Text);

            model.EvolutionSimulation = new TimedEvent(interval, new Action(async () =>
            {
                await model.Evolve();
                try
                {
                    this.Invoke(new Action(() => this.Invalidate(true)));
                }
                catch (ObjectDisposedException ex)
                {
                    model.EvolutionSimulation.Stop();
                }
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
                int? MaxItr_i = string.IsNullOrEmpty(MaxItr_tb.Text) ? null : int.Parse(MaxItr_tb.Text);
                int? ItrWithoutImpr_i = string.IsNullOrEmpty(ItrWithoutImpr_tb.Text) ? null : int.Parse(ItrWithoutImpr_tb.Text);
                int? TargetLength_i = string.IsNullOrEmpty(TargetFitness_tb.Text) ? null : int.Parse(TargetFitness_tb.Text);
                await model.Optimize(MaxItr_i, ItrWithoutImpr_i, TargetLength_i);
            });

            this.graph_pb.Invalidate();
        }

        private void OnlyInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void prevGen_btn_Click(object sender, EventArgs e)
        {
            model.SelectPreviousGeneration();
            this.graph_pb.Invalidate();
        }

        private void nextGen_btn_Click(object sender, EventArgs e)
        {
            model.SelectNextGeneration();
            this.graph_pb.Invalidate();
        }


        private void BitManipV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            pauseClick();
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            model.restartAlgorithm();
            this.Invalidate(true);
        }
    }
}
