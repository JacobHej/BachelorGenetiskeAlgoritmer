namespace GeneticAlgorithms.CreateSimulationForms.TSPMutator
{
    partial class TSPMutatorSelector
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
            this.label1 = new System.Windows.Forms.Label();
            this.MutatorSelector = new System.Windows.Forms.ComboBox();
            this.MutatorScene = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(425, 0);
            this.label1.Size = new System.Drawing.Size(150, 30);
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Name = "label1";
            this.label1.Text = "Pick a mutator";
            // 
            // MutatorSelector
            // 
            this.MutatorSelector.Location = new System.Drawing.Point(425, 30);
            this.MutatorSelector.Size = new System.Drawing.Size(150, 30);
            this.MutatorSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MutatorSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            this.MutatorSelector.FormattingEnabled = true;
            this.MutatorSelector.Name = "MutatorSelector";
            this.MutatorSelector.SelectedIndexChanged += new System.EventHandler(this.MutatorSelector_SelectedIndexChanged);
            // 
            // MutatorScene
            // 
            this.MutatorScene.Location = new System.Drawing.Point(100, 60);
            this.MutatorScene.Size = new System.Drawing.Size(800, 800);
            this.MutatorScene.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MutatorScene.Name = "MutatorScene";
            // 
            // TSPMutatorSelector
            // 
            this.Dock = DockStyle.Fill;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MutatorSelector);
            this.Controls.Add(this.MutatorScene);
            this.Name = "TSPMutatorSelector";
            this.Text = "TSPMutatorSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox MutatorSelector;
        private Panel MutatorScene;
        private Label label1;
    }
}