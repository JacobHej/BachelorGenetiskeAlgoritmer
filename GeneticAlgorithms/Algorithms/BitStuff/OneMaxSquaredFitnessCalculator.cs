using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public  class OneMaxSquaredFitnessCalculator : OneMaxFitnessCalculator
    {
        public override int CalculateFitness(BitStringIndividual individual) 
            => (int) Math.Pow(base.CalculateFitness(individual), 2);
    }
}
