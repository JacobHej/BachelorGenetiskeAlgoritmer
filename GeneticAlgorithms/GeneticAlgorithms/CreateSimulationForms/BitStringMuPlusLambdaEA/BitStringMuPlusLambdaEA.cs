using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA
{
    public partial class BitStringMuPlusLambdaEA : CreateSimulationForm
    {

        BitStringSelector.RandomBitStringIndividual BitLengthSel;
        MuPlusLambdaSelector.MuPlusLambdaSelector MPLSel;
        IFitnessCalculator<BitStringIndividual> problem;

        public BitStringMuPlusLambdaEA(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            this.problem = problem;
            InitializeComponent();
            this.headline.Text = headlineText;
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringMuPlusLambdaEAModel model = new BitStringMuPlusLambdaEAModel();
            int mu = MPLSel.getMu();
            int lambda = MPLSel.getMu();
            double crossOver = MPLSel.getCrossover();
            int bitLength = BitLengthSel.GetBitStringLength();
            model.createAlgorithm(problem,bitLength, mu, lambda, crossOver);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }
    }
}
