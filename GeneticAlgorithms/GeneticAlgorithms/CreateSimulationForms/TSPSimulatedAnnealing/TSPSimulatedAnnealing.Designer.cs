
using GeneticAlgorithms.CreateSimulationForms.TSPMutator;

namespace GeneticAlgorithms.CreateSimulationForms.TSPSimulatedAnnealing
{
    partial class TSPSimulatedAnnealing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // selectables
            //
            this.selectables.ColumnCount = 3;
            this.selectables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.selectables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.selectables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.selectables.Name = "selectables";
            this.selectables.RowCount = 1;
            this.selectables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //TSP SELECTOR
            this.TSPSel = new TSPSelector.TSPSelector();
            TSPSel.FormBorderStyle = FormBorderStyle.None;
            TSPSel.TopLevel = false;
            this.selectables.Controls.Add(TSPSel, 0, 0);
            TSPSel.Show();
            //TSP MUTATOR SELECTOR
            mutSel = new TSPMutatorSelector();
            mutSel.FormBorderStyle = FormBorderStyle.None;
            mutSel.TopLevel = false;
            this.selectables.Controls.Add(mutSel, 1, 0);
            mutSel.Show();
            //SIMULATED ANNEALING SELECTOR
            SimAnSel = new SimulatedAnnealingSelector.SimulatedAnnealingSelector();
            SimAnSel.FormBorderStyle = FormBorderStyle.None;
            SimAnSel.TopLevel = false;
            this.selectables.Controls.Add(SimAnSel, 2, 0);
            SimAnSel.Show();

            this.Dock = DockStyle.Fill;
            this.Name = "TSPSimulatedAnnealing";
            this.Text = "TSPSimulatedAnnealing";
            this.ResumeLayout(false);

        }

        #endregion
    }
}