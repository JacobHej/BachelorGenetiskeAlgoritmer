namespace GeneticAlgorithms.CreateSimulationForms.BitStringSelector
{
    partial class CustomBitStringIndividual
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
            this.BitStringLabel = new System.Windows.Forms.Label();
            this.BitStringInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //  BitStringLabel
            //
            this.BitStringLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BitStringLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BitStringInput.Size = new System.Drawing.Size(400, 30);
            this.BitStringLabel.Name = "BitStringLabel";
            this.BitStringLabel.TabIndex = 0;
            this.BitStringLabel.Text = "Custom Bitstring";
            //
            //  BitStringInput
            //
            this.BitStringInput.Anchor = AnchorStyles.Top;
            this.BitStringInput.Size = new System.Drawing.Size(400, 30);
            this.BitStringInput.Location = new System.Drawing.Point(300, 30);
            this.BitStringInput.Name = "BitStringInput";
            this.BitStringInput.Text = "0011001100";
            this.BitStringInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BitStringInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bitStringCheckOnKeyPress);
            // 
            // CustomBitStringIndividual
            // 
            this.Dock = DockStyle.Fill;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.BitStringLabel);
            this.Controls.Add(this.BitStringInput);
            this.Name = "CustomBitStringIndividual";
            this.Text = "CustomBitStringIndividual";
            this.ResumeLayout(false);
        }


        private Label BitStringLabel;
        private TextBox BitStringInput;

        #endregion
    }
}