using Common;
using IOParsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA
{
    public partial class TSPOnePlusOneEA : Form
    {
        public TSPOnePlusOneEA()
        {
            InitializeComponent();
        }

        private void bitLength_label_Click(object sender, EventArgs e)
        {

        }

        private void bitLength_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            String file = (String)comboBox1.SelectedItem;
            ResourceManager.tspFiles.TryGetValue(file, out String[] tspFilePaths);
            CoordinateGraph g;
            if (tspFilePaths.Length<=1)
            {
                g = Parser.LoadTSPGraph(tspFilePaths[0]);
            }
            else
            {
                g = Parser.LoadTspGraphWithOpt(tspFilePaths[0],tspFilePaths[1]);
            }
            
            TSPOnePlusOneEAModel model = new TSPOnePlusOneEAModel();
            model.createAlgorithm(g);

            TSPManipV2 A_Form = new TSPManipV2(model);
            A_Form.Show();
        }
    }
}
