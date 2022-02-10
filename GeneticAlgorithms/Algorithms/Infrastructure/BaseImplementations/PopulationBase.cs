using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class PopulationBase<TIndividual> : IPopulation<TIndividual> where TIndividual : IIndividual
    {
        public List<TIndividual> Individuals { get; set; }
        public int PopulationSize { get; }

        public PopulationBase(int populationSize)
        {
            Individuals = new List<TIndividual>();
            this.PopulationSize = populationSize;
        }
    }
}
