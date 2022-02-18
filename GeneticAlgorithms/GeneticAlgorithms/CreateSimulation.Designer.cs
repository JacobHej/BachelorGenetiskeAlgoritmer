namespace GeneticAlgorithms
{
    partial class CreateSimulation
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
            this.startOver_btn = new System.Windows.Forms.Button();
            this.problem_box = new System.Windows.Forms.ComboBox();
            this.solution_box = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // startOver_btn
            // 
            this.startOver_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startOver_btn.AutoSize = true;
            this.startOver_btn.Location = new System.Drawing.Point(579, 12);
            this.startOver_btn.Name = "startOver_btn";
            this.startOver_btn.Size = new System.Drawing.Size(94, 30);
            this.startOver_btn.TabIndex = 0;
            this.startOver_btn.Text = "Start Over";
            this.startOver_btn.UseVisualStyleBackColor = true;
            this.startOver_btn.Click += new System.EventHandler(this.startOver_btn_Click);
            // 
            // problem_box
            // 
            this.problem_box.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.problem_box.FormattingEnabled = true;
            this.problem_box.Items.AddRange(new object[] {
            "OneMax",
            "LeadingOnes",
            "BinVal",
            "TSP"});
            this.problem_box.Location = new System.Drawing.Point(419, 12);
            this.problem_box.Name = "problem_box";
            this.problem_box.Size = new System.Drawing.Size(154, 53);
            this.problem_box.TabIndex = 1;
            this.problem_box.Text = "Problem";
            this.problem_box.SelectedIndexChanged += new System.EventHandler(this.problem_box_SelectedIndexChanged);
            // 
            // solution_box
            // 
            this.solution_box.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solution_box.FormattingEnabled = true;
            this.solution_box.Items.AddRange(new object[] {
            "1+1EA"});
            this.solution_box.Location = new System.Drawing.Point(679, 12);
            this.solution_box.Name = "solution_box";
            this.solution_box.Size = new System.Drawing.Size(154, 53);
            this.solution_box.TabIndex = 2;
            this.solution_box.Text = "Solution";
            this.solution_box.SelectedIndexChanged += new System.EventHandler(this.solution_box_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 820);
            this.panel1.TabIndex = 3;
            // 
            // CreateSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1182, 903);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.solution_box);
            this.Controls.Add(this.problem_box);
            this.Controls.Add(this.startOver_btn);
            this.Name = "CreateSimulation";
            this.Text = "CreateSimulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startOver_btn;
        private ComboBox problem_box;
        private ComboBox solution_box;
        private Panel panel1;
    }
}