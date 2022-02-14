using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class BinValFitnessCalculator : FitnessCalculatorBase<BitStringIndividual>
    {
        public override int CalculateFitness(BitStringIndividual individual)
        {
            int oneBits = 0;

            for (int i = 0; i < individual.Solution.Bits.Length; i++)
            {
                int shift = individual.Solution.Bits[i] == '1' ? 1 : 0;
                oneBits |= (shift << i);
            }

            return oneBits;
        }
    }
}
