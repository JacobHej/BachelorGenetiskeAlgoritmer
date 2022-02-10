using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
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
        public GenericAlgorithmBase<BitStringIndividual> algorithm = new GenericAlgorithmBase<BitStringIndividual>(
            new RandomSelectionBitStringCrossover(),
            new OneOverNBitStringMutation(),
            new OneMaxFitnessCalculator(),
            new BitStringPopulation(10, 100),
            new RandomBitStringSelector(),
            new LoggerBase<BitStringIndividual>());

        public TimedEvent EvolutionSimulation;

        public int population = 10;
        public int bitLength = 100;
        public bool UseProbabilitySelector = false;

        public void CreateAlgorithm()
        {
            algorithm = new GenericAlgorithmBase<BitStringIndividual>(
                new RandomSelectionBitStringCrossover(),
                new OneOverNBitStringMutation(),
                new OneMaxFitnessCalculator(),
                new BitStringPopulation(population, bitLength),
                UseProbabilitySelector ? new SelectOnlyTwoBestSelector(new OneMaxFitnessCalculator()) : new RandomBitStringSelector(),
                new LoggerBase<BitStringIndividual>());
        }

        public async Task Evolve()
        {
            await algorithm.Evolve();
        }
        public void Optimize()
        {
            algorithm.Optimize(new Predicate<GenericAlgorithmBase<BitStringIndividual>>((algorithm) =>
            {
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;
                }
                return algorithm.Logger?.History?.Last()?.HighestFitness == bitLength;
            }));
        }
    }
}
