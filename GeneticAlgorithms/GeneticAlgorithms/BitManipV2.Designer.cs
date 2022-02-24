namespace GeneticAlgorithms
{
    partial class BitManipV2
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
            this.nextGen_btn = new System.Windows.Forms.Button();
            this.prevGen_btn = new System.Windows.Forms.Button();
            this.test_btn = new System.Windows.Forms.Button();
            this.interval_lbl = new System.Windows.Forms.Label();
            this.interval_tb = new System.Windows.Forms.TextBox();
            this.pause_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.optimize_btn = new System.Windows.Forms.Button();
            this.evolve_btn = new System.Windows.Forms.Button();
            this.createNewSimulation_btn = new System.Windows.Forms.Button();
            this.data_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // nextGen_btn
            // 
            this.nextGen_btn.Location = new System.Drawing.Point(638, 643);
            this.nextGen_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nextGen_btn.Name = "nextGen_btn";
            this.nextGen_btn.Size = new System.Drawing.Size(97, 69);
            this.nextGen_btn.TabIndex = 42;
            this.nextGen_btn.Text = "Next Generation";
            this.nextGen_btn.UseVisualStyleBackColor = true;
            // 
            // prevGen_btn
            // 
            this.prevGen_btn.Location = new System.Drawing.Point(638, 548);
            this.prevGen_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prevGen_btn.Name = "prevGen_btn";
            this.prevGen_btn.Size = new System.Drawing.Size(97, 75);
            this.prevGen_btn.TabIndex = 41;
            this.prevGen_btn.Text = "Previous Generation";
            this.prevGen_btn.UseVisualStyleBackColor = true;
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(1026, 548);
            this.test_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(111, 164);
            this.test_btn.TabIndex = 40;
            this.test_btn.Text = "Test";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // interval_lbl
            // 
            this.interval_lbl.AutoSize = true;
            this.interval_lbl.ForeColor = System.Drawing.Color.White;
            this.interval_lbl.Location = new System.Drawing.Point(761, 524);
            this.interval_lbl.Name = "interval_lbl";
            this.interval_lbl.Size = new System.Drawing.Size(91, 20);
            this.interval_lbl.TabIndex = 39;
            this.interval_lbl.Text = "Interval (ms)";
            // 
            // interval_tb
            // 
            this.interval_tb.Location = new System.Drawing.Point(761, 548);
            this.interval_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(242, 27);
            this.interval_tb.TabIndex = 34;
            this.interval_tb.Text = "200";
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.White;
            this.pause_btn.Location = new System.Drawing.Point(742, 653);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(242, 59);
            this.pause_btn.TabIndex = 12;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.White;
            this.play_btn.Location = new System.Drawing.Point(742, 587);
            this.play_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(242, 59);
            this.play_btn.TabIndex = 11;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // optimize_btn
            // 
            this.optimize_btn.BackColor = System.Drawing.Color.White;
            this.optimize_btn.Location = new System.Drawing.Point(875, 443);
            this.optimize_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optimize_btn.Name = "optimize_btn";
            this.optimize_btn.Size = new System.Drawing.Size(242, 49);
            this.optimize_btn.TabIndex = 10;
            this.optimize_btn.Text = "Optimize";
            this.optimize_btn.UseVisualStyleBackColor = false;
            this.optimize_btn.Click += new System.EventHandler(this.optimize_btn_Click);
            // 
            // evolve_btn
            // 
            this.evolve_btn.BackColor = System.Drawing.Color.White;
            this.evolve_btn.Location = new System.Drawing.Point(616, 443);
            this.evolve_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.evolve_btn.Name = "evolve_btn";
            this.evolve_btn.Size = new System.Drawing.Size(242, 49);
            this.evolve_btn.TabIndex = 9;
            this.evolve_btn.Text = "Evolve One Step";
            this.evolve_btn.UseVisualStyleBackColor = false;
            this.evolve_btn.Click += new System.EventHandler(this.evolve_btn_Click);
            // 
            // createNewSimulation_btn
            // 
            this.createNewSimulation_btn.BackColor = System.Drawing.Color.White;
            this.createNewSimulation_btn.Location = new System.Drawing.Point(635, 383);
            this.createNewSimulation_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createNewSimulation_btn.Name = "createNewSimulation_btn";
            this.createNewSimulation_btn.Size = new System.Drawing.Size(502, 52);
            this.createNewSimulation_btn.TabIndex = 29;
            this.createNewSimulation_btn.Text = "Create New Simulation\r\n";
            this.createNewSimulation_btn.UseVisualStyleBackColor = false;
            this.createNewSimulation_btn.Click += new System.EventHandler(this.createNewSimulation_btn_Click);
            // 
            // data_pb
            // 
            this.data_pb.BackColor = System.Drawing.Color.White;
            this.data_pb.Location = new System.Drawing.Point(14, 16);
            this.data_pb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_pb.Name = "data_pb";
            this.data_pb.Size = new System.Drawing.Size(576, 873);
            this.data_pb.TabIndex = 0;
            this.data_pb.TabStop = false;
            this.data_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.data_pb_Paint);
            // 
            // BitManipV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1171, 905);
            this.Controls.Add(this.nextGen_btn);
            this.Controls.Add(this.prevGen_btn);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.optimize_btn);
            this.Controls.Add(this.evolve_btn);
            this.Controls.Add(this.createNewSimulation_btn);
            this.Controls.Add(this.data_pb);
            this.Name = "BitManipV2";
            this.Text = "BitManipV2";
            ((System.ComponentModel.ISupportInitialize)(this.data_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nextGen_btn;
        private Button prevGen_btn;
        private Button test_btn;
        private Label interval_lbl;
        private TextBox interval_tb;
        private Button pause_btn;
        private Button play_btn;
        private Button optimize_btn;
        private Button evolve_btn;
        private Button createNewSimulation_btn;
        private PictureBox data_pb;
    }
}