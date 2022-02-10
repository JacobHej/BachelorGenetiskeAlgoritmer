using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class PopulationBase : IPopulation
    {
        public List<IIndividual> Individuals { get; private set; }
    }
}
