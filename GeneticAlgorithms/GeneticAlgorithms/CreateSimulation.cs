using Algorithms;
using Algorithms.BitStuff;
using GeneticAlgorithms.CreateSimulationForms;
using GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA;
using GeneticAlgorithms.CreateSimulationForms.BitStringOnePlusOneEA;
using GeneticAlgorithms.CreateSimulationForms.BitStringSimulatedAnnealing;
using GeneticAlgorithms.CreateSimulationForms.TSPACO;
using GeneticAlgorithms.CreateSimulationForms.TSPMuPlusLambdaEA;
using GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA;
using GeneticAlgorithms.CreateSimulationForms.TSPSimulatedAnnealing;
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
    public partial class CreateSimulation : Form
    {
        public CreateSimulation()
        {
            InitializeComponent();
            this.Width = 1800;
            this.Height = 800;
        }

        private void startOver_btn_Click(object sender, EventArgs e)
        {
            CreateSimulation form = new CreateSimulation();
            this.Close();
            form.Show();
            this.Dispose();
        }


        private void problem_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePanel();
        }

        private void solution_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePanel();
        }


        private void ContentResized(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            panel1.Location = new Point(0, panel1.Location.Y);
        }

        private void ChangePanel()
        {
            CreateSimulationForm frm;
            switch (problem_box.SelectedIndex, solution_box.SelectedIndex)
            {

                case (0, 0)://
                    frm = new BitStringOnePlusOneEA(new OneMaxFitnessCalculator(), "OneMax - One Plus One");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (1, 0)://
                    frm = new BitStringOnePlusOneEA(new LeadingOnesFitnessCalculator(), "Leading Ones - One Plus One");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (2, 0)://
                    frm = new BitStringOnePlusOneEA(new BinValFitnessCalculator(), "Binary Value - One Plus One");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (3, 0)://
                    frm = new TSPOnePlusOneEA();
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (0, 1)://OneMaxMuPlusLambda
                    frm = new BitStringMuPlusLambdaEA(new OneMaxFitnessCalculator(), "OneMax - Mu Plus Lambda");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (1, 1)://LeadingOnesMuPlusLambda
                    frm = new BitStringMuPlusLambdaEA(new LeadingOnesFitnessCalculator(), "Leading Ones - Mu Plus Lambda");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (2, 1)://Binval MuPlusLambda
                    frm = new BitStringMuPlusLambdaEA(new BinValFitnessCalculator(), "Binary Value - Mu Plus Lambda");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (3, 1)://TSP MuPlusLambda
                    frm = new TSPMuPlusLambdaEA();
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (0, 2)://OneMaxSimAn
                    frm = new BitStringSimulatedAnnealing(new OneMaxFitnessCalculator(), "OneMax - Simulated Annealing");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (1, 2)://LeadingOnesSimAn
                    frm = new BitStringSimulatedAnnealing(new LeadingOnesFitnessCalculator(), "Leading Ones - Simulated Annealing");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (2, 2)://Binval SimAn
                    frm = new BitStringSimulatedAnnealing(new BinValFitnessCalculator(), "Binary Value - Simulated Annealing");
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (3, 2)://TSP SimAn
                    frm = new TSPSimulatedAnnealing();
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                case (3, 3)://TSP RBACO
                    frm = new TSPACO();
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(frm);
                    frm.Show();
                    break;
                default:
                    panel1.Controls.Clear();
                    break;
            }
        }
    }
}
