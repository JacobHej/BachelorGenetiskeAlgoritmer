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

namespace GeneticAlgorithms.CreateSimulationForms.TSPSelector
{
    public partial class TSPSelector : Form
    {
        public TSPSelector()
        {
            InitializeComponent();
        }

        public CoordinateGraph getTSPProblem()
        {
            String file = (String)comboBox1.SelectedItem;
            ResourceManager.tspFiles.TryGetValue(file, out String[] tspFilePaths);
            CoordinateGraph g;
            if (tspFilePaths.Length <= 1)
            {
                g = Parser.LoadTSPGraph(tspFilePaths[0]);
            }
            else
            {
                g = Parser.LoadTspGraphWithOpt(tspFilePaths[0], tspFilePaths[1]);
            }
            return g;
        }
    }
}
