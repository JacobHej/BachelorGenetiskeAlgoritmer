using Algorithms;
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

namespace GeneticAlgorithms.CreateSimulationForms.BinValOnePlusOneEA
{
    public partial class BinValOnePlusOneEA : CreateSimulationForm
    {

        BitStringSelector.BitStringSelector BitStringSel;
        public BinValOnePlusOneEA()
        {
            InitializeComponent();
            this.headline.Text = "Binary Value - One Plus One EA";
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BinValOnePlusOneEAModel model = new BinValOnePlusOneEAModel();
            BitStringIndividual bitString = BitStringSel.GetBitString();
            model.createAlgorithm(bitString);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }
    }
}
