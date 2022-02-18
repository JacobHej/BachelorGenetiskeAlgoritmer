using GeneticAlgorithms.CreateSimulationForms;
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
            
            switch (problem_box.SelectedIndex, solution_box.SelectedIndex)
            {
                
                case (0, 0)://
                    OneMaxOnePlusOneEA frm = new OneMaxOnePlusOneEA();
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
