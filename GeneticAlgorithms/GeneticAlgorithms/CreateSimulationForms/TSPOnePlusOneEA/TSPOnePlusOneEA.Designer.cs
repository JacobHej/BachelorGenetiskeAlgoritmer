namespace GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA
{
    partial class TSPOnePlusOneEA
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
            this.bitLength_label = new System.Windows.Forms.Label();
            this.generate_btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bitLength_label
            // 
            this.bitLength_label.AutoSize = true;
            this.bitLength_label.Location = new System.Drawing.Point(338, 182);
            this.bitLength_label.Name = "bitLength_label";
            this.bitLength_label.Size = new System.Drawing.Size(109, 20);
            this.bitLength_label.TabIndex = 19;
            this.bitLength_label.Text = "Graph Problem";
            this.bitLength_label.Click += new System.EventHandler(this.bitLength_label_Click);
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(348, 240);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(94, 29);
            this.generate_btn.TabIndex = 17;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 206);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.DataSource = new List<string>(ResourceManager.Resources.Keys);
            // 
            // TSPOnePlusOneEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bitLength_label);
            this.Controls.Add(this.generate_btn);
            this.Name = "TSPOnePlusOneEA";
            this.Text = "TSPOnePlusOneEA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label bitLength_label;
        private Button generate_btn;
        private ComboBox comboBox1;
    }
}