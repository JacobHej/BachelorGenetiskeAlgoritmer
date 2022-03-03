using Algorithms;
using Algorithms.TravelingSalesPerson;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualization;
using Common;

namespace GeneticAlgorithms
{
    public class SimpleTSPAlgorithmModel
    {
        public TimedEvent EvolutionSimulation;

        public Generation<TravelingSalesPersonIndividual> SelectedGeneration;
        public int SelectedgenerationNumber => algorithm.Logger.History.IndexOf(SelectedGeneration);
        public bool UseProbabilitySelector = false;

        public Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>> algorithmFactory;
        public GeneticAlgorithmBase<TravelingSalesPersonIndividual> algorithm;
        public CoordinateGraph graph;


        public async Task Evolve()
        {
            await algorithm.Evolve();
            SelectedGeneration = algorithm.Logger.History.Last();
        }

        public async Task Optimize()
        {
            await algorithm.Optimize(new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                int? highestFitnessSoFar = null;
                int prevIterations = 0;
                int maxIterations = 1000;
                if (highestFitnessSoFar == null)
                {
                    highestFitnessSoFar = algorithm.Logger?.History?.Last()?.HighestFitness;
                    prevIterations = algorithm.Iterations;
                    return false;
                }
                if (algorithm.Logger?.History?.Last()?.HighestFitness > highestFitnessSoFar)
                {
                    prevIterations = algorithm.Iterations;
                    highestFitnessSoFar = algorithm.Logger?.History?.Last()?.HighestFitness;
                    return false;
                }
                if (algorithm.Iterations - prevIterations > maxIterations)
                {
                    return true;
                }
                return false;
            }));

            SelectedGeneration = algorithm.Logger.History.Last();
        }

        public void SelectPreviousGeneration()
        {
            int index = algorithm.Logger.History.IndexOf(SelectedGeneration);

            if (index - 1 < 0) return;

            SelectedGeneration = algorithm.Logger.History[index - 1];
        }

        public void SelectNextGeneration()
        {
            int index = algorithm.Logger.History.IndexOf(SelectedGeneration);

            if (index + 1 >= algorithm.Logger.History.Count) return;

            SelectedGeneration = algorithm.Logger.History[index + 1];
        }

        public void restartAlgorithm()
        {
            algorithm = algorithmFactory();
        }
    }
}
