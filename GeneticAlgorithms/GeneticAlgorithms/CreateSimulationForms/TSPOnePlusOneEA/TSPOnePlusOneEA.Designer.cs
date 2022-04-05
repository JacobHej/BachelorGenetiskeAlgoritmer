using GeneticAlgorithms.CreateSimulationForms.TSPMutator;

namespace GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA
{
    partial class TSPOnePlusOneEA
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
            this.selectables.ColumnCount = 2;
            this.selectables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.selectables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //TSP SELECTOR
            TSPSel = new TSPSelector.TSPSelector();
            TSPSel.FormBorderStyle = FormBorderStyle.None;
            TSPSel.TopLevel = false;
            this.selectables.Controls.Add(TSPSel,0,0);
            TSPSel.Show();
            //TSP MUTATOR SELECTOR
            mutSel = new TSPMutatorSelector();
            mutSel.FormBorderStyle = FormBorderStyle.None;
            mutSel.TopLevel = false;
            this.selectables.Controls.Add(mutSel,1,0);
            mutSel.Show();
            this.selectables.Name = "selectables";
            this.selectables.RowCount = 1;
            this.selectables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // 
            // TSPOnePlusOneEA
            // 
            this.Name = "TSPOnePlusOneEA";
            this.Text = "TSPOnePlusOneEA";
            this.ResumeLayout(false);

        }

        #endregion
    }
}