namespace GeneticAlgorithms.CreateSimulationForms.BitStringSelector
{
    partial class ZeroBitStringIndividual
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
            this.BitStringLengthLabel = new System.Windows.Forms.Label();
            this.BitStringLengthInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //  BitStringLabel
            //
            this.BitStringLengthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BitStringLengthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BitStringLengthInput.Size = new System.Drawing.Size(400, 30);
            this.BitStringLengthLabel.Name = "BitStringLengthLabel";
            this.BitStringLengthLabel.TabIndex = 0;
            this.BitStringLengthLabel.Text = "Length of bitstring";
            //
            //  BitStringInput
            //
            this.BitStringLengthInput.Anchor = AnchorStyles.Top;
            this.BitStringLengthInput.Size = new System.Drawing.Size(400, 30);
            this.BitStringLengthInput.Location = new System.Drawing.Point(300, 30);
            this.BitStringLengthInput.Name = "BitStringLengthInput";
            this.BitStringLengthInput.Text = "10";
            this.BitStringLengthInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BitStringLengthInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.positiveIntCheckOnKeyPress);
            // 
            // RandomBitStringIndividual
            // 
            this.Dock = DockStyle.Fill;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.BitStringLengthLabel);
            this.Controls.Add(this.BitStringLengthInput);
            this.Name = "CustomBitStringIndividual";
            this.Text = "CustomBitStringIndividual";
            this.ResumeLayout(false);
        }

        protected Label BitStringLengthLabel;
        protected TextBox BitStringLengthInput;


        #endregion
    }
}