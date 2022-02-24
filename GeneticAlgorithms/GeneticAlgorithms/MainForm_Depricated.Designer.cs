namespace GeneticAlgorithms
{
    partial class MainForm_Depricated
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.evaluate_btn = new System.Windows.Forms.Button();
            this.graph_pb = new System.Windows.Forms.PictureBox();
            this.play_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.interval_tb = new System.Windows.Forms.TextBox();
            this.interval_lbl = new System.Windows.Forms.Label();
            this.clear_btn = new System.Windows.Forms.Button();
            this.timesEvaluated_lbl = new System.Windows.Forms.Label();
            this.files_lb = new System.Windows.Forms.ListBox();
            this.test_btn = new System.Windows.Forms.Button();
            this.loadedFile_lbl = new System.Windows.Forms.Label();
            this.bit_btn = new System.Windows.Forms.Button();
            this.graph_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // evaluate_btn
            // 
            this.evaluate_btn.BackColor = System.Drawing.Color.White;
            this.evaluate_btn.Location = new System.Drawing.Point(885, 104);
            this.evaluate_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.evaluate_btn.Name = "evaluate_btn";
            this.evaluate_btn.Size = new System.Drawing.Size(263, 37);
            this.evaluate_btn.TabIndex = 0;
            this.evaluate_btn.Text = "Evaluate";
            this.evaluate_btn.UseVisualStyleBackColor = false;
            this.evaluate_btn.Click += new System.EventHandler(this.evaluate_btn_Click);
            // 
            // graph_pb
            // 
            this.graph_pb.BackColor = System.Drawing.Color.White;
            this.graph_pb.Location = new System.Drawing.Point(12, 12);
            this.graph_pb.Name = "graph_pb";
            this.graph_pb.Size = new System.Drawing.Size(867, 688);
            this.graph_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.graph_pb.TabIndex = 1;
            this.graph_pb.TabStop = false;
            this.graph_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_pb_Paint);
            // 
            // play_btn
            // 
            this.play_btn.BackColor = System.Drawing.Color.White;
            this.play_btn.Location = new System.Drawing.Point(885, 63);
            this.play_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(132, 37);
            this.play_btn.TabIndex = 2;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = false;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.BackColor = System.Drawing.Color.White;
            this.pause_btn.Enabled = false;
            this.pause_btn.Location = new System.Drawing.Point(1023, 63);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(125, 37);
            this.pause_btn.TabIndex = 3;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = false;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // interval_tb
            // 
            this.interval_tb.Location = new System.Drawing.Point(885, 35);
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(263, 23);
            this.interval_tb.TabIndex = 4;
            // 
            // interval_lbl
            // 
            this.interval_lbl.AutoSize = true;
            this.interval_lbl.ForeColor = System.Drawing.Color.White;
            this.interval_lbl.Location = new System.Drawing.Point(887, 15);
            this.interval_lbl.Name = "interval_lbl";
            this.interval_lbl.Size = new System.Drawing.Size(46, 15);
            this.interval_lbl.TabIndex = 5;
            this.interval_lbl.Text = "Interval";
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.White;
            this.clear_btn.Location = new System.Drawing.Point(887, 145);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(263, 37);
            this.clear_btn.TabIndex = 6;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // timesEvaluated_lbl
            // 
            this.timesEvaluated_lbl.AutoSize = true;
            this.timesEvaluated_lbl.ForeColor = System.Drawing.Color.White;
            this.timesEvaluated_lbl.Location = new System.Drawing.Point(885, 210);
            this.timesEvaluated_lbl.Name = "timesEvaluated_lbl";
            this.timesEvaluated_lbl.Size = new System.Drawing.Size(95, 15);
            this.timesEvaluated_lbl.TabIndex = 7;
            this.timesEvaluated_lbl.Text = "Times Evaluated:";
            this.timesEvaluated_lbl.Paint += new System.Windows.Forms.PaintEventHandler(this.timesEvaluated_lbl_Paint);
            // 
            // files_lb
            // 
            this.files_lb.FormattingEnabled = true;
            this.files_lb.ItemHeight = 15;
            this.files_lb.Location = new System.Drawing.Point(885, 238);
            this.files_lb.Name = "files_lb";
            this.files_lb.Size = new System.Drawing.Size(263, 79);
            this.files_lb.TabIndex = 8;
            this.files_lb.SelectedIndexChanged += new System.EventHandler(this.files_lb_SelectedIndexChanged);
            // 
            // test_btn
            // 
            this.test_btn.BackColor = System.Drawing.Color.White;
            this.test_btn.Location = new System.Drawing.Point(885, 405);
            this.test_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(132, 37);
            this.test_btn.TabIndex = 9;
            this.test_btn.Text = "Optimize";
            this.test_btn.UseVisualStyleBackColor = false;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // loadedFile_lbl
            // 
            this.loadedFile_lbl.AutoSize = true;
            this.loadedFile_lbl.ForeColor = System.Drawing.Color.White;
            this.loadedFile_lbl.Location = new System.Drawing.Point(885, 320);
            this.loadedFile_lbl.Name = "loadedFile_lbl";
            this.loadedFile_lbl.Size = new System.Drawing.Size(70, 15);
            this.loadedFile_lbl.TabIndex = 10;
            this.loadedFile_lbl.Text = "Loaded File:";
            // 
            // bit_btn
            // 
            this.bit_btn.Enabled = false;
            this.bit_btn.Location = new System.Drawing.Point(885, 362);
            this.bit_btn.Name = "bit_btn";
            this.bit_btn.Size = new System.Drawing.Size(132, 38);
            this.bit_btn.TabIndex = 11;
            this.bit_btn.Text = "Select Bit";
            this.bit_btn.UseVisualStyleBackColor = true;
            this.bit_btn.Click += new System.EventHandler(this.bit_btn_Click);
            // 
            // graph_btn
            // 
            this.graph_btn.Location = new System.Drawing.Point(1023, 362);
            this.graph_btn.Name = "graph_btn";
            this.graph_btn.Size = new System.Drawing.Size(125, 38);
            this.graph_btn.TabIndex = 12;
            this.graph_btn.Text = "Select Graph";
            this.graph_btn.UseVisualStyleBackColor = true;
            this.graph_btn.Click += new System.EventHandler(this.graph_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1168, 712);
            this.Controls.Add(this.graph_btn);
            this.Controls.Add(this.bit_btn);
            this.Controls.Add(this.loadedFile_lbl);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.files_lb);
            this.Controls.Add(this.timesEvaluated_lbl);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.interval_lbl);
            this.Controls.Add(this.interval_tb);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.graph_pb);
            this.Controls.Add(this.evaluate_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Genetic Algorithms";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.graph_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button evaluate_btn;
        private PictureBox graph_pb;
        private Button play_btn;
        private Button pause_btn;
        private TextBox interval_tb;
        private Label interval_lbl;
        private Button clear_btn;
        private Label timesEvaluated_lbl;
        private ListBox files_lb;
        private Button test_btn;
        private Label loadedFile_lbl;
        private Button bit_btn;
        private Button graph_btn;
    }
}