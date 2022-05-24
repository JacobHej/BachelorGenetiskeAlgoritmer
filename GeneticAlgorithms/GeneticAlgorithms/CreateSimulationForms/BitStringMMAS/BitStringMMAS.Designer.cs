using GeneticAlgorithms.CreateSimulationForms.TSPMutator;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringMMAS
{
    partial class BitStringMMAS
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
            //BitStringSelector
            BitSel.FormBorderStyle = FormBorderStyle.None;
            BitSel.TopLevel = false;
            this.selectables.Controls.Add(BitSel, 0, 0);
            BitSel.Show();
            //ACO SELECTOR
            ASRank.FormBorderStyle = FormBorderStyle.None;
            ASRank.TopLevel = false;
            this.selectables.Controls.Add(ASRank, 1, 0);
            ASRank.Show();


            this.Dock = DockStyle.Fill;
            this.Name = "TSPMuPlusLambda";
            this.Text = "TSPMuPlusLambda";
            this.ResumeLayout(false);
        }

        #endregion
    }
}