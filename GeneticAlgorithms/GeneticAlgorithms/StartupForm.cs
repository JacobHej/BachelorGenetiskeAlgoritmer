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

        private async void test_btn_Click(object sender, EventArgs e)
        {
            //TestModels.TSPTestModel model = new TestModels.TSPTestModel();
            //model.createAlgorithm();
            //TSPManipV2 A_Form = new TSPManipV2(model);
            //A_Form.Show();

            BenchmarkModel model = new BenchmarkModel(@"C:\Users\Jacob Hejlsberg\Desktop\BachelorGenetiskeAlgoritmer\GeneticAlgorithms\BenchmarkOutPutFolder");
            await model.ErikTest();
            //await model.OnePlusOneEA_OneMax_OneOverN();
            //await model.OnePlusOneEA_OneMax_OneOverNX();
            //await model.OnePlusOneEA_LeadingOnes_OneOverN();
            //await model.OnePlusOneEA_LeadingOnes_OneOverNX();
            //await model.OnePlusOneEA_BinVal_OneOverN();
            //await model.OnePlusOneEA_BinVal_OneOverNX();
            //await model.OnePlusOneEA_TSP_TwoOpt();
            //await model.OnePlusOneEA_TSP_TwoOptPoisson2();
            //await model.OnePlusOneEA_TSP_TwoOptPoisson2_1And5MilIterations();
            //await model.SimulatedAnnealing_OneMax_ALL();
            //await model.SimulatedAnnealing_LeadingOnes_ALL();
            //await model.SimulatedAnnealing_BinVal_ALL();
            //await model.SimulatedAnnealing_TSP_ALL();



           
        }
    }
}
