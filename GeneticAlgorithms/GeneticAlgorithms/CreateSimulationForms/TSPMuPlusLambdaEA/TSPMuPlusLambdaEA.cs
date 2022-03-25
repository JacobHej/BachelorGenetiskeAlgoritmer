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

namespace GeneticAlgorithms.CreateSimulationForms.TSPMuPlusLambdaEA
{
    public partial class TSPMuPlusLambdaEA : CreateSimulationForm
    {


        TSPSelector.TSPSelector TSPSel;
        TSPMutator.TSPMutatorSelector mutSel;
        MuPlusLambdaSelector.MuPlusLambdaSelector MPLSel;

        public TSPMuPlusLambdaEA()
        {
            InitializeComponent();
            this.headline.Text = "TSP - Mu Plus Lambda";

        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPMuPlusLambdaEAModel model = new TSPMuPlusLambdaEAModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();
            int mu = MPLSel.getMu();
            int lambda = MPLSel.getLambda();
            double crossover = MPLSel.getCrossover();
            MutatorBase<TravelingSalesPersonIndividual> mutator = mutSel.getMutator();
            model.createAlgorithm(graph, mutator, mu, lambda, crossover);
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }

        
    }
}
