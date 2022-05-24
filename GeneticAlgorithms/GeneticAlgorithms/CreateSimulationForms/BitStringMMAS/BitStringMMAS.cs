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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMMAS
{
    public partial class BitStringMMAS : CreateSimulationForm
    {


        VariableSelector.VariableSelector ASRank;
        BitStringSelector.RandomBitStringIndividual BitSel;
        IFitnessCalculator<BitStringIndividual> problem;

        public BitStringMMAS(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            BitSel = new BitStringSelector.RandomBitStringIndividual();
            ASRank = new VariableSelector.VariableSelector(new List<VariableSelector.VariableSelector.Variable>()
            {
                new VariableSelector.VariableSelector.doubleVariable("p",0.2),
                new VariableSelector.VariableSelector.doubleVariable("min",1),
                new VariableSelector.VariableSelector.doubleVariable("max",1),
                new VariableSelector.VariableSelector.doubleVariable("initialPheromone",1)
            });
            this.problem = problem;

            Action setVariables = new Action(delegate ()
            {
                double n = BitSel.getBitLength();
                double min = 1 / n;
                double max = 1- (1 / n);
                int antAmount = (int)Math.Log10(n) + 5;
                ASRank.setVariable("min", min);
                ASRank.setVariable("max", max);
            });

            BitSel.addListenerOnBitsChange(
                setVariables
            );

            setVariables();

            InitializeComponent();
            this.headline.Text = headlineText;
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringMMASModel model = new BitStringMMASModel();
            int bitLength = BitSel.getBitLength();

            model.createAlgorithm(problem, bitLength,
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("p")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("min")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("max")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("initialPheromone")).getValue()
            );
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }


    }
}
