using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
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
using Visualization.Components;

namespace GeneticAlgorithms
{
    public partial class BitManipV2 : Form
    {

        SimpleBitStringAlgorithmModel model;

        public BitManipV2(SimpleBitStringAlgorithmModel model)
        {
            this.model = model;
            InitializeComponent();
            this.data_pb.Invalidate();
        }

        private void createNewSimulation_btn_Click(object sender, EventArgs e)
        {

        }

        private async void evolve_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                await model.Evolve();
            });
            this.data_pb.Invalidate();
        }

        private async void optimize_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                int? MaxItr_i = string.IsNullOrEmpty(MaxItr_tb.Text) ? null : int.Parse(MaxItr_tb.Text);
                int? ItrWithoutImpr_i = string.IsNullOrEmpty(ItrWithoutImpr_tb.Text) ? null : int.Parse(ItrWithoutImpr_tb.Text);
                int? TargetFitness_i = string.IsNullOrEmpty(TargetFitness_tb.Text) ? null : int.Parse(TargetFitness_tb.Text);
                await model.Optimize(MaxItr_i, ItrWithoutImpr_i, TargetFitness_i);
            });

            this.data_pb.Invalidate();
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
                try
                {
                    this.Invoke(new Action(() => this.Invalidate(true)));
                } catch (Exception ex)
                {
                    model.EvolutionSimulation.Stop();
                }
            }));

            model.EvolutionSimulation.Start();
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

            this.pause_btn.Enabled = false;
            this.interval_tb.Enabled = true;
            this.play_btn.Enabled = true;
            this.evolve_btn.Enabled = true;
        }

        private async void test_btn_Click(object sender, EventArgs e)
        {
            OnePlusOneEaAlgorithm<BitStringIndividual> algo = new OnePlusOneEaAlgorithm<BitStringIndividual>(
                new OneOverNXBitStringMutation(),
                new BinValFitnessCalculator(),
                new LoggerBase<BitStringIndividual>(),
                new BitStringIndividual(16));
            await algo.Optimize(new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness > (2 * Math.Pow(2, 15)) - 2;
            }));
            model.algorithm = algo;
            this.data_pb.Invalidate();
        }

        #region PaintEvents
        private async void data_pb_Paint(object sender, PaintEventArgs e)
        {
            OnionThing o = new OnionThing(new Point(50,650), new Size(200, 200));
            o.Draw2(e.Graphics, model.bitLength, model.GetWeights());

            if (model.algorithm.Logger.History.Count > 0 && model.SelectedGeneration != null)
            {


                Chart chart = new Chart(200, 400, new Point(50, 50), "Latest Population");
                chart.values.AddRange(model.SelectedGeneration.IndividualFitness.Values.Select(v => (double)v).ToList());
                chart.Draw(e.Graphics);

                Chart chartBest = new Chart(200, 400, new Point(50, 350), "Best Of Each Population");
                model.algorithm.Logger.History.ForEach(v => chartBest.values.Add(v.HighestFitness));
                chartBest.Draw(e.Graphics);

                e.Graphics.DrawString("Generation: " + model.SelectedgenerationNumber, new Font("Arial", 16), new SolidBrush(Color.Black), new Point(50, 600));
                e.Graphics.DrawString("Iteration: " + model.algorithm.Iterations, new Font("Arial", 16), new SolidBrush(Color.Black), new Point(50, 620));
            }
        }
            #endregion

            private void prevGen_btn_Click(object sender, EventArgs e)
        {
            model.SelectPreviousGeneration();
            this.data_pb.Invalidate();
        }

        private void nextGen_btn_Click(object sender, EventArgs e)
        {
            model.SelectNextGeneration();
            this.data_pb.Invalidate();
        }

        private void MaxItr_tb_TextChanged(object sender, EventArgs e)
        {
        }

        private void OnlyInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
