using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.MuPlusLambdaSelector
{
    public partial class MuPlusLambdaSelector : Form
    {
        public MuPlusLambdaSelector()
        {
            InitializeComponent();
        }

        private void checkIfIntegerOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void checkIfBetween0And1OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(sender is TextBox))
            {
                return;
            }
            TextBox textbox = sender as TextBox;
            if (e.KeyChar=='\b')
            {
                return;
            }
            try
            {
                string newText = textbox.Text + e.KeyChar.ToString();
                double value = double.Parse(newText, CultureInfo.InvariantCulture);

                if (value>1||value<0)
                {
                    e.Handled=true;
                }
            }
            catch(Exception error)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!(sender is TextBox))
            {
                return;
            }
            TextBox textbox = sender as TextBox;
            double value;
            if (!double.TryParse(textbox.Text, out value))
            {
                textbox.Text = "";
            }
        }

        public int getMu()
        {
            return int.Parse(muInput.Text);
        }

        public int getLambda()
        {
            return int.Parse(lambdaInput.Text);
        }

        public double getCrossover()
        {
            return double.Parse(crossoverInput.Text);
        }
    }
}
