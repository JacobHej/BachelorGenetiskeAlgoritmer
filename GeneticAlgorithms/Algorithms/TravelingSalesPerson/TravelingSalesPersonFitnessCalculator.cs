using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class TravelingSalesPersonFitnessCalculator : FitnessCalculatorBase<TravelingSalesPersonIndividual>
    {
        public override int CalculateFitness(TravelingSalesPersonIndividual individual)
        {
            int fitness = 0;

            int prevVertex = individual.Solution[0];

            for(int i = 1; i < individual.Solution.Length; i++)
            {
                fitness += individual.Problem.GetDistance(prevVertex, prevVertex = individual.Solution[i]);
            }

            fitness += individual.Problem.GetDistance(prevVertex,individual.Solution[0]);

            return int.MaxValue - fitness;
        }
    }
}
