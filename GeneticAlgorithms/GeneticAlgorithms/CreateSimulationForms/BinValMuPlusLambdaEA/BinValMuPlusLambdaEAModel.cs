using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BinValMuPlusLambdaEA
{
    public class BinValMuPlusLambdaEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm( int bitLengthIn, int population = 10, int mu = 5, double crossChance = 50)
        {
            
            bitLength = bitLengthIn;
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>(
                    new RandomSelectionBitStringCrossover(),
                    new OneOverNXBitStringMutation(),
                    new BinValFitnessCalculator(),
                    new RandomSelector<BitStringPopulation, BitStringIndividual>(),
                    new LoggerBase<BitStringIndividual>(),
                    new ReplaceWorstReplacer<BitStringPopulation, BitStringIndividual>(),
                    new BitStringPopulation(population, bitLengthIn),
                    mu,
                crossChance);
            });
            algorithm = algorithmFactory();
        }
    }
}
