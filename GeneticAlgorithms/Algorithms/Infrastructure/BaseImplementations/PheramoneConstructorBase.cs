using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class PheramoneConstructorBase<TIndividual> : IPheramoneConstructor<TIndividual> where TIndividual : IIndividual
    {
        public abstract Dictionary<string, double> ConstructPheramones(Dictionary<string, double> previousPheramones, List<TIndividual> individuals);
    }
}
