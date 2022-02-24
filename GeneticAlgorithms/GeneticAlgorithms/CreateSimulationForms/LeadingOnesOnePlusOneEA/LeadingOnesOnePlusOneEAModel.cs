using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.LeadingOnesOnePlusOneEA
{
    public class LeadingOnesOnePlusOneEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(int bitLengthIn)
        {
            population = 1;
            bitLength = bitLengthIn;
            algorithm = new OnePlusOneEaAlgorithm<BitStringIndividual>(
                new OneOverNXBitStringMutation(),
                new LeadingOnesFitnessCalculator(),
                new LoggerBase<BitStringIndividual>(),
                new BitStringIndividual(bitLength)
            );
        }
    }
}
