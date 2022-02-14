using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class LeadingOnesFitnessCalculator : FitnessCalculatorBase<BitStringIndividual>
    {
        public override int CalculateFitness(BitStringIndividual individual) => individual.Solution.Bits.TakeWhile(bits => bits == '1').Count();        
    }
}
