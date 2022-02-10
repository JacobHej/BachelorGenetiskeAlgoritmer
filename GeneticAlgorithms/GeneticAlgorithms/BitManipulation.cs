using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
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
    public partial class BitManipulation : Form
    {
        SimpleBitStringAlgorithmModel model;
        

        public BitManipulation()
        {
            InitializeComponent();

            model = new SimpleBitStringAlgorithmModel();
        }

        private void createAlgorithm_btn_Click(object sender, EventArgs e)
        {
            model.population = int.Parse(this.populationSize_tb.Text);
            model.bitLength = int.Parse(this.bitStringLength_tb.Text);

            if(this.probabilitySelector_rb.Checked == true)
            {
                model.UseProbabilitySelector = true;
            } else
            {
                model.UseProbabilitySelector = false;
            }

            model.CreateAlgorithm();

            this.data_pb.Invalidate();
        }

        private async void evolve_btn_Click(object sender, EventArgs e)
        {
            await model.Evolve();
            this.data_pb.Invalidate();
        }

        private void optimize_btn_Click(object sender, EventArgs e)
        {
           model.Optimize();
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

            model.EvolutionSimulation = new TimedEvent(interval, new Action(() =>
            {
                model.algorithm.Evolve();
                this.Invoke(new Action(() => this.Invalidate(true)));
            }));

            model.EvolutionSimulation.Start();
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            model.EvolutionSimulation.Stop();

            this.pause_btn.Enabled = false;
            this.interval_tb.Enabled = true;
            this.play_btn.Enabled = true;
            this.evolve_btn.Enabled = true;
        }

        #region PaintEvents
        private void data_pb_Paint(object sender, PaintEventArgs e)
        {
            if (model.algorithm.Logger.History.Count > 0)
            {
                Chart chart = new Chart(200, 400, new Point(50, 25), "Latest Population");
                chart.values.AddRange(model.algorithm.Logger.History.Last().IndividualFitness.Values.Select(v => (double)v).ToList());
                chart.Draw(e.Graphics);

                Chart chartBest = new Chart(200, 400, new Point(50, 350), "Best Of Each Population");
                model.algorithm.Logger.History.ForEach(v => chartBest.values.Add(v.HighestFitness));
                chartBest.Draw(e.Graphics);
            }
        }
        #endregion
    }
}
