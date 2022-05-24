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

namespace GeneticAlgorithms.CreateSimulationForms.TSPMMAS
{
    public partial class TSPMMAS : CreateSimulationForm
    {


        TSPSelector.TSPSelector TSPSel;
        VariableSelector.VariableSelector MMAS;

        public TSPMMAS()
        {
            this.TSPSel = new TSPSelector.TSPSelector();

            MMAS = new VariableSelector.VariableSelector(new List<VariableSelector.VariableSelector.Variable>()
            {
                new VariableSelector.VariableSelector.doubleVariable("alpha",1),
                new VariableSelector.VariableSelector.doubleVariable("beta",5),
                new VariableSelector.VariableSelector.doubleVariable("p",0.2),
                new VariableSelector.VariableSelector.doubleVariable("min",0.1),
                new VariableSelector.VariableSelector.doubleVariable("max",1),
                new VariableSelector.VariableSelector.doubleVariable("initialPheromone",1)
            });

            Action setVariables = new Action(delegate ()
            {
                double n = TSPSel.getTSPProblem().Verticies.Count();
                double min = 1 / Math.Pow(n, 2);
                double max = 1 - 1 / n;
                MMAS.setVariable("min", min);
                MMAS.setVariable("max", max);
            });

            TSPSel.addListenerOnIndexChanged(
                setVariables
            );

            InitializeComponent();
            this.headline.Text = "TSP - MMAS";
            setVariables();
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPMMASModel model = new TSPMMASModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();

            model.createAlgorithm(graph,
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("alpha")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("beta")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("p")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("min")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("max")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)MMAS.getVariable("initialPheromone")).getValue()
            );
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }

        
    }
}
