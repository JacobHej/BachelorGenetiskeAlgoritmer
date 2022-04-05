namespace GeneticAlgorithms.CreateSimulationForms.BitStringMuPlusLambdaEA
{
    partial class BitStringMuPlusLambdaEA
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
            //BitSel
            BitSel = new BitStringSelector.BitStringSelector();
            BitSel.FormBorderStyle = FormBorderStyle.None;
            BitSel.TopLevel = false;
            this.selectables.Controls.Add(BitSel, 0, 0);
            BitSel.Show();
            //MuPlusLambda
            MPLSel = new MuPlusLambdaSelector.MuPlusLambdaSelector();
            MPLSel.FormBorderStyle = FormBorderStyle.None;
            MPLSel.TopLevel = false;
            this.selectables.Controls.Add(MPLSel, 1, 0);
            MPLSel.Show();
            
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