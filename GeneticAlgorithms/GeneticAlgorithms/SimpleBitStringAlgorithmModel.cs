using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualization;

namespace GeneticAlgorithms
{
    public class SimpleBitStringAlgorithmModel
    {
        public TimedEvent EvolutionSimulation;

        public Generation<BitStringIndividual> SelectedGeneration;
        public int SelectedgenerationNumber => algorithm.Logger.History.IndexOf(SelectedGeneration);

        public int population = 10;
        public int bitLength = 100;
        public bool UseProbabilitySelector = false;

        public GeneticAlgorithmBase<BitStringIndividual> algorithm;

        public void create_A_OnePlusOne_P_OneMax(int bitLengthIn)
        {
            population = 1;
            bitLength = bitLengthIn;
            algorithm = new OnePlusOneEaAlgorithm<BitStringIndividual>(
                new OneOverNXBitStringMutation(),
                new OneMaxFitnessCalculator(),
                new LoggerBase<BitStringIndividual>(),
                new BitStringIndividual(bitLength)
            );
        }

        public void createAlgorithm<TAlgorithm>(
            int bitLength,
            int Population = 1
        ) where TAlgorithm : GeneticAlgorithmBase<BitStringIndividual>
        {
            String a = (typeof(OnePlusOneEaAlgorithm<BitStringIndividual>)).Name;
            String b = (typeof(TAlgorithm)).Name;
        }

        public async Task Evolve()
        {
            await algorithm.Evolve();
            SelectedGeneration = algorithm.Logger.History.Last();
        }

        public async Task Optimize()
        {
            await algorithm.Optimize(new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness == bitLength;
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
    }
}
