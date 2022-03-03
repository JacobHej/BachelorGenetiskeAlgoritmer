using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IReplacer<TPopulation, TIndividual> where TIndividual : IIndividual where TPopulation : IPopulation<TIndividual>
    {
        public TPopulation Replace(TPopulation population, List<TIndividual> individuals, IFitnessCalculator<TIndividual> fitnessCalculator);
    }
}
