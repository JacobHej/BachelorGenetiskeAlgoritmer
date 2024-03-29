﻿using Algorithms;
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
    public partial class RandomBitStringIndividual : BitStringSelectForm
    {
        public RandomBitStringIndividual()
        {
            InitializeComponent();
        }

        private Boolean isPositiveInt(string text)
        {
            try
            {
                int x = int.Parse(text);
                if (x>0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void positiveIntCheckOnKeyPress(object sender, KeyPressEventArgs e)
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
            e.Handled = !isPositiveInt(newText);
        }

        public override Func<BitStringIndividual> GetBitStringCreator()
        {
            try
            {
                int x = int.Parse(BitStringLengthInput.Text);
                if (x > 0)
                {
                    return () => new BitStringIndividual(BitString.getRandomBitString(x));
                }
                throw new ArgumentException("bit string length was not positve");
            }
            catch (Exception)
            {
                throw new ArgumentException("bit string length was not integer");
            }
            
        }

        public int getBitLength()
        {
            try
            {
                int x = int.Parse(BitStringLengthInput.Text);
                if (x > 0)
                {
                    return x;
                }
                throw new ArgumentException("bit string length was not positve");
            }
            catch (Exception)
            {
               throw new ArgumentException("bit string length was not integer");
            }
        }


        public override void addListenerOnBitsChange(Action action)
        {
            this.BitStringLengthInput.TextChanged += new EventHandler((obj, e) => action());
        }
    }
}
