using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMutator
{
    public partial class TwoOptMutatorForm : TSPMutatorSelectForm
    {
        public TwoOptMutatorForm()
        {
            InitializeComponent();
        }

        public override MutatorBase<TravelingSalesPersonIndividual> GetMutator()
        {
            return new TwoOptMutator();
        }
    }
}
