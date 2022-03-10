﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.LeadingOnesMuPlusLambdaEA
{
    public partial class LeadingOnesMuPlusLambdaEA : Form
    {
        int bitLength = 20;
        public LeadingOnesMuPlusLambdaEA()
        {
            InitializeComponent();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            LeadingOnesMuPlusLambdaEAModel model = new LeadingOnesMuPlusLambdaEAModel();
            model.createAlgorithm(bitLength);

            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();

        }



        private void bitLength_tb_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.bitLength_tb.Text) || this.bitLength_tb.Text.Any(c => !char.IsDigit(c)))
            {
                bitLength_tb.Text = "20";
                bitLength = 20;
            }
            else
            {
                bitLength = int.Parse(bitLength_tb.Text);
            }
        }

        private void bitLength_label_Click(object sender, EventArgs e)
        {

        }
    }
}
