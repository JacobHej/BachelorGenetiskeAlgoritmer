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

namespace GeneticAlgorithms.CreateSimulationForms.SimulatedAnnealingSelector
{
    public partial class SimulatedAnnealingSelector : Form
    {
        public SimulatedAnnealingSelector()
        {
            InitializeComponent();
        }

        private void checkIfPositiveDoubleOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(sender is TextBox))
            {
                return;
            }
            TextBox textbox = sender as TextBox;
            if (e.KeyChar == '\b')
            {
                return;
            }
            try
            {
                string newText = textbox.Text + e.KeyChar.ToString();
                double value = double.Parse(newText, CultureInfo.InvariantCulture);

                if (value < 0)
                {
                    e.Handled = true;
                }
            }
            catch (Exception error)
            {
                e.Handled = true;
            }
        }

        public double getAlpha()
        {
            double alpha;
            try
            {
                alpha = double.Parse(alphaInput.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new Exception("alpha was not in double format");
            }
            if (alpha < 0)
            {
                throw new Exception("alpha was positive");
            }
            return alpha;
        }

        public double getStartTemp()
        {
            double StartTemp;
            try
            {
                StartTemp = double.Parse(startTempInput.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new Exception("alpha was not in double format");
            }
            if (StartTemp < 0)
            {
                throw new Exception("alpha was positive");
            }
            return StartTemp;
        }
    }
}
