using Algorithms;
using Algorithms.Benchmark;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Benchmarking;
using Common;
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
                await model.Optimize();
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
                chart.values.AddRange(model.SelectedGeneration.IndividualFitness.Values.Select(v => (double)v).ToList());
                chart.Draw(e.Graphics);

                Chart chartBest = new Chart(200, 400, new Point(50, 350), "Best Of Each Population");
                model.algorithm.Logger.History.ForEach(v => chartBest.values.Add(v.HighestFitness));
                chartBest.Draw(e.Graphics);

                e.Graphics.DrawString("Generation: " + model.SelectedgenerationNumber, new Font("Arial", 16), new SolidBrush(Color.Black), new Point(50, 600));
            }
        }
        #endregion

        private async void test_btn_Click(object sender, EventArgs e)
        {
            //Task[] tasks = new Task[10];

            //for (int i = 0; i < 10; i++)
            //{
            //    tasks[i] = Task.Run(async () =>
            //    {
            //        await Task.Delay(1000);
            //    });
            //}

            //await Task.WhenAll(tasks);

            //this.test_btn.Text = "DONE!";

            /*
            var result = await Benchmarker.Benchmark<BitStringIndividual>(
                new Func<GenericAlgorithmBase<BitStringIndividual>>(() =>
                    new GenericAlgorithmBase<BitStringIndividual>(
                        new RandomSelectionBitStringCrossover(),
                        new OneOverNBitStringMutation(),
                        new OneMaxFitnessCalculator(),
                        new BitStringPopulation(10, 100),
                        new RandomBitStringSelector(),
                        new LoggerBase<BitStringIndividual>())),
                new Predicate<GenericAlgorithmBase<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1)
                    {
                        return false;
                    }
                    return algorithm.Logger?.History?.Last()?.HighestFitness == 100;
                }));
            
            OnePlusOneEaAlgorithm<BitStringIndividual> algo = new OnePlusOneEaAlgorithm<BitStringIndividual>(
                new OneOverNBitStringMutation(), 
                new OneMaxFitnessCalculator(), 
                new LoggerBase<BitStringIndividual>(),
                new BitStringIndividual(100));
            algo.Optimize(new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness == 100;
            })).Wait();
            //*/

            //int length = 32;
            //var result = await Benchmarker.Benchmark<BitStringIndividual>(
            //    new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
            //        new OnePlusOneEaAlgorithm<BitStringIndividual>(
            //            new OneOverNXBitStringMutation(),
            //            new BinValFitnessCalculator(),
            //            new LoggerBase<BitStringIndividual>(),
            //            new BitStringIndividual(length)
            //        )
            //    ),
            //    new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            //        {
            //            if (algorithm.Logger?.History.Count < 1)
            //            {
            //                return false;
            //            }
            //            return algorithm.Logger?.History?.Last()?.HighestFitness == int.MaxValue;
            //        }
            //    ),
            //    100000,
            //    500000000
            //    );


            //CoordinateGraph g = new CoordinateGraph(new PointF[]
            //{
            //    new PointF(0,0),
            //    new PointF(5,0),
            //    new PointF(10,0),
            //    new PointF(10,5),
            //    new PointF(10,10),
            //    new PointF(5,10),
            //    new PointF(0,10)
            //});

            //var t =
            //    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
            //        new TwoOptMutator(),
            //        new TravelingSalesPersonFitnessCalculator(),
            //        new LoggerBase<TravelingSalesPersonIndividual>(),
            //        new TravelingSalesPersonIndividual(7, g));

            //await t.Optimize(new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
            //{
            //    if (algorithm.Logger?.History.Count < 1)
            //    {
            //        return false;
            //    }

            //    return algorithm?.Logger?.History?.Last()?.HighestFitness == int.MaxValue - 40;
            //}));
        }

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
    }
}
