using Algorithms;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringSelector
{
    public abstract class BitStringSelectForm : Form
    {
        public abstract Func<BitStringIndividual> GetBitStringCreator();
        public abstract void addListenerOnBitsChange(Action action);
    }
}
