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

namespace GeneticAlgorithms.CreateSimulationForms.TSPSimulatedAnnealing
{
    public partial class TSPSimulatedAnnealing : CreateSimulationForm
    {

        TSPSelector.TSPSelector TSPSel;
        TSPMutator.TSPMutatorSelector mutSel;
        SimulatedAnnealingSelector.SimulatedAnnealingSelector SimAnSel;
        public TSPSimulatedAnnealing()
        {
            InitializeComponent();
            this.headline.Text = "TSP - Simulated Annealing";
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPSimulatedAnnealingModel model = new TSPSimulatedAnnealingModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();
            double starttemp = SimAnSel.getStartTemp();
            double alpha = SimAnSel.getAlpha();
            MutatorBase<TravelingSalesPersonIndividual> mutator = mutSel.getMutator();
            model.createAlgorithm(graph, mutator, starttemp, alpha);
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }
    }
}
