using GeneticAlgorithms.CreateSimulationForms.TSPMutator;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMMAS
{
    partial class TSPMMAS
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
            this.selectables.Name = "selectables";
            this.selectables.RowCount = 1;
            this.selectables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //TSP SELECTOR
            TSPSel.FormBorderStyle = FormBorderStyle.None;
            TSPSel.TopLevel = false;
            this.selectables.Controls.Add(TSPSel, 0, 0);
            TSPSel.Show();
            //MMAS SELECTOR
            MMAS.FormBorderStyle = FormBorderStyle.None;
            MMAS.TopLevel = false;
            this.selectables.Controls.Add(MMAS, 1, 0);
            MMAS.Show();

            this.Dock = DockStyle.Fill;
            this.Name = "TSPMuPlusLambda";
            this.Text = "TSPMuPlusLambda";
            this.ResumeLayout(false);
        }

        #endregion
    }
}