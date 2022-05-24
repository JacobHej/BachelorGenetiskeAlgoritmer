using Algorithms;
using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringASRank
{
    public class BitStringASRankModel : SimpleBitStringAlgorithmModel
    {

        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> fitnessCalculator, int BitStringLength, double p, double q, double initialPheromone, int populationSize, int xNrOfRanks)
        {
            bitLength = BitStringLength;

            var pheromoneConstructor = new BitStringPheramoneConstructor(p, q, fitnessCalculator);

            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<BitStringPopulation, BitStringIndividual>(
                    fitnessCalculator,
                    pheromoneConstructor,
                    new SelectXBestSelector<BitStringPopulation, BitStringIndividual>(
                     fitnessCalculator),
                    new BitStringAntConstructor(BitStringLength),
                    new LoggerBase<BitStringIndividual>(),
                    pheromoneConstructor.InitializePheromones(BitStringLength, initialPheromone),
                    populationSize,
                    xNrOfRanks
                );
            });

            algorithm = algorithmFactory();
        }
    }
}
