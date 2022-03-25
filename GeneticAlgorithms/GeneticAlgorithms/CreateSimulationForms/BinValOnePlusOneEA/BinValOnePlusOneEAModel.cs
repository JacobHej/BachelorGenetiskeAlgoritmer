using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BinValOnePlusOneEA
{
    public class BinValOnePlusOneEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(BitStringIndividual bitString)
        {
            population = 1;
            bitLength = bitString.Solution.Bits.Length;
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new OnePlusOneEaAlgorithm<BitStringIndividual>(
                    new OneOverNXBitStringMutation(),
                    new BinValFitnessCalculator(),
                    new LoggerBase<BitStringIndividual>(),
                    bitString
                );
            });
            algorithm = algorithmFactory();
        }
    }
}
