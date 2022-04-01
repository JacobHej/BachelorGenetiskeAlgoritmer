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
            //BitStringLength
            BitLengthSel = new BitStringSelector.RandomBitStringIndividual();
            BitLengthSel.FormBorderStyle = FormBorderStyle.None;
            BitLengthSel.TopLevel = false;
            this.selectables.Controls.Add(BitLengthSel, 0, 0);
            BitLengthSel.Show();
            //MuPlusLambda
            MPLSel = new MuPlusLambdaSelector.MuPlusLambdaSelector();
            MPLSel.FormBorderStyle = FormBorderStyle.None;
            MPLSel.TopLevel = false;
            this.selectables.Controls.Add(MPLSel, 1, 0);
            MPLSel.Show();
            
            this.selectables.Name = "selectables";
            this.selectables.RowCount = 1;
            this.selectables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formatter.TabIndex = 0;

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