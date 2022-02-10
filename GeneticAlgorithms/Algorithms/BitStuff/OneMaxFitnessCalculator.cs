using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class OneMaxFitnessCalculator : FitnessCalculatorBase<BitStringIndividual>
    {
        public override int CalculateFitness(BitStringIndividual individual)
        {
            int oneBits = 0;

            for (int i = 0; i < individual.Solution.Bits.Length; i++)
            {
                oneBits += individual.Solution.Bits[i] == '1' ? 1 : 0;
            }

            return oneBits;
        }
    }
}
