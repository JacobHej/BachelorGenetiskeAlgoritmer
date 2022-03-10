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
        private CoordinateGraph problem;
        private int populationSize;
        public TravelingSalesPersonPopulation(int populationSize, CoordinateGraph g, bool random = true) : base(populationSize)
        {
            Individuals = new List<TravelingSalesPersonIndividual>();
            this.problem = g;
            this.populationSize = populationSize;

            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new TravelingSalesPersonIndividual(g, random));
            }
        }
        public TravelingSalesPersonPopulation(CoordinateGraph g, List<TravelingSalesPersonIndividual> individuals) : base(individuals.Count)
        {
            Individuals = individuals;
            this.problem = g;
            this.populationSize = individuals.Count;
        }

        public override IPopulation<TravelingSalesPersonIndividual> Copy()
            => new TravelingSalesPersonPopulation(problem, Individuals.Select(i => (TravelingSalesPersonIndividual)i.Copy()).ToList());
    }
}
