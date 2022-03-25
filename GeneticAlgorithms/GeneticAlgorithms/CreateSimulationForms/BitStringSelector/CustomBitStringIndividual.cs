using Algorithms;
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

namespace GeneticAlgorithms.CreateSimulationForms.BitStringSelector
{
    public partial class CustomBitStringIndividual : BitStringSelectForm
    {
        public CustomBitStringIndividual()
        {
            InitializeComponent();
        }

        public override BitStringIndividual GetBitString()
        {
            return new BitStringIndividual(new BitString(BitStringInput.Text));
        }

        private  Boolean isBitString(string text)
        {
            return text.ToCharArray().All(c => c == '0' || c == '1');
        }

        private void bitStringCheckOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(sender is TextBox))
            {
                return;
            }
            TextBox textbox = sender as TextBox;
            string newText = textbox.Text + e.KeyChar.ToString();
            if (e.KeyChar == '\b')
            {
                if (textbox.Text.Length == 1)
                {
                    textbox.Text = "1";
                }
                return;
            }
            e.Handled = !isBitString(newText);
        }
    }
}
