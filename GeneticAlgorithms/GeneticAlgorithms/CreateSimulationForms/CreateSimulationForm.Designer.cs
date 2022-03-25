namespace GeneticAlgorithms.CreateSimulationForms
{
    partial class CreateSimulationForm
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
            this.formatter = new System.Windows.Forms.TableLayoutPanel();
            this.headline = new System.Windows.Forms.Label();
            this.createAlgorithm = new System.Windows.Forms.Button();
            this.selectables = new TableLayoutPanel();
            this.formatter.SuspendLayout();
            this.SuspendLayout();
            // 
            // formatter
            // 
            this.formatter.ColumnCount = 1;
            this.formatter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formatter.Controls.Add(this.headline, 0, 0);
            this.formatter.Controls.Add(this.selectables,0,1);
            this.formatter.Controls.Add(this.createAlgorithm, 0, 2);
            this.formatter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatter.Location = new System.Drawing.Point(0, 0);
            this.formatter.Name = "formatter";
            this.formatter.RowCount = 3;
            this.formatter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.formatter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formatter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.formatter.Size = new System.Drawing.Size(1378, 578);
            this.formatter.TabIndex = 0;
            // 
            // headline
            // 
            this.headline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headline.Location = new System.Drawing.Point(3, 0);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(1372, 50);
            this.headline.TabIndex = 0;
            this.headline.Text = "INSERT HEADLINE HERE";
            this.headline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //  selectables SHOULD BE SPECIFIED IN INHERTING CLASS
            //
            this.selectables.Dock = DockStyle.Fill;


            // 
            // createAlgorithm
            // 
            this.createAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createAlgorithm.Location = new System.Drawing.Point(639, 531);
            this.createAlgorithm.Name = "createAlgorithm";
            this.createAlgorithm.Size = new System.Drawing.Size(100, 44);
            this.createAlgorithm.TabIndex = 1;
            this.createAlgorithm.Text = "Create";
            this.createAlgorithm.Click += new System.EventHandler(this.createAlgorithm_Click);
            // 
            // CreateSimulationForm
            // 
            this.Dock = DockStyle.Fill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 578);
            this.Controls.Add(this.formatter);
            this.Name = "CreateSimulationForm";
            this.Text = "CreateSimulationForm";
            this.formatter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected TableLayoutPanel selectables;
        protected TableLayoutPanel formatter;
        protected Label headline;
        protected Button createAlgorithm;
    }
}