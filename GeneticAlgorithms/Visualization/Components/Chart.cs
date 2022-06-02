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
        public List<double> values = new List<double>();
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
            new ChartLine(location, new Point(location.X, location.Y + height), Color.Black, 3).Draw(g);
            new ChartLine(new Point(location.X, location.Y + height), new Point(location.X + width, location.Y + height), Color.Black, 3).Draw(g);

            Point lowerLeft = new Point(location.X, location.Y + height);
            double offSet = ((double)width - (double)20) / values.Count;
            double jump = 1;
            while (offSet < 1)
            {
                jump = jump / offSet;
                offSet = 1;
                
            }
            
            List<double> normalizedValues = new List<double>();
            double maxVal = values.MaxBy(x => x);
            values.ForEach(x => normalizedValues.Add(x / maxVal));
            
            for (double i = 0; i < Math.Min(values.Count,(width-20)); i++)
            {
                Point p1 = new Point(lowerLeft.X + (int)(i * offSet) + 10, lowerLeft.Y);
                Point p2 = new Point(location.X + (int)(i * offSet) + 10, (int)Math.Round(lowerLeft.Y - (lowerLeft.Y - location.Y) * normalizedValues[(int)(i*jump)]));
                new ChartLine(p1, p2, Color.Blue, (float)(offSet * 0.1)).Draw(g);
            }

            g.DrawString(titel, new Font("Arial", 16), new SolidBrush(Color.Black), new Point(lowerLeft.X, lowerLeft.Y + 10));
            g.DrawString("Highest Value", new Font("Arial", 16), new SolidBrush(Color.Black), new Point(location.X, location.Y - 30));
            g.DrawString(maxVal.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), new Point(location.X - 15 * maxVal.ToString().Length, location.Y));
        }
    }
}
