using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IAntConstructor<TPopulation, TIndividual> where TIndividual : IIndividual where TPopulation : IPopulation<TIndividual>
    {
        public TIndividual ConstructAnt(Dictionary<string, double> pheramones);

        public TPopulation ConstructAnst(Dictionary<string, double> pheramones, int amount);
    }
}
