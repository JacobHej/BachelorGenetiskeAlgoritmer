using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization.Components
{
    public class OnionThing : IDrawable
    {
        private Point conorTR;
        private Size size;
        public OnionThing(Point conorTR, Size size)
        {
            this.conorTR = conorTR;
            this.size =  size;
        }

        public void Draw(Graphics g)
        {
            Point p1 = new Point(conorTR.X + (size.Width / 2), conorTR.Y); ;
            Point p3 = new Point(conorTR.X + (size.Width / 2), conorTR.Y + size.Height);

            //draw left
            Point p2 = new Point(conorTR.X-(size.Width/2), conorTR.Y + (size.Height / 2));
            ZeichneBezier(15, p1, p2, p3, g);

            p2 = new Point(conorTR.X + (size.Width*3 / 2), conorTR.Y + (size.Height / 2));
            ZeichneBezier(15, p1, p2, p3, g);
        }

        public void Draw2(Graphics g, int length, List<KeyValuePair<int, int>> actualWeights)
        {
            int heightInterval = size.Height / length;

            PointF[] pointsLeft = new PointF[length + 2];
            PointF[] pointsRight = new PointF[length + 2];

            // weights from only on bit to all btis
            int sum = 0;
            var halfWeights = Enumerable.Range(1, length / 2).Reverse().Select(i => sum += i).ToList();
            // concatinate the weights with the reversed verison (in the onion when you go up past the middle the weights should go down)
            halfWeights.AddRange(halfWeights.AsEnumerable().Reverse().ToList());
            var weights = halfWeights.ToArray();

            int maxWeight = sum;
            int weightOffset = (size.Width / 2) / maxWeight;
            int xCenter = conorTR.X + size.Width/2;

            pointsLeft[0] = new PointF(xCenter, conorTR.Y);
            pointsRight[0] = new PointF(xCenter, conorTR.Y);

            for (int i = 0; i < length; i++)
            {
                pointsLeft[i + 1] = new PointF(xCenter - weights[i] * weightOffset, conorTR.Y + heightInterval * (i + 1));
                pointsRight[i + 1] = new PointF(xCenter + weights[i] * weightOffset, conorTR.Y + heightInterval * (i + 1));
            }

            pointsLeft[length + 1] = new PointF(xCenter, conorTR.Y + size.Height + heightInterval);
            pointsRight[length + 1] = new PointF(xCenter, conorTR.Y + size.Height + heightInterval);

            Pen bkStift = new Pen(Color.Red, 2);
            g.DrawCurve(bkStift, pointsLeft);
            g.DrawCurve(bkStift, pointsRight);

            // draw the bit line
            PointF[] pointsBit = new PointF[actualWeights.Count + 2];

            pointsBit[actualWeights.Count + 1] = new PointF(xCenter, conorTR.Y);
            pointsBit[0] = new PointF(xCenter, conorTR.Y + size.Height + heightInterval);

            int count = 1;
            actualWeights.ForEach(
                x => {
                    PointF point = new PointF(xCenter + x.Key * weightOffset, conorTR.Y + size.Height - heightInterval * x.Value);
                    pointsBit[count] = point; 
                    count++;

                    g.DrawEllipse(bkStift, new Rectangle(new Point((int)point.X - 5, (int)point.Y - 5), new Size(10, 10)));
                });


            g.DrawCurve(bkStift, pointsBit);
        }


        /// <summary>
        /// https://stackoverflow.com/questions/51223909/how-to-draw-bezier-curve-c-sharp
        /// </summary>
        /// <param name="n"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        /// <param name="g"></param>
        private void ZeichneBezier(int n, Point P1, Point P2, Point P3, Graphics g)
        {
            Pen bkStift = new Pen(Color.Red, 2);
            Pen kpStift = new Pen(Color.Black, 3);

            if (n > 0)
            {
                Point P12 = new Point((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2);
                Point P23 = new Point((P2.X + P3.X) / 2, (P2.Y + P3.Y) / 2);
                Point P123 = new Point((P12.X + P23.X) / 2, (P12.Y + P23.Y) / 2);

                ZeichneBezier(n - 1, P1, P12, P123, g);
                ZeichneBezier(n - 1, P123, P23, P3, g);
            }
            else
            {
                g.DrawLine(bkStift, P1, P2);
                g.DrawLine(bkStift, P2, P3);
            }
        }
    }
}
