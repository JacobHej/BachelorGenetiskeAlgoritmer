namespace GeneticAlgorithms.CreateSimulationForms.MuPlusLambdaSelector
{
    partial class MuPlusLambdaSelector
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
            this.mu = new System.Windows.Forms.Label();
            this.lambda = new System.Windows.Forms.Label();
            this.crossover = new System.Windows.Forms.Label();
            this.muInput = new System.Windows.Forms.TextBox();
            this.lambdaInput = new System.Windows.Forms.TextBox();
            this.crossoverInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mu
            // 
            this.mu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mu.AutoSize = true;
            this.mu.Location = new System.Drawing.Point(464, 0);
            this.mu.MinimumSize = new System.Drawing.Size(150, 20);
            this.mu.Name = "mu";
            this.mu.Size = new System.Drawing.Size(150, 20);
            this.mu.TabIndex = 0;
            this.mu.Text = "Mu";
            this.mu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lambda
            // 
            this.lambda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lambda.AutoSize = true;
            this.lambda.Location = new System.Drawing.Point(614, 0);
            this.lambda.MinimumSize = new System.Drawing.Size(150, 20);
            this.lambda.Name = "lambda";
            this.lambda.Size = new System.Drawing.Size(150, 20);
            this.lambda.TabIndex = 0;
            this.lambda.Text = "Lambda";
            this.lambda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // crossover
            // 
            this.crossover.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.crossover.AutoSize = true;
            this.crossover.Location = new System.Drawing.Point(764, 0);
            this.crossover.MinimumSize = new System.Drawing.Size(150, 20);
            this.crossover.Name = "crossover";
            this.crossover.Size = new System.Drawing.Size(150, 20);
            this.crossover.TabIndex = 0;
            this.crossover.Text = "Crossover";
            this.crossover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // muInput
            // 
            this.muInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.muInput.Location = new System.Drawing.Point(464, 50);
            this.muInput.Name = "muInput";
            this.muInput.Size = new System.Drawing.Size(150, 27);
            this.muInput.TabIndex = 0;
            this.muInput.Text = "10";
            this.muInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.muInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfIntegerOnKeyPress);
            // 
            // lambdaInput
            // 
            this.lambdaInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lambdaInput.Location = new System.Drawing.Point(614, 50);
            this.lambdaInput.Name = "lambdaInput";
            this.lambdaInput.Size = new System.Drawing.Size(150, 27);
            this.lambdaInput.TabIndex = 0;
            this.lambdaInput.Text = "10";
            this.lambdaInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lambdaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfIntegerOnKeyPress);
            // 
            // crossoverInput
            // 
            this.crossoverInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.crossoverInput.Location = new System.Drawing.Point(764, 50);
            this.crossoverInput.Name = "crossoverInput";
            this.crossoverInput.Size = new System.Drawing.Size(150, 27);
            this.crossoverInput.TabIndex = 0;
            this.crossoverInput.Text = "0.0";
            this.crossoverInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.crossoverInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfBetween0And1OnKeyPress);
            // 
            // MuPlusLambdaSelector
            // 
            this.ClientSize = new System.Drawing.Size(1378, 578);
            this.Controls.Add(this.mu);
            this.Controls.Add(this.lambda);
            this.Controls.Add(this.crossover);
            this.Controls.Add(this.muInput);
            this.Controls.Add(this.lambdaInput);
            this.Controls.Add(this.crossoverInput);
            this.Name = "MuPlusLambdaSelector";
            this.Text = "MuPlusLambdaSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label mu;
        private Label lambda;
        private Label crossover;
        private TextBox muInput;
        private TextBox lambdaInput;
        private TextBox crossoverInput;
    }
}