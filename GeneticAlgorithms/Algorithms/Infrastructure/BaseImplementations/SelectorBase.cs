using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class SelectorBase<TPopulation, TIndividual> 
        : ISelector<TPopulation, TIndividual> 
        where TPopulation : IPopulation<TIndividual> 
        where TIndividual : IIndividual
    {
        public abstract TIndividual Select(TPopulation population);
        public abstract (TPopulation, List<TIndividual>) SelectMultiple(TPopulation population, int selectionSize);
    }
}
