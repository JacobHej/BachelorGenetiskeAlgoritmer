namespace GeneticAlgorithms.CreateSimulationForms.OneMaxOnePlusOneEA
{
    partial class OneMaxOnePlusOneEA
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
            this.generate_btn = new System.Windows.Forms.Button();
            this.bitLength_tb = new System.Windows.Forms.TextBox();
            this.bitLength_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(355, 67);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(94, 29);
            this.generate_btn.TabIndex = 0;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // bitLength_tb
            // 
            this.bitLength_tb.BackColor = System.Drawing.Color.White;
            this.bitLength_tb.Location = new System.Drawing.Point(286, 33);
            this.bitLength_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bitLength_tb.Name = "bitLength_tb";
            this.bitLength_tb.Size = new System.Drawing.Size(242, 27);
            this.bitLength_tb.TabIndex = 15;
            this.bitLength_tb.Text = "20";
            this.bitLength_tb.TextChanged += new System.EventHandler(this.bitLength_tb_TextChanged);
            // 
            // bitLength_label
            // 
            this.bitLength_label.AutoSize = true;
            this.bitLength_label.Location = new System.Drawing.Point(345, 9);
            this.bitLength_label.Name = "bitLength_label";
            this.bitLength_label.Size = new System.Drawing.Size(115, 20);
            this.bitLength_label.TabIndex = 16;
            this.bitLength_label.Text = "Size of BitString";
            this.bitLength_label.Click += new System.EventHandler(this.bitLength_label_Click);
            // 
            // OneMaxOnePlusOneEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bitLength_label);
            this.Controls.Add(this.bitLength_tb);
            this.Controls.Add(this.generate_btn);
            this.Name = "OneMaxOnePlusOneEA";
            this.Text = "OneMaxOnePlusOneEA";
            this.Load += new System.EventHandler(this.OneMaxOnePlusOneEA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button generate_btn;
        private TextBox bitLength_tb;
        private Label bitLength_label;
    }
}