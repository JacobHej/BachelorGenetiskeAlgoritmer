using Algorithms;
using Algorithms.BitStuff;
using GeneticAlgorithms.CreateSimulationForms;
using GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA;
using GeneticAlgorithms.CreateSimulationForms.BitStringOnePlusOneEA;
using GeneticAlgorithms.CreateSimulationForms.TSPMuPlusLambdaEA;
using GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA;
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

            this.Width = 1600;
            this.Height = 1000;
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
                default:
                    panel1.Controls.Clear();
                    break;
            }
        }
    }
}
