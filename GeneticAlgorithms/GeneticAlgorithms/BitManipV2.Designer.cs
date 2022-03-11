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
            this.data_pb = new System.Windows.Forms.PictureBox();
            this.ItrWithoutImpr_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxTime_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxItr_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetFitness_tb = new System.Windows.Forms.TextBox();
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
            this.interval_tb.MaxLength = 10;
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(242, 27);
            this.interval_tb.TabIndex = 34;
            this.interval_tb.Text = "200";
            this.interval_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
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
            this.optimize_btn.Location = new System.Drawing.Point(761, 345);
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
            this.evolve_btn.Location = new System.Drawing.Point(761, 402);
            this.evolve_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.evolve_btn.Name = "evolve_btn";
            this.evolve_btn.Size = new System.Drawing.Size(242, 49);
            this.evolve_btn.TabIndex = 9;
            this.evolve_btn.Text = "Evolve One Step";
            this.evolve_btn.UseVisualStyleBackColor = false;
            this.evolve_btn.Click += new System.EventHandler(this.evolve_btn_Click);
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
            // ItrWithoutImpr_tb
            // 
            this.ItrWithoutImpr_tb.Location = new System.Drawing.Point(638, 311);
            this.ItrWithoutImpr_tb.MaxLength = 10;
            this.ItrWithoutImpr_tb.Name = "ItrWithoutImpr_tb";
            this.ItrWithoutImpr_tb.Size = new System.Drawing.Size(256, 27);
            this.ItrWithoutImpr_tb.TabIndex = 43;
            this.ItrWithoutImpr_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(638, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nr of iterations without improvement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(901, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Deprecated";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MaxTime_tb
            // 
            this.MaxTime_tb.Location = new System.Drawing.Point(901, 311);
            this.MaxTime_tb.MaxLength = 10;
            this.MaxTime_tb.Name = "MaxTime_tb";
            this.MaxTime_tb.Size = new System.Drawing.Size(131, 27);
            this.MaxTime_tb.TabIndex = 45;
            this.MaxTime_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(638, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Max nr of iterations total";
            // 
            // MaxItr_tb
            // 
            this.MaxItr_tb.Location = new System.Drawing.Point(638, 258);
            this.MaxItr_tb.MaxLength = 10;
            this.MaxItr_tb.Name = "MaxItr_tb";
            this.MaxItr_tb.Size = new System.Drawing.Size(256, 27);
            this.MaxItr_tb.TabIndex = 47;
            this.MaxItr_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(903, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Target Fitness";
            // 
            // TargetFitness_tb
            // 
            this.TargetFitness_tb.Location = new System.Drawing.Point(903, 258);
            this.TargetFitness_tb.MaxLength = 10;
            this.TargetFitness_tb.Name = "TargetFitness_tb";
            this.TargetFitness_tb.Size = new System.Drawing.Size(129, 27);
            this.TargetFitness_tb.TabIndex = 49;
            this.TargetFitness_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // BitManipV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1171, 905);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TargetFitness_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaxItr_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxTime_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItrWithoutImpr_tb);
            this.Controls.Add(this.nextGen_btn);
            this.Controls.Add(this.prevGen_btn);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.optimize_btn);
            this.Controls.Add(this.evolve_btn);
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
        private PictureBox data_pb;
        private TextBox ItrWithoutImpr_tb;
        private Label label1;
        private Label label2;
        private TextBox MaxTime_tb;
        private Label label3;
        private TextBox MaxItr_tb;
        private Label label4;
        private TextBox TargetFitness_tb;
    }
}