namespace GeneticAlgorithms.CreateSimulationForms.ACOSelector
{
    partial class ACOSelector
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

            this.SuspendLayout();

            int size = 150;
            int x20 = 500 - size;
            int x21 = 500;
            int x30 = 500 - size * 3 / 2;
            int x31 = 500 - size / 2;
            int x32 = 500 + size / 2;

            for (int i = 0; i<n; i++)
            {
                Label l = new Label();
                l.Text = names[i];
                l.Name = names[i];
                l.Anchor = System.Windows.Forms.AnchorStyles.Top;
                l.AutoSize = true;
                l.MinimumSize = new System.Drawing.Size(size, 20);
                l.Size = new System.Drawing.Size(size, 20);
                l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labels[i] = l;

                TextBox t = new TextBox();
                t.Anchor = System.Windows.Forms.AnchorStyles.Top;
                t.Name = names[i]+"Input";
                t.Size = new System.Drawing.Size(size, 30);
                t.TabIndex = 0;
                inputs[i] = t;

                this.Controls.Add(l);
                this.Controls.Add(t);

                switch (names[i])
                {
                    case "alpha":
                        l.Location = new System.Drawing.Point(x20, 0);
                        t.Location = new System.Drawing.Point(x20, 50);
                        t.Text = "1";
                        break;
                    case "beta":
                        l.Location = new System.Drawing.Point(x21, 0);
                        t.Location = new System.Drawing.Point(x21, 50);
                        t.Text = "1";
                        break;
                    case "p":
                        l.Location = new System.Drawing.Point(x20, 100);
                        t.Location = new System.Drawing.Point(x20, 150);
                        t.Text = "0.9";
                        break;
                    case "q":
                        l.Location = new System.Drawing.Point(x21, 100);
                        t.Location = new System.Drawing.Point(x21, 150);
                        t.Text = "1";
                        break;
                    case "initialPheremone":
                        l.Location = new System.Drawing.Point(x30, 200);
                        t.Location = new System.Drawing.Point(x30, 250);
                        t.Text = "1";
                        break;
                    case "nrOfAnts":
                        l.Location = new System.Drawing.Point(x31, 200);
                        t.Location = new System.Drawing.Point(x31, 250);
                        t.Text = "10";
                        break;
                    case "selectXBest":
                        l.Location = new System.Drawing.Point(x32, 200);
                        t.Location = new System.Drawing.Point(x32, 250);
                        t.Text = "10";
                        break;
                }
            }
            // 
            // ACOSelector
            // 
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Name = "MuPlusLambdaSelector";
            this.Text = "MuPlusLambdaSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private static int n = 7;
        private String[] names = new String[] {
            "alpha",
            "beta",
            "p",
            "q",
            "initialPheremone",
            "nrOfAnts",
            "selectXBest"
        };
        private Label[] labels = new Label[n];
        private TextBox[] inputs = new TextBox[n];
    }
}