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
            this.optimize_btn = new System.Windows.Forms.Button();
            this.evolve_btn = new System.Windows.Forms.Button();
            this.createNewSimulation_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // graph_pb
            // 
            this.graph_pb.BackColor = System.Drawing.Color.White;
            this.graph_pb.Location = new System.Drawing.Point(41, 18);
            this.graph_pb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.graph_pb.Name = "graph_pb";
            this.graph_pb.Size = new System.Drawing.Size(950, 950);
            this.graph_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.graph_pb.TabIndex = 14;
            this.graph_pb.TabStop = false;
            this.graph_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_pb_Paint);
            // 
            // nextGen_btn
            // 
            this.nextGen_btn.Location = new System.Drawing.Point(1059, 560);
            this.nextGen_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nextGen_btn.Name = "nextGen_btn";
            this.nextGen_btn.Size = new System.Drawing.Size(100, 50);
            this.nextGen_btn.TabIndex = 52;
            this.nextGen_btn.Text = "Next Generation";
            this.nextGen_btn.UseVisualStyleBackColor = true;
            // 
            // prevGen_btn
            // 
            this.prevGen_btn.Location = new System.Drawing.Point(1209, 560);
            this.prevGen_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prevGen_btn.Name = "prevGen_btn";
            this.prevGen_btn.Size = new System.Drawing.Size(100, 50);
            this.prevGen_btn.TabIndex = 51;
            this.prevGen_btn.Text = "Previous Generation";
            this.prevGen_btn.UseVisualStyleBackColor = true;
            // 
            // interval_lbl
            // 
            this.interval_lbl.AutoSize = true;
            this.interval_lbl.ForeColor = System.Drawing.Color.White;
            this.interval_lbl.Location = new System.Drawing.Point(1143, 385);
            this.interval_lbl.Name = "interval_lbl";
            this.interval_lbl.Size = new System.Drawing.Size(91, 20);
            this.interval_lbl.TabIndex = 49;
            this.interval_lbl.Text = "Interval (ms)";
            // 
            // interval_tb
            // 
            this.interval_tb.Location = new System.Drawing.Point(1113, 409);
            this.interval_tb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(150, 27);
            this.interval_tb.TabIndex = 48;
            this.interval_tb.Text = "200";
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.White;
            this.pause_btn.Location = new System.Drawing.Point(1059, 502);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(250, 50);
            this.pause_btn.TabIndex = 46;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.White;
            this.play_btn.Location = new System.Drawing.Point(1059, 444);
            this.play_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(250, 50);
            this.play_btn.TabIndex = 45;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // optimize_btn
            // 
            this.optimize_btn.BackColor = System.Drawing.Color.White;
            this.optimize_btn.Location = new System.Drawing.Point(1214, 331);
            this.optimize_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optimize_btn.Name = "optimize_btn";
            this.optimize_btn.Size = new System.Drawing.Size(150, 50);
            this.optimize_btn.TabIndex = 44;
            this.optimize_btn.Text = "Optimize";
            this.optimize_btn.UseVisualStyleBackColor = false;
            this.optimize_btn.Click += new System.EventHandler(this.optimize_btn_Click);
            // 
            // evolve_btn
            // 
            this.evolve_btn.BackColor = System.Drawing.Color.White;
            this.evolve_btn.Location = new System.Drawing.Point(1014, 331);
            this.evolve_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.evolve_btn.Name = "evolve_btn";
            this.evolve_btn.Size = new System.Drawing.Size(150, 50);
            this.evolve_btn.TabIndex = 43;
            this.evolve_btn.Text = "Evolve One Step";
            this.evolve_btn.UseVisualStyleBackColor = false;
            this.evolve_btn.Click += new System.EventHandler(this.evolve_btn_Click);
            // 
            // createNewSimulation_btn
            // 
            this.createNewSimulation_btn.BackColor = System.Drawing.Color.White;
            this.createNewSimulation_btn.Location = new System.Drawing.Point(1014, 273);
            this.createNewSimulation_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createNewSimulation_btn.Name = "createNewSimulation_btn";
            this.createNewSimulation_btn.Size = new System.Drawing.Size(350, 50);
            this.createNewSimulation_btn.TabIndex = 47;
            this.createNewSimulation_btn.Text = "Create New Simulation\r\n";
            this.createNewSimulation_btn.UseVisualStyleBackColor = false;
            // 
            // TSPManipV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1382, 953);
            this.Controls.Add(this.nextGen_btn);
            this.Controls.Add(this.prevGen_btn);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.optimize_btn);
            this.Controls.Add(this.evolve_btn);
            this.Controls.Add(this.createNewSimulation_btn);
            this.Controls.Add(this.graph_pb);
            this.Name = "TSPManipV2";
            this.Text = "TSPManipV2";
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox graph_pb;
        private Button nextGen_btn;
        private Button prevGen_btn;
        private Label interval_lbl;
        private TextBox interval_tb;
        private Button pause_btn;
        private Button play_btn;
        private Button optimize_btn;
        private Button evolve_btn;
        private Button createNewSimulation_btn;
    }
}