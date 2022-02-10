﻿namespace GeneticAlgorithms
{
    partial class BitManipulation
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
            this.data_pb = new System.Windows.Forms.PictureBox();
            this.crossover_lbl = new System.Windows.Forms.Label();
            this.mutation_lbl = new System.Windows.Forms.Label();
            this.selector_lbl = new System.Windows.Forms.Label();
            this.randomCrossover_rb = new System.Windows.Forms.RadioButton();
            this.crossover_grp = new System.Windows.Forms.GroupBox();
            this.mutation_grp = new System.Windows.Forms.GroupBox();
            this.oneOverNMutation_rb = new System.Windows.Forms.RadioButton();
            this.selector_grp = new System.Windows.Forms.GroupBox();
            this.randomSelection_rb = new System.Windows.Forms.RadioButton();
            this.createAlgorithm_btn = new System.Windows.Forms.Button();
            this.evolve_btn = new System.Windows.Forms.Button();
            this.optimize_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.interval_tb = new System.Windows.Forms.TextBox();
            this.populationSize_tb = new System.Windows.Forms.TextBox();
            this.pupolationSize_lbl = new System.Windows.Forms.Label();
            this.bitStringLength_lbl = new System.Windows.Forms.Label();
            this.bitStringLength_tb = new System.Windows.Forms.TextBox();
            this.interval_lbl = new System.Windows.Forms.Label();
            this.probabilitySelector_rb = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.data_pb)).BeginInit();
            this.crossover_grp.SuspendLayout();
            this.mutation_grp.SuspendLayout();
            this.selector_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_pb
            // 
            this.data_pb.BackColor = System.Drawing.Color.White;
            this.data_pb.Location = new System.Drawing.Point(12, 12);
            this.data_pb.Name = "data_pb";
            this.data_pb.Size = new System.Drawing.Size(504, 655);
            this.data_pb.TabIndex = 0;
            this.data_pb.TabStop = false;
            this.data_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.data_pb_Paint);
            // 
            // crossover_lbl
            // 
            this.crossover_lbl.AutoSize = true;
            this.crossover_lbl.ForeColor = System.Drawing.Color.White;
            this.crossover_lbl.Location = new System.Drawing.Point(539, 12);
            this.crossover_lbl.Name = "crossover_lbl";
            this.crossover_lbl.Size = new System.Drawing.Size(59, 15);
            this.crossover_lbl.TabIndex = 1;
            this.crossover_lbl.Text = "Crossover";
            // 
            // mutation_lbl
            // 
            this.mutation_lbl.AutoSize = true;
            this.mutation_lbl.ForeColor = System.Drawing.Color.White;
            this.mutation_lbl.Location = new System.Drawing.Point(539, 86);
            this.mutation_lbl.Name = "mutation_lbl";
            this.mutation_lbl.Size = new System.Drawing.Size(56, 15);
            this.mutation_lbl.TabIndex = 2;
            this.mutation_lbl.Text = "Mutation";
            // 
            // selector_lbl
            // 
            this.selector_lbl.AutoSize = true;
            this.selector_lbl.ForeColor = System.Drawing.Color.White;
            this.selector_lbl.Location = new System.Drawing.Point(539, 153);
            this.selector_lbl.Name = "selector_lbl";
            this.selector_lbl.Size = new System.Drawing.Size(49, 15);
            this.selector_lbl.TabIndex = 3;
            this.selector_lbl.Text = "Selector";
            // 
            // randomCrossover_rb
            // 
            this.randomCrossover_rb.AutoSize = true;
            this.randomCrossover_rb.Checked = true;
            this.randomCrossover_rb.ForeColor = System.Drawing.Color.White;
            this.randomCrossover_rb.Location = new System.Drawing.Point(6, 16);
            this.randomCrossover_rb.Name = "randomCrossover_rb";
            this.randomCrossover_rb.Size = new System.Drawing.Size(125, 19);
            this.randomCrossover_rb.TabIndex = 4;
            this.randomCrossover_rb.TabStop = true;
            this.randomCrossover_rb.Text = "Random Crossover";
            this.randomCrossover_rb.UseVisualStyleBackColor = true;
            // 
            // crossover_grp
            // 
            this.crossover_grp.Controls.Add(this.randomCrossover_rb);
            this.crossover_grp.ForeColor = System.Drawing.Color.White;
            this.crossover_grp.Location = new System.Drawing.Point(539, 30);
            this.crossover_grp.Name = "crossover_grp";
            this.crossover_grp.Size = new System.Drawing.Size(440, 41);
            this.crossover_grp.TabIndex = 5;
            this.crossover_grp.TabStop = false;
            // 
            // mutation_grp
            // 
            this.mutation_grp.Controls.Add(this.oneOverNMutation_rb);
            this.mutation_grp.Location = new System.Drawing.Point(539, 104);
            this.mutation_grp.Name = "mutation_grp";
            this.mutation_grp.Size = new System.Drawing.Size(440, 43);
            this.mutation_grp.TabIndex = 6;
            this.mutation_grp.TabStop = false;
            // 
            // oneOverNMutation_rb
            // 
            this.oneOverNMutation_rb.AutoSize = true;
            this.oneOverNMutation_rb.Checked = true;
            this.oneOverNMutation_rb.ForeColor = System.Drawing.Color.White;
            this.oneOverNMutation_rb.Location = new System.Drawing.Point(6, 18);
            this.oneOverNMutation_rb.Name = "oneOverNMutation_rb";
            this.oneOverNMutation_rb.Size = new System.Drawing.Size(97, 19);
            this.oneOverNMutation_rb.TabIndex = 5;
            this.oneOverNMutation_rb.TabStop = true;
            this.oneOverNMutation_rb.Text = "1/N Mutation";
            this.oneOverNMutation_rb.UseVisualStyleBackColor = true;
            // 
            // selector_grp
            // 
            this.selector_grp.Controls.Add(this.probabilitySelector_rb);
            this.selector_grp.Controls.Add(this.randomSelection_rb);
            this.selector_grp.Location = new System.Drawing.Point(539, 172);
            this.selector_grp.Name = "selector_grp";
            this.selector_grp.Size = new System.Drawing.Size(439, 42);
            this.selector_grp.TabIndex = 7;
            this.selector_grp.TabStop = false;
            // 
            // randomSelection_rb
            // 
            this.randomSelection_rb.AutoSize = true;
            this.randomSelection_rb.Checked = true;
            this.randomSelection_rb.ForeColor = System.Drawing.Color.White;
            this.randomSelection_rb.Location = new System.Drawing.Point(3, 17);
            this.randomSelection_rb.Name = "randomSelection_rb";
            this.randomSelection_rb.Size = new System.Drawing.Size(121, 19);
            this.randomSelection_rb.TabIndex = 0;
            this.randomSelection_rb.TabStop = true;
            this.randomSelection_rb.Text = "Random Selection";
            this.randomSelection_rb.UseVisualStyleBackColor = true;
            // 
            // createAlgorithm_btn
            // 
            this.createAlgorithm_btn.BackColor = System.Drawing.Color.White;
            this.createAlgorithm_btn.Location = new System.Drawing.Point(539, 287);
            this.createAlgorithm_btn.Name = "createAlgorithm_btn";
            this.createAlgorithm_btn.Size = new System.Drawing.Size(439, 39);
            this.createAlgorithm_btn.TabIndex = 8;
            this.createAlgorithm_btn.Text = "Create Algorithm";
            this.createAlgorithm_btn.UseVisualStyleBackColor = false;
            this.createAlgorithm_btn.Click += new System.EventHandler(this.createAlgorithm_btn_Click);
            // 
            // evolve_btn
            // 
            this.evolve_btn.BackColor = System.Drawing.Color.White;
            this.evolve_btn.Location = new System.Drawing.Point(539, 332);
            this.evolve_btn.Name = "evolve_btn";
            this.evolve_btn.Size = new System.Drawing.Size(212, 37);
            this.evolve_btn.TabIndex = 9;
            this.evolve_btn.Text = "Evolve One Step";
            this.evolve_btn.UseVisualStyleBackColor = false;
            this.evolve_btn.Click += new System.EventHandler(this.evolve_btn_Click);
            // 
            // optimize_btn
            // 
            this.optimize_btn.BackColor = System.Drawing.Color.White;
            this.optimize_btn.Location = new System.Drawing.Point(766, 332);
            this.optimize_btn.Name = "optimize_btn";
            this.optimize_btn.Size = new System.Drawing.Size(212, 37);
            this.optimize_btn.TabIndex = 10;
            this.optimize_btn.Text = "Optimize";
            this.optimize_btn.UseVisualStyleBackColor = false;
            this.optimize_btn.Click += new System.EventHandler(this.optimize_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.White;
            this.play_btn.Location = new System.Drawing.Point(649, 440);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(212, 44);
            this.play_btn.TabIndex = 11;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.White;
            this.pause_btn.Location = new System.Drawing.Point(649, 490);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(212, 44);
            this.pause_btn.TabIndex = 12;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // interval_tb
            // 
            this.interval_tb.Location = new System.Drawing.Point(649, 411);
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(212, 23);
            this.interval_tb.TabIndex = 13;
            this.interval_tb.Text = "200";
            // 
            // populationSize_tb
            // 
            this.populationSize_tb.BackColor = System.Drawing.Color.White;
            this.populationSize_tb.Location = new System.Drawing.Point(539, 247);
            this.populationSize_tb.Name = "populationSize_tb";
            this.populationSize_tb.Size = new System.Drawing.Size(212, 23);
            this.populationSize_tb.TabIndex = 14;
            this.populationSize_tb.Text = "5";
            // 
            // pupolationSize_lbl
            // 
            this.pupolationSize_lbl.AutoSize = true;
            this.pupolationSize_lbl.ForeColor = System.Drawing.Color.White;
            this.pupolationSize_lbl.Location = new System.Drawing.Point(539, 226);
            this.pupolationSize_lbl.Name = "pupolationSize_lbl";
            this.pupolationSize_lbl.Size = new System.Drawing.Size(88, 15);
            this.pupolationSize_lbl.TabIndex = 15;
            this.pupolationSize_lbl.Text = "Population Size";
            // 
            // bitStringLength_lbl
            // 
            this.bitStringLength_lbl.AutoSize = true;
            this.bitStringLength_lbl.ForeColor = System.Drawing.Color.White;
            this.bitStringLength_lbl.Location = new System.Drawing.Point(766, 226);
            this.bitStringLength_lbl.Name = "bitStringLength_lbl";
            this.bitStringLength_lbl.Size = new System.Drawing.Size(95, 15);
            this.bitStringLength_lbl.TabIndex = 17;
            this.bitStringLength_lbl.Text = "Bit String Length";
            // 
            // bitStringLength_tb
            // 
            this.bitStringLength_tb.BackColor = System.Drawing.Color.White;
            this.bitStringLength_tb.Location = new System.Drawing.Point(766, 247);
            this.bitStringLength_tb.Name = "bitStringLength_tb";
            this.bitStringLength_tb.Size = new System.Drawing.Size(212, 23);
            this.bitStringLength_tb.TabIndex = 16;
            this.bitStringLength_tb.Text = "20";
            // 
            // interval_lbl
            // 
            this.interval_lbl.AutoSize = true;
            this.interval_lbl.ForeColor = System.Drawing.Color.White;
            this.interval_lbl.Location = new System.Drawing.Point(649, 393);
            this.interval_lbl.Name = "interval_lbl";
            this.interval_lbl.Size = new System.Drawing.Size(73, 15);
            this.interval_lbl.TabIndex = 18;
            this.interval_lbl.Text = "Interval (ms)";
            // 
            // probabilitySelector_rb
            // 
            this.probabilitySelector_rb.AutoSize = true;
            this.probabilitySelector_rb.BackColor = System.Drawing.Color.Transparent;
            this.probabilitySelector_rb.ForeColor = System.Drawing.Color.White;
            this.probabilitySelector_rb.Location = new System.Drawing.Point(141, 17);
            this.probabilitySelector_rb.Name = "probabilitySelector_rb";
            this.probabilitySelector_rb.Size = new System.Drawing.Size(133, 19);
            this.probabilitySelector_rb.TabIndex = 1;
            this.probabilitySelector_rb.TabStop = true;
            this.probabilitySelector_rb.Text = "Probability Selection";
            this.probabilitySelector_rb.UseVisualStyleBackColor = false;
            // 
            // BitManipulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1025, 679);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.bitStringLength_lbl);
            this.Controls.Add(this.bitStringLength_tb);
            this.Controls.Add(this.pupolationSize_lbl);
            this.Controls.Add(this.populationSize_tb);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.optimize_btn);
            this.Controls.Add(this.evolve_btn);
            this.Controls.Add(this.createAlgorithm_btn);
            this.Controls.Add(this.selector_grp);
            this.Controls.Add(this.mutation_grp);
            this.Controls.Add(this.crossover_grp);
            this.Controls.Add(this.selector_lbl);
            this.Controls.Add(this.mutation_lbl);
            this.Controls.Add(this.crossover_lbl);
            this.Controls.Add(this.data_pb);
            this.Name = "BitManipulation";
            this.Text = "BitManipulation";
            ((System.ComponentModel.ISupportInitialize)(this.data_pb)).EndInit();
            this.crossover_grp.ResumeLayout(false);
            this.crossover_grp.PerformLayout();
            this.mutation_grp.ResumeLayout(false);
            this.mutation_grp.PerformLayout();
            this.selector_grp.ResumeLayout(false);
            this.selector_grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox data_pb;
        private Label crossover_lbl;
        private Label mutation_lbl;
        private Label selector_lbl;
        private RadioButton randomCrossover_rb;
        private GroupBox crossover_grp;
        private GroupBox mutation_grp;
        private RadioButton oneOverNMutation_rb;
        private GroupBox selector_grp;
        private RadioButton randomSelection_rb;
        private Button createAlgorithm_btn;
        private Button evolve_btn;
        private Button optimize_btn;
        private Button play_btn;
        private Button pause_btn;
        private TextBox interval_tb;
        private TextBox populationSize_tb;
        private Label pupolationSize_lbl;
        private Label bitStringLength_lbl;
        private TextBox bitStringLength_tb;
        private Label interval_lbl;
        private RadioButton probabilitySelector_rb;
    }
}