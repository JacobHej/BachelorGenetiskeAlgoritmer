using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMutator
{
    public partial class PoissonTwoOptMutatorForm : TSPMutatorSelectForm
    {
        public PoissonTwoOptMutatorForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (this.textBox1.Text.IndexOf(".") >= 0 || this.textBox1.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            double value;
            if (!double.TryParse(textBox1.Text, out value)) { 
                textBox1.Text = ""; 
            }
        }

        
        public override MutatorBase<TravelingSalesPersonIndividual> GetMutator()
        {
            return new PoissonTwoOptMutator(double.Parse(textBox1.Text));
        }

    }
}
