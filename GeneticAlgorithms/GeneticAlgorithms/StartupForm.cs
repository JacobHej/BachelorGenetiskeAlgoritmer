using Algorithms;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void createNewSimulation_btn_Click(object sender, EventArgs e)
        {
            CreateSimulation form = new CreateSimulation();
            form.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            SimpleBitStringAlgorithmModel a = new SimpleBitStringAlgorithmModel();
            a.createAlgorithm<OnePlusOneEaAlgorithm<BitStringIndividual>>(1,2);
        }
    }
}
