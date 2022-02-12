using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class GeneticAlgorithmBase<TIndividual> : IGeneticAlgorithm<TIndividual> where TIndividual : IIndividual
    {
        public virtual ILogger<TIndividual> Logger { get { throw new NotImplementedException();} set { throw new NotImplementedException();} }

        public virtual Task Evolve()
        {
            throw new NotImplementedException();
        }

        public virtual async Task Optimize(Predicate<IGeneticAlgorithm<TIndividual>> stoppingCriteria)
        {
            while (!stoppingCriteria.Invoke(this))
            {
                await Evolve();
            }
        }
    }
}
