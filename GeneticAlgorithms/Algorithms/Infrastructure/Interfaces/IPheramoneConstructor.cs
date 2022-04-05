using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IPheramoneConstructor<TIndividual> where TIndividual : IIndividual
    {
        public Dictionary<string, double> ConstructPheramones(Dictionary<string, double> previousPheramones, List<TIndividual> individuals);
    }
}
