using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class AntConstructorBase<TPopulation, TIndividual> : IAntConstructor<TPopulation, TIndividual> where TIndividual : IIndividual where TPopulation : IPopulation<TIndividual>
    {
        public abstract TIndividual ConstructAnt(Dictionary<string, double> pheramones);

        public abstract TPopulation ConstructAnst(Dictionary<string, double> pheramones, int amount);
    }
}
