using Algorithms;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringACO
{
    public partial class BitStringACO : CreateSimulationForm
    {


        ACOSelector.ACOSelector ACOSel;
        BitStringSelector.BitStringSelector BitSel;
        IFitnessCalculator<BitStringIndividual> problem;

        public BitStringACO(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            this.problem = problem;
            InitializeComponent();
            this.headline.Text = headlineText;
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringACOModel model = new BitStringACOModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();
            MutatorBase<TravelingSalesPersonIndividual> mutator = mutSel.getMutator();
            //model.createAlgorithm(graph, mutator, mu, lambda, crossover);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }

        
    }
}
