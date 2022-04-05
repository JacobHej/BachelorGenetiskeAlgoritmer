using Algorithms;
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
    public partial class BitStringSelector : Form
    {
        BitStringSelectForm? BitString;

        public BitStringSelector(bool zero = true, bool random = true, bool custom = true)
        {
            InitializeComponent();
            if (zero)
            {
                BitStringSelectorBox.Items.Add("Zero BitString");
            }
            if (random)
            {
                BitStringSelectorBox.Items.Add("Random BitString");
            }
            if (custom)
            {
                BitStringSelectorBox.Items.Add("Custom BitString");
            }
            BitStringSelectorBox.SelectedIndex = 0;
        }

        private void BitStringSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BitStringScene.Controls.Clear();
            BitString = null;
            switch ((String)BitStringSelectorBox.SelectedItem)
            {
                case "Zero BitString":
                    BitString = new ZeroBitStringIndividual();
                    break;
                case "Random BitString":
                    BitString = new RandomBitStringIndividual();
                    break;
                case "Custom BitString":
                    BitString = new CustomBitStringIndividual();

                    break;
            }
            BitString.FormBorderStyle = FormBorderStyle.None;
            BitString.TopLevel = false;
            BitStringScene.Controls.Add(BitString);
            BitString.Show();
        }

        public Func<BitStringIndividual> GetBitStringCreator()
        {
            return BitString.GetBitStringCreator();
        }
    }
}
