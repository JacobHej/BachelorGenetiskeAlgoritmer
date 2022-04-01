namespace GeneticAlgorithms.CreateSimulationForms.TSPSelector
{
    partial class TSPSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSPSelector));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bitLength_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Size = new System.Drawing.Size(150, 30);
            this.comboBox1.Location = new System.Drawing.Point(425,30);
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DataSource = new List<string>(ResourceManager.tspFiles.Keys);

            // 
            // bitLength_label
            // 
            this.bitLength_label.Location = new System.Drawing.Point(425, 0);
            this.bitLength_label.Size = new System.Drawing.Size(150, 30);
            this.bitLength_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bitLength_label.TextAlign = ContentAlignment.MiddleCenter;
            this.bitLength_label.AutoSize = true;
            this.bitLength_label.Name = "bitLength_label";
            this.bitLength_label.TabIndex = 0;
            this.bitLength_label.Text = "Graph Problem";
            // 
            // TSPSelector
            // 
            this.Dock = DockStyle.Fill;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bitLength_label);
            this.Name = "TSPSelector";
            this.Text = "TSPSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox1;
        private Label bitLength_label;
    }
}