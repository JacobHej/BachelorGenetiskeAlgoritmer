namespace GeneticAlgorithms.CreateSimulationForms.VariableSelector
{
    partial class VariableSelector
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

        protected void InitializeComponent()
        {


            this.SuspendLayout();




            int size = 150;

            for (int i = 0; i<variables.Count(); i++)
            {
                string name = variables[i].name;
                Label l = new Label();
                variables[i].label = l;
                l.Text = name;
                l.Name = name;
                l.Anchor = System.Windows.Forms.AnchorStyles.Top;
                l.AutoSize = true;
                l.MinimumSize = new System.Drawing.Size(size, 20);
                l.Size = new System.Drawing.Size(size, 20);
                l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labels.Add(name, l);

                TextBox t = new TextBox();
                variables[i].input = t;
                t.Anchor = System.Windows.Forms.AnchorStyles.Top;
                t.Name = name + "Input";
                t.Size = new System.Drawing.Size(size, 30);
                t.TabIndex = 0;
                inputs.Add(name, t);

                this.Controls.Add(l);
                this.Controls.Add(t);

                l.Location = new System.Drawing.Point(500-size/2, i*60);
                t.Location = new System.Drawing.Point(500 - size / 2, i * 60+20);
                int holder = i;
                

                switch (variables[i])
                {
                    case intVariable v:
                        t.Text = v.value.ToString();
                        t.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfIntegerOnKeyPress);
                        t.TextChanged += new EventHandler((obj, e) => {
                            try
                            {
                                variables[holder].onChange();
                            }
                            catch
                            {
                                t.Text = v.value + "";
                            }
                        });
                        break;
                    case doubleVariable v:
                        t.Text = v.value.ToString();
                        t.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkIfDoubleOnKeyPress);
                        t.TextChanged += new EventHandler((obj, e) => {
                            try
                            {
                                variables[holder].onChange();
                            }
                            catch
                            {
                                t.Text = v.value + "";
                            }
                        });
                        break;
                }
            }

            this.AutoScroll = true;

            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Name = "VariableSelector";
            this.Text = "VariableSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        
    }
}