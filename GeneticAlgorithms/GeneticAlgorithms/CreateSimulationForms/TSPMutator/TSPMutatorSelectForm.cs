using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMutator
{
    public abstract class TSPMutatorSelectForm: Form
    {
        public abstract MutatorBase<TravelingSalesPersonIndividual> GetMutator();
    }
}
