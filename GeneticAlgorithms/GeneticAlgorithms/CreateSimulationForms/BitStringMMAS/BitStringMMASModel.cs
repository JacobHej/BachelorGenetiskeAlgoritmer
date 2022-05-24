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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMMAS
{
    public class BitStringMMASModel : SimpleBitStringAlgorithmModel
    {

        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> fitnessCalculator, int BitStringLength, double p, double min, double max, double initialPheromone)
        {
            bitLength = BitStringLength;

            var pherCon = new MinMaxBitStringPheramoneConstructor(p, min, max);

            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new MMASAlgorithm<BitStringPopulation, BitStringIndividual>(
                    fitnessCalculator,
                    pherCon,
                    new BitStringAntConstructor(BitStringLength),
                    new LoggerBase<BitStringIndividual>(),
                    pherCon.InitializePheromones(BitStringLength, initialPheromone)
                );
            });

            algorithm = algorithmFactory();
        }
    }
}
