namespace GeneticAlgorithms.CreateSimulationForms
{
    partial class CreateSimulationForm
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
            this.headline = new System.Windows.Forms.Label();
            this.createAlgorithm = new System.Windows.Forms.Button();
            this.selectables = new TableLayoutPanel();
            this.SuspendLayout();
            // 
            // headline
            // 
            this.headline.Anchor = AnchorStyles.Top;
            this.headline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headline.Location = new System.Drawing.Point(300, 0);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(400, 50);
            this.headline.TabIndex = 0;
            this.headline.Text = "INSERT HEADLINE HERE";
            this.headline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //  selectables SHOULD BE SPECIFIED IN INHERTING CLASS
            //
            this.selectables.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            this.selectables.Size = new System.Drawing.Size(1000, 300);
            this.selectables.Location = new System.Drawing.Point(0,100);
            this.selectables.TabIndex = 100;
            // 
            // createAlgorithm
            // 
            this.createAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createAlgorithm.Location = new System.Drawing.Point(450, 400);
            this.createAlgorithm.Name = "createAlgorithm";
            this.createAlgorithm.Size = new System.Drawing.Size(100, 50);
            this.createAlgorithm.TabIndex = 10;
            this.createAlgorithm.Text = "Create";
            this.createAlgorithm.Click += new System.EventHandler(this.createAlgorithm_Click);
            // 
            // CreateSimulationForm
            // 
            this.Dock = DockStyle.Fill;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.headline);
            this.Controls.Add(this.selectables);
            this.Controls.Add(this.createAlgorithm);
            this.Resize += new EventHandler(this.ContentResized);
            this.Name = "CreateSimulationForm";
            this.Text = "CreateSimulationForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected TableLayoutPanel selectables;
        protected Label headline;
        protected Button createAlgorithm;
    }
}