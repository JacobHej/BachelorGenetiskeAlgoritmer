﻿using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA
{
    public partial class BitStringMuPlusLambdaEA : CreateSimulationForm
    {

        BitStringSelector.BitStringSelector BitSel;
        MuPlusLambdaSelector.MuPlusLambdaSelector MPLSel;
        IFitnessCalculator<BitStringIndividual> problem;

        public BitStringMuPlusLambdaEA(IFitnessCalculator<BitStringIndividual> problem, string headlineText)
        {
            this.problem = problem;
            InitializeComponent();
            this.headline.Text = headlineText;
        }

        protected override void createAlgorithm_Click(object sender, EventArgs e)
        {
            BitStringMuPlusLambdaEAModel model = new BitStringMuPlusLambdaEAModel();
            int mu = MPLSel.getMu();
            int lambda = MPLSel.getLambda();
            double crossOver = MPLSel.getCrossover();
            Func<BitStringIndividual> bitLengthCreator = BitSel.GetBitStringCreator();
            model.createAlgorithm(problem, bitLengthCreator, mu, lambda, crossOver);
            BitManipV2 A_Form = new BitManipV2(model);
            A_Form.Show();
        }
    }
}
