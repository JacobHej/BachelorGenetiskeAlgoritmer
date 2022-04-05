namespace GeneticAlgorithms.CreateSimulationForms.SimulatedAnnealingSelector
{
    partial class SimulatedAnnealingSelector
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
            this.startTemp = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.Label();
            this.startTempInput = new System.Windows.Forms.TextBox();
            this.alphaInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mu
            // 
            this.startTemp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startTemp.AutoSize = true;
            this.startTemp.Location = new System.Drawing.Point(350, 0);
            this.startTemp.MinimumSize = new System.Drawing.Size(150, 20);
            this.startTemp.Name = "startTemp";
            this.startTemp.Size = new System.Drawing.Size(150, 20);
            this.startTemp.TabIndex = 0;
            this.startTemp.Text = "Start Temperature";
            this.startTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alpha
            // 
            this.alpha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.alpha.AutoSize = true;
            this.alpha.Location = new System.Drawing.Point(500, 0);
            this.alpha.MinimumSize = new System.Drawing.Size(150, 20);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(150, 20);
            this.alpha.TabIndex = 0;
            this.alpha.Text = "Alpha";
            this.alpha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startTempInput
            // 
            this.startTempInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startTempInput.Location = new System.Drawing.Point(350, 50);
            this.startTempInput.Name = "startTempInput";
            this.startTempInput.Size = new System.Drawing.Size(150, 30);
            this.startTempInput.TabIndex = 0;
            this.startTempInput.Text = "1";
            this.startTempInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTempInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfPositiveDoubleOnKeyPress);
            // 
            // alphaInput
            // 
            this.alphaInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.alphaInput.Location = new System.Drawing.Point(500, 50);
            this.alphaInput.Name = "alphaInput";
            this.alphaInput.Size = new System.Drawing.Size(150, 30);
            this.alphaInput.TabIndex = 0;
            this.alphaInput.Text = "0.9";
            this.alphaInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alphaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfPositiveDoubleOnKeyPress);
            // 
            // MuPlusLambdaSelector
            // 
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.startTemp);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.startTempInput);
            this.Controls.Add(this.alphaInput);
            this.Name = "MuPlusLambdaSelector";
            this.Text = "MuPlusLambdaSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label startTemp;
        private Label alpha;
        private TextBox startTempInput;
        private TextBox alphaInput;
    }
}