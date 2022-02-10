using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization.Components
{
    public class Chart : IDrawable
    {
        private String titel;
        public List<int> values = new List<int>();
        private int height;
        private int width;
        private Point location;

        public Chart(int height, int width, Point location, string titel)
        {
            this.height = height;
            this.width = width;
            this.titel = titel;
            this.location = location;
        }

        public void Draw(Graphics g)
        {
            // draw left and botton
            new ChartLine(location, new Point(location.X, location.Y + height), Color.Black).Draw(g);
            new ChartLine(new Point(location.X, location.Y + height), new Point(location.X + width, location.Y + height), Color.Black).Draw(g);

            Point lowerLeft = new Point(location.X, location.Y + height);
            int offSet = width / values.Count;

            for (int i = 0; i < values.Count; i++)
            {

            }
        }
    }
}
