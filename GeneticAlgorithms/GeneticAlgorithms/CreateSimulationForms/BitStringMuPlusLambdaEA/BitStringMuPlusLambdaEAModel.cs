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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA
{
    public class BitStringMuPlusLambdaEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> problem, Func<BitStringIndividual> bitStringCreator, int mu, int lambda = 5, double crossChance = 0.5)
        {
            
            this.bitLength = bitStringCreator().Solution.Bits.Length;


            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>(
                    new RandomSelectionBitStringCrossover(),
                    new OneOverNXBitStringMutation(),
                    problem,
                    new RandomSelector<BitStringPopulation, BitStringIndividual>(),
                    new LoggerBase<BitStringIndividual>(),
                    new ReplaceWorstReplacer<BitStringPopulation, BitStringIndividual>(),
                    new BitStringPopulation(mu, bitStringCreator),
                    lambda,
                crossChance);
            });
            algorithm = algorithmFactory();
        }
    }
}
