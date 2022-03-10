using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class TravelingSalesPersonPopulation : PopulationBase<TravelingSalesPersonIndividual>
    {

        CoordinateGraph problem;

        public TravelingSalesPersonPopulation(int populationSize, CoordinateGraph problem) : base(populationSize)
        {
            problem = problem;
            Individuals = new List<TravelingSalesPersonIndividual>();

            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new TravelingSalesPersonIndividual(problem));
            }
        }

        public TravelingSalesPersonPopulation(List<TravelingSalesPersonIndividual> individuals) : base(individuals.Count)
        {
            problem = individuals.First().Problem;
            Individuals = individuals;
        }

        public override IPopulation<TravelingSalesPersonIndividual> Copy() 
            => new TravelingSalesPersonPopulation(Individuals.Select(i => (TravelingSalesPersonIndividual) i.Copy()).ToList());
    }
}
