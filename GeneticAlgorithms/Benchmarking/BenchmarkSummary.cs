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
        public List<IGeneticAlgorithm<TIndividual>> Algorithms;

        public BenchmarkSummary(
            double meanOptimizationTime, 
            double worstOptimizationTIme, 
            double bestOptimizationtime, 
            int meanAmountOfGenerations, 
            int bestAmountOfGenerations, 
            int worstAmountOfGenerations,
            List<IGeneticAlgorithm<TIndividual>> algorithms)
        {
            this.MeanOptimizationTime = meanOptimizationTime;
            this.Algorithms = algorithms;
            this.MeanAmountOfGenerations = meanAmountOfGenerations;
            this.WorstAmountOfGenerations = worstAmountOfGenerations;
            this.BestAmountOfGenerations= bestAmountOfGenerations;
            this.BestOptimizationTIme = bestOptimizationtime;
            this.WorstOptimizationTIme = worstOptimizationTIme;
        }
    }
}
