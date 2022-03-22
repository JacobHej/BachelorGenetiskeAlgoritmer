using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class ReplacerBase<TPopulation, TIndividual> :
        IReplacer<TPopulation, TIndividual>
        where TIndividual : IIndividual
        where TPopulation : IPopulation<TIndividual>
    {
        public abstract TPopulation Replace(TPopulation population, List<TIndividual> individuals, IFitnessCalculator<TIndividual> fitnessCalculator);
    }

}
