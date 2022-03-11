namespace GeneticAlgorithms
{
    partial class StartupForm
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
            this.createNewSimulation_btn = new System.Windows.Forms.Button();
            this.test_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createNewSimulation_btn
            // 
            this.createNewSimulation_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createNewSimulation_btn.BackColor = System.Drawing.Color.White;
            this.createNewSimulation_btn.Location = new System.Drawing.Point(350, 200);
            this.createNewSimulation_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createNewSimulation_btn.Name = "createNewSimulation_btn";
            this.createNewSimulation_btn.Size = new System.Drawing.Size(500, 50);
            this.createNewSimulation_btn.TabIndex = 30;
            this.createNewSimulation_btn.Text = "Create New Simulation\r\n";
            this.createNewSimulation_btn.UseVisualStyleBackColor = false;
            this.createNewSimulation_btn.Click += new System.EventHandler(this.createNewSimulation_btn_Click);
            // 
            // test_btn
            // 
            this.test_btn.BackColor = System.Drawing.Color.White;
            this.test_btn.Location = new System.Drawing.Point(500, 260);
            this.test_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(200, 50);
            this.test_btn.TabIndex = 31;
            this.test_btn.Text = "Test";
            this.test_btn.UseVisualStyleBackColor = false;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1182, 903);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.createNewSimulation_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartupForm";
            this.Text = "StartupForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button createNewSimulation_btn;
        private Button test_btn;
    }
}