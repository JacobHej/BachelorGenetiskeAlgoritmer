using Algorithms.Infrastructure.BaseImplementations;
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

namespace GeneticAlgorithms.CreateSimulationForms.TSPACO
{
    public partial class TSPACO : CreateSimulationForm
    {


        TSPSelector.TSPSelector TSPSel;
        TSPMutator.TSPMutatorSelector mutSel;
        ACOSelector.ACOSelector ACOSel;

        public TSPACO()
        {
            InitializeComponent();
            this.headline.Text = "TSP - Mu Plus Lambda";

        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPACOModel model = new TSPACOModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();
            MutatorBase<TravelingSalesPersonIndividual> mutator = mutSel.getMutator();
            //model.createAlgorithm(graph, mutator, mu, lambda, crossover);
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }

        
    }
}
