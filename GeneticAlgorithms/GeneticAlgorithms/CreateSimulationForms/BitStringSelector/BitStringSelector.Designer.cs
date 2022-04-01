namespace GeneticAlgorithms.CreateSimulationForms.BitStringSelector
{
    partial class BitStringSelector
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
            this.Headline = new System.Windows.Forms.Label();
            BitStringSelectorBox = new ComboBox();
            BitStringScene = new Panel();
            this.SuspendLayout();
            // 
            // Headline
            // 
            this.Headline.Dock = DockStyle.Top;
            this.Headline.Location = new System.Drawing.Point(0, 0);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(50, 20);
            this.Headline.Text = "Select BitString";
            this.Headline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // BitStringSelectorBox
            //
            this.BitStringSelectorBox.Location = new System.Drawing.Point(425, 30);
            this.BitStringSelectorBox.Size = new System.Drawing.Size(150, 30);
            this.BitStringSelectorBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BitStringSelectorBox.FormattingEnabled = true;
            this.BitStringSelectorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BitStringSelectorBox.Name = "BitStringSelectorBox";
            this.BitStringSelectorBox.SelectedIndexChanged += new System.EventHandler(this.BitStringSelectorBox_SelectedIndexChanged);
            //
            //  BitStringScene
            //
            this.BitStringScene.Location = new System.Drawing.Point(100, 60);
            this.BitStringScene.Size = new System.Drawing.Size(800, 800);
            this.BitStringScene.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BitStringScene.Name = "BitStringScene";
            // 
            // BitStringSelector
            // 
            this.Dock = DockStyle.Fill;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.BitStringSelectorBox);
            this.Controls.Add(this.BitStringScene);
            this.Name = "BitStringSelector";
            this.Text = "BitStringSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Headline;
        private ComboBox BitStringSelectorBox;
        private Panel BitStringScene;
    }
}