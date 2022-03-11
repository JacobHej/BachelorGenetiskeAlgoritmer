using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ISelector<TPopulation, TIndividual> where TPopulation : IPopulation<TIndividual> where TIndividual : IIndividual
    {
        public TIndividual Select(TPopulation population);

        public (TPopulation, List<TIndividual>) SelectMultiple(TPopulation population, int selectionSize);
    }
}
