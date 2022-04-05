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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringSimulatedAnnealing
{
    public partial class BitStringSimulatedAnnealing : CreateSimulationForm
    {

        BitStringSelector.BitStringSelector BitStringSel;
        SimulatedAnnealingSelector.SimulatedAnnealingSelector SimAnSel;
        IFitnessCalculator<BitStringIndividual> problem;
        public BitStringSimulatedAnnealing(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            this.problem = problem;
            InitializeComponent();
            this.headline.Text = "Binary Value - One Plus One EA";
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringSimulatedAnnealingModel model = new BitStringSimulatedAnnealingModel();
            Func<BitStringIndividual> bitStringCreator = BitStringSel.GetBitStringCreator();
            double starttemp = SimAnSel.getStartTemp();
            double alpha = SimAnSel.getAlpha();
            model.createAlgorithm(problem, bitStringCreator,starttemp,alpha);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }
    }
}
