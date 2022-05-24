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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringASRank
{
    public partial class BitStringASRank : CreateSimulationForm
    {


        VariableSelector.VariableSelector ASRank;
        BitStringSelector.RandomBitStringIndividual BitSel;
        IFitnessCalculator<BitStringIndividual> problem;

        public BitStringASRank(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            BitSel = new BitStringSelector.RandomBitStringIndividual();
            ASRank = new VariableSelector.VariableSelector(new List<VariableSelector.VariableSelector.Variable>()
            {
                new VariableSelector.VariableSelector.doubleVariable("p",0.9),
                new VariableSelector.VariableSelector.doubleVariable("q",1),
                new VariableSelector.VariableSelector.doubleVariable("initialPheromone",1),
                new VariableSelector.VariableSelector.intVariable("amount of ants",1),
                new VariableSelector.VariableSelector.intVariable("amount of ants picked",1)
            });
            this.problem = problem;


            Action setVariables = new Action(delegate ()
            {
                double n = BitSel.getBitLength();
                int antAmount = (int)Math.Log10(n)+5;
                ASRank.setVariable("q", n);
                ASRank.setVariable("amount of ants", antAmount);
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
            BitStringASRankModel model = new BitStringASRankModel();
            int bitLength = BitSel.getBitLength();

            model.createAlgorithm(problem, bitLength,
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("p")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("q")).getValue(),
                ((VariableSelector.VariableSelector.doubleVariable)ASRank.getVariable("initialPheromone")).getValue(),
                ((VariableSelector.VariableSelector.intVariable)ASRank.getVariable("amount of ants")).getValue(),
                ((VariableSelector.VariableSelector.intVariable)ASRank.getVariable("amount of ants picked")).getValue()
            );
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }


    }
}
