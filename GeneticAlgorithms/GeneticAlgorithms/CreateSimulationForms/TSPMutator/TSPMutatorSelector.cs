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
    public partial class TSPMutatorSelector : Form
    {
        TSPMutatorSelectForm MUTATOR;
        public TSPMutatorSelector()
        {
            InitializeComponent();
            MutatorSelector.Items.Add("TwoOptMutator");
            MutatorSelector.Items.Add("PoissonTwoOptMutator");
            MutatorSelector.SelectedIndex = 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MutatorSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            MutatorScene.Controls.Clear();
            MUTATOR = null;
            switch ((String)MutatorSelector.SelectedItem)
            {
                case "TwoOptMutator":
                    MUTATOR = new TwoOptMutatorForm();
                    break;
                case "PoissonTwoOptMutator":
                    MUTATOR = new PoissonTwoOptMutatorForm();
                    
                    break;
            }
            MUTATOR.FormBorderStyle = FormBorderStyle.None;
            MUTATOR.TopLevel = false;
            MutatorScene.Controls.Add(MUTATOR);
            MUTATOR.Show();


        }

        public MutatorBase<TravelingSalesPersonIndividual> getMutator()
        {
            if(MUTATOR == null)
            {
                return null;
            }
            return MUTATOR.GetMutator();
        }
    }
}
