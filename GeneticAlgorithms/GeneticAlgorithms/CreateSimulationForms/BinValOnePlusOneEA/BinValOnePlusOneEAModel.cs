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
        public void createAlgorithm(int bitLengthIn)
        {
            population = 1;
            bitLength = bitLengthIn;
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new OnePlusOneEaAlgorithm<BitStringIndividual>(
                    new OneOverNXBitStringMutation(),
                    new BinValFitnessCalculator(),
                    new LoggerBase<BitStringIndividual>(),
                    new BitStringIndividual(bitLength)
                );
            });
            algorithm = algorithmFactory();
        }
    }
}
