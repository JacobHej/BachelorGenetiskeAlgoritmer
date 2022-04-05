namespace GeneticAlgorithms
{
    partial class TSPManipV2
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
            this.graph_pb = new System.Windows.Forms.PictureBox();
            this.nextGen_btn = new System.Windows.Forms.Button();
            this.prevGen_btn = new System.Windows.Forms.Button();
            this.interval_lbl = new System.Windows.Forms.Label();
            this.interval_tb = new System.Windows.Forms.TextBox();
            this.pause_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.evolve_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetFitness_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxItr_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxTime_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItrWithoutImpr_tb = new System.Windows.Forms.TextBox();
            this.optimize_btn = new System.Windows.Forms.Button();
            this.restart_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).BeginInit();
            this.SuspendLayout();

            int Xtra = 300;
            // 
            // restart_btn
            // 
            this.restart_btn.Location = new System.Drawing.Point(Xtra+650, 100);
            this.restart_btn.Name = "restart_btn";
            this.restart_btn.MinimumSize = new System.Drawing.Size(350, 100);
            this.restart_btn.Text = "Restart Simulation";
            this.restart_btn.UseVisualStyleBackColor = true;
            this.restart_btn.Click += restart_btn_Click;
            // 
            // nextGen_btn
            // 
            this.nextGen_btn.Location = new System.Drawing.Point(Xtra + 625, 650);
            this.nextGen_btn.Name = "nextGen_btn";
            this.nextGen_btn.MinimumSize = new System.Drawing.Size(100, 70);
            this.nextGen_btn.Text = "Next Generation";
            this.nextGen_btn.UseVisualStyleBackColor = true;
            // 
            // prevGen_btn
            // 
            this.prevGen_btn.Location = new System.Drawing.Point(Xtra + 625, 550);
            this.prevGen_btn.Name = "prevGen_btn";
            this.prevGen_btn.MinimumSize = new System.Drawing.Size(100, 70);
            this.prevGen_btn.Text = "Previous Generation";
            this.prevGen_btn.UseVisualStyleBackColor = true;
            // 
            // interval_lbl
            // 
            this.interval_lbl.AutoSize = true;
            this.interval_lbl.ForeColor = System.Drawing.Color.White;
            this.interval_lbl.Location = new System.Drawing.Point(Xtra + 750, 530);
            this.interval_lbl.Name = "interval_lbl";
            this.interval_lbl.MinimumSize = new System.Drawing.Size(250, 20);
            this.interval_lbl.TabIndex = 39;
            this.interval_lbl.Text = "Interval (ms)";
            // 
            // interval_tb
            // 
            this.interval_tb.Location = new System.Drawing.Point(Xtra + 750, 550);
            this.interval_tb.MaxLength = 10;
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(250, 30);
            this.interval_tb.TabIndex = 34;
            this.interval_tb.Text = "200";
            this.interval_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.White;
            this.pause_btn.Location = new System.Drawing.Point(Xtra + 750, 650);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(250, 60);
            this.pause_btn.TabIndex = 12;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.White;
            this.play_btn.Location = new System.Drawing.Point(Xtra + 750, 590);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(250, 60);
            this.play_btn.TabIndex = 11;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // optimize_btn
            // 
            this.optimize_btn.BackColor = System.Drawing.Color.White;
            this.optimize_btn.Location = new System.Drawing.Point(Xtra + 650, 350);
            this.optimize_btn.Name = "optimize_btn";
            this.optimize_btn.Size = new System.Drawing.Size(350, 50);
            this.optimize_btn.TabIndex = 10;
            this.optimize_btn.Text = "Optimize";
            this.optimize_btn.UseVisualStyleBackColor = false;
            this.optimize_btn.Click += new System.EventHandler(this.optimize_btn_Click);
            // 
            // evolve_btn
            // 
            this.evolve_btn.BackColor = System.Drawing.Color.White;
            this.evolve_btn.Location = new System.Drawing.Point(Xtra + 650, 400);
            this.evolve_btn.Name = "evolve_btn";
            this.evolve_btn.Size = new System.Drawing.Size(350, 50);
            this.evolve_btn.TabIndex = 9;
            this.evolve_btn.Text = "Evolve One Step";
            this.evolve_btn.UseVisualStyleBackColor = false;
            this.evolve_btn.Click += new System.EventHandler(this.evolve_btn_Click);
            // 
            // ItrWithoutImpr_tb
            // 
            this.ItrWithoutImpr_tb.Location = new System.Drawing.Point(Xtra + 650, 300);
            this.ItrWithoutImpr_tb.MaxLength = 10;
            this.ItrWithoutImpr_tb.Name = "ItrWithoutImpr_tb";
            this.ItrWithoutImpr_tb.Size = new System.Drawing.Size(250, 30);
            this.ItrWithoutImpr_tb.TabIndex = 43;
            this.ItrWithoutImpr_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(Xtra + 650, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nr of iterations without improvement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(Xtra + 900, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Deprecated";
            // 
            // MaxTime_tb
            // 
            this.MaxTime_tb.Location = new System.Drawing.Point(Xtra + 900, 300);
            this.MaxTime_tb.MaxLength = 10;
            this.MaxTime_tb.Name = "MaxTime_tb";
            this.MaxTime_tb.Size = new System.Drawing.Size(100, 30);
            this.MaxTime_tb.TabIndex = 45;
            this.MaxTime_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(Xtra + 650, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 20);
            this.label3.Text = "Max nr of iterations total";
            // 
            // MaxItr_tb
            // 
            this.MaxItr_tb.Location = new System.Drawing.Point(Xtra + 650, 250);
            this.MaxItr_tb.MaxLength = 10;
            this.MaxItr_tb.Name = "MaxItr_tb";
            this.MaxItr_tb.Size = new System.Drawing.Size(250, 30);
            this.MaxItr_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(Xtra + 900, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Target Fitness";
            // 
            // TargetFitness_tb
            // 
            this.TargetFitness_tb.Location = new System.Drawing.Point(Xtra + 900, 250);
            this.TargetFitness_tb.MaxLength = 10;
            this.TargetFitness_tb.Name = "TargetFitness_tb";
            this.TargetFitness_tb.Size = new System.Drawing.Size(100, 30);
            this.TargetFitness_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInt_KeyPress);
            // 
            // graph_pb
            // 
            this.graph_pb.BackColor = System.Drawing.Color.White;
            this.graph_pb.Location = new System.Drawing.Point(0, 0);
            this.graph_pb.Name = "graph_pb";
            this.graph_pb.Size = new System.Drawing.Size(900, 900);
            this.graph_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.graph_pb.TabIndex = 14;
            this.graph_pb.TabStop = false;
            this.graph_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_pb_Paint);
            // 
            // TSPManipV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.restart_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TargetFitness_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaxItr_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxTime_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItrWithoutImpr_tb);
            this.Controls.Add(this.optimize_btn);
            this.Controls.Add(this.nextGen_btn);
            this.Controls.Add(this.prevGen_btn);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.evolve_btn);
            this.Controls.Add(this.graph_pb);
            this.FormClosed += BitManipV2_FormClosed;
            this.Name = "TSPManipV2";
            this.Text = "TSPManipV2";
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button restart_btn;
        private PictureBox graph_pb;
        private Button nextGen_btn;
        private Button prevGen_btn;
        private Label interval_lbl;
        private TextBox interval_tb;
        private Button pause_btn;
        private Button play_btn;
        private Button evolve_btn;
        private Label label4;
        private TextBox TargetFitness_tb;
        private Label label3;
        private TextBox MaxItr_tb;
        private Label label2;
        private TextBox MaxTime_tb;
        private Label label1;
        private TextBox ItrWithoutImpr_tb;
        private Button optimize_btn;
    }
}