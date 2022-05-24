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

namespace GeneticAlgorithms.CreateSimulationForms.VariableSelector
{
    public partial class VariableSelector : Form
    {



        public List<Variable> variables = new List<Variable>()
        {
            new intVariable("cock",1)
        };
        public Dictionary<string, Label> labels = new Dictionary<string, Label>();
        public Dictionary<string, TextBox> inputs = new Dictionary<string, TextBox>();

        public abstract class Variable {
            public Variable(string name) { 
                this.name = name;
            }

            public abstract void onChange();

            public string name;
            public TextBox input;
            public Label label;
        }

        public class intVariable : Variable
        {
            public intVariable(string name, int value) : base(name)
            {
                this.name = name;
                this.value = value;
            }
            public int value;


            public override void onChange()
            {
                try
                {
                    string newText = input.Text;
                    int value = int.Parse(newText, CultureInfo.InvariantCulture);
                    this.value = value;
                    return;
                }
                catch (Exception error)
                {
                    throw new Exception("variableInput" + name + "didnt hold an int");
                }
            }

            public int getValue()
            {
                return value;
            }
        }

        public class doubleVariable : Variable
        {
            public doubleVariable(string name, double value) : base(name)
            {
                this.name = name;
                this.value = value;
            }

            public double value;

            public override void onChange()
            {
                try
                {
                    string newText = input.Text;
                    newText = newText.Replace(',', '.');
                    double value = double.Parse(newText, CultureInfo.InvariantCulture);
                    this.value = value;
                    return;
                }
                catch (Exception error)
                {
                    throw new Exception("variableInput" + name + "didnt hold a double");
                }
            }

            public double getValue()
            {
                return value;
            }
        }




        public VariableSelector()
        {
            InitializeComponent();
        }

        public VariableSelector(List<Variable> variables)
        {
            this.variables = variables;
            InitializeComponent();
        }

        private void checkIfIntegerOnKeyPress(object sender, KeyPressEventArgs e)
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
                int value = int.Parse(newText, CultureInfo.InvariantCulture);
            }
            catch (Exception error)
            {
                e.Handled = true;
            }
        }

        private void checkIfDoubleOnKeyPress(object sender, KeyPressEventArgs e)
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
            }
            catch (Exception error)
            {
                e.Handled = true;
            }
        }

        private void checkIfBetweenxAndyOnKeyPress(object sender, KeyPressEventArgs e, double x, double y)
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

                if (value>y||value<x)
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

        public Variable getVariable(String s)
        {
            IEnumerable<Variable> matches = variables.Where(v => v.name == s);
            if (matches.Count() != 1)
            {
                throw new Exception("Doesnt exist or exists multiple times");
            }
            else
            {
                return matches.First();
            }
        }

        public void setVariable(String variableName,double value)
        {
            IEnumerable<Variable> matches = variables.Where(v => v.name == variableName);
            if (matches.Count() != 1)
            {
                throw new Exception("Doesnt exist or exists multiple times");
            }
            else
            {
                switch (matches.First())
                {
                    case doubleVariable v:
                        v.input.Text = value + "";
                        v.value = value;
                        break;
                    case intVariable v:
                        v.input.Text = (int)value + "";
                        v.value = (int)value;
                        break;
                }
            }
        }
    }
}
