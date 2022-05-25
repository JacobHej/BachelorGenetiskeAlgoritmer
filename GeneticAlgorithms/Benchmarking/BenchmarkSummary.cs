using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking
{
    public class BenchmarkSummary<TIndividual> where TIndividual : IIndividual
    {
        public double MeanOptimizationTime;
        public double WorstOptimizationTIme;
        public double BestOptimizationTIme;
        public int MeanAmountOfGenerations;
        public int BestAmountOfGenerations;
        public int WorstAmountOfGenerations;
        public int MeanAmountOfIterations;
        public int BestAmountOfIterations;
        public int WorstAmountOfIterations;
        public List<IterationSummary<TIndividual>> Summaries;

        public BenchmarkSummary(
            double meanOptimizationTime,
            double worstOptimizationTIme,
            double bestOptimizationtime,
            int meanAmountOfGenerations,
            int bestAmountOfGenerations,
            int worstAmountOfGenerations,
            int meanAmountOfIterations,
            int bestAmountOfIterations,
            int worstAmountOfIterations,
            List<IterationSummary<TIndividual>> summaries)
        {
            this.MeanOptimizationTime = meanOptimizationTime;
            this.MeanAmountOfGenerations = meanAmountOfGenerations;
            this.WorstAmountOfGenerations = worstAmountOfGenerations;
            this.BestAmountOfGenerations = bestAmountOfGenerations;
            this.MeanAmountOfIterations = meanAmountOfIterations;
            this.WorstAmountOfIterations = worstAmountOfIterations;
            this.BestAmountOfIterations = bestAmountOfIterations;
            this.BestOptimizationTIme = bestOptimizationtime;
            this.WorstOptimizationTIme = worstOptimizationTIme;
            this.Summaries = summaries;
        }
        public class IterationSummary<TIndividual> where TIndividual : IIndividual
        {
            public List<long> GenerationTimeStamps = new List<long>();
            public bool TaskTimedOut;
            public int Generations;
            public double OptimizationTime;
            public IGeneticAlgorithm<TIndividual> Algorithm;
        }
    }
}
