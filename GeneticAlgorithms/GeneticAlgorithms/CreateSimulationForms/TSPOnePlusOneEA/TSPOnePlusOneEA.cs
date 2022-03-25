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

namespace GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA
{
    public partial class TSPOnePlusOneEA : CreateSimulationForm
    {

        TSPSelector.TSPSelector TSPSel;
        TSPMutator.TSPMutatorSelector mutSel;
        public TSPOnePlusOneEA()
        {
            InitializeComponent();
            this.headline.Text = "TSP - One Plus One EA";
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPOnePlusOneEAModel model = new TSPOnePlusOneEAModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();
            MutatorBase<TravelingSalesPersonIndividual> mutator = mutSel.getMutator();
            model.createAlgorithm(graph,mutator);
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }
    }
}
