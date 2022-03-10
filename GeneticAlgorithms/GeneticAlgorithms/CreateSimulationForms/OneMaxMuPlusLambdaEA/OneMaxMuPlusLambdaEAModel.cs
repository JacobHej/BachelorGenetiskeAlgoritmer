using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.OneMaxMuPlusLambdaEA
{
    public class OneMaxMuPlusLambdaEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(int bitLengthIn, int population = 10, int mu = 5, double crossChance = 50)
        {
            population = 1;
            bitLength = bitLengthIn;
            
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>(
                    new RandomSelectionBitStringCrossover(),
                    new OneOverNXBitStringMutation(),
                    new OneMaxFitnessCalculator(),
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
