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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringOnePlusOneEA
{
    public partial class BitStringOnePlusOneEA : CreateSimulationForm
    {

        BitStringSelector.BitStringSelector BitStringSel;
        IFitnessCalculator<BitStringIndividual> problem;
        public BitStringOnePlusOneEA(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            this.problem = problem;
            InitializeComponent();
            this.headline.Text = headlineText;
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringOnePlusOneEAModel model = new BitStringOnePlusOneEAModel();
            Func<BitStringIndividual> bitStringCreator = BitStringSel.GetBitStringCreator();
            model.createAlgorithm(problem, bitStringCreator);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }
    }
}
