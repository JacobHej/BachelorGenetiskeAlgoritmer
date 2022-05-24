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

namespace GeneticAlgorithms.CreateSimulationForms.TSPASRank
{
    public partial class TSPASRank : CreateSimulationForm
    {


        TSPSelector.TSPSelector TSPSel;
        VariableSelector.VariableSelector ASRank;

        public TSPASRank()
        {
            this.TSPSel = new TSPSelector.TSPSelector();

            ASRank = new VariableSelector.VariableSelector(new List<VariableSelector.VariableSelector.Variable>()
            {
                new VariableSelector.VariableSelector.doubleVariable("alpha",1),
                new VariableSelector.VariableSelector.doubleVariable("beta",5),
                new VariableSelector.VariableSelector.doubleVariable("p",0.5),
                new VariableSelector.VariableSelector.doubleVariable("q",100),
                new VariableSelector.VariableSelector.doubleVariable("initialPheromone",1),
                new VariableSelector.VariableSelector.intVariable("amount of ants",10),
                new VariableSelector.VariableSelector.intVariable("amount of ants picked",10)
            });

            Action setVariables = new Action(delegate ()
            {
                double n = TSPSel.getTSPProblem().Verticies.Count();
                ASRank.setVariable("amount of ants", n);
                ASRank.setVariable("amount of ants picked", n);
            });

            TSPSel.addListenerOnIndexChanged(
                setVariables
            );

            InitializeComponent();
            this.headline.Text = "TSP - ASRank";
            setVariables();
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            TSPASRankModel model = new TSPASRankModel();
            CoordinateGraph graph = TSPSel.getTSPProblem();

            model.createAlgorithm(graph,
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("alpha")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("beta")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("p")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("q")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("initialPheromone")).getValue(),
                ((VariableSelector.VariableSelector.intVariable)ASRank.getVariable("amount of ants")).getValue(),
                ((VariableSelector.VariableSelector.intVariable)ASRank.getVariable("amount of ants picked")).getValue()
            );
            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }

        
    }
}
