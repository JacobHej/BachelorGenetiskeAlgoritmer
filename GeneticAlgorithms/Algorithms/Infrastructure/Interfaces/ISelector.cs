using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ISelector<TIndividual> where TIndividual : IIndividual
    {
        public TIndividual Select(IPopulation<TIndividual> population);
    }
}
