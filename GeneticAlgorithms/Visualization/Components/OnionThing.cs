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
        private Point conorTL;
        private Size size;
        public OnionThing(Point conorTL, Size size)
        {
            this.conorTL = conorTL;
            this.size =  size;
        }

        public void Draw(Graphics g)
        {
            Point p1 = new Point(conorTL.X + (size.Width / 2), conorTL.Y); ;
            Point p3 = new Point(conorTL.X + (size.Width / 2), conorTL.Y + size.Height);

            //draw left
            Point p2 = new Point(conorTL.X-(size.Width/2), conorTL.Y + (size.Height / 2));
            ZeichneBezier(15, p1, p2, p3, g);

            p2 = new Point(conorTL.X + (size.Width*3 / 2), conorTL.Y + (size.Height / 2));
            ZeichneBezier(15, p1, p2, p3, g);
        }

        private void drawBoundingBox(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            Point conorTR = new Point(conorTL.X + size.Width, conorTL.Y);
            Point conorBR = new Point(conorTL.X + size.Width, conorTL.Y + size.Height);
            Point conorBL = new Point(conorTL.X, conorTL.Y + size.Height);

            g.DrawLine(pen, conorTL, conorTR);
            g.DrawLine(pen, conorBR, conorTR);
            g.DrawLine(pen, conorBR, conorBL);
            g.DrawLine(pen, conorTL, conorBL);
        }

        public void drawEdge(Graphics g)
        {
            int length = 20;
            int sum = 0;
            double heightInterval = ((double)size.Height) / ((double)length);


            PointF[] pointsLeft = new PointF[length+1];
            PointF[] pointsRight = new PointF[length+1];

            var preciseWeights = Enumerable.Range(1, length / 2).Reverse();
            var halfWeights = preciseWeights.Select(i => sum += i).ToList();
            // concatinate the weights with the reversed verison (in the onion when you go up past the middle the weights should go down)
            halfWeights.AddRange(halfWeights.AsEnumerable().Reverse().ToList());
            int midValue = halfWeights[length/2];
            halfWeights.RemoveAt(length/2);
            var weights = halfWeights.ToArray();


            int maxWeight = midValue;
            double weightOffset = (((double)size.Width) / 2d) / ((double)maxWeight);
            int xCenter = conorTL.X + size.Width / 2;


            pointsLeft[0] = new PointF(xCenter, conorTL.Y);
            pointsRight[0] = new PointF(xCenter, conorTL.Y);

            for (int i = 0; i < weights.Length; i++)
            {
                pointsLeft[i+1] = new PointF((float)(xCenter - weights[i] * weightOffset), (float) (conorTL.Y + heightInterval * (i + 1)));
                pointsRight[i + 1] = new PointF((float)(xCenter + weights[i] * weightOffset), (float)(conorTL.Y + heightInterval * (i + 1)));
            }

            pointsLeft[length] = new PointF(xCenter, conorTL.Y + size.Height);
            pointsRight[length] = new PointF(xCenter, conorTL.Y + size.Height);

            Pen bkStift = new Pen(Color.Gray, 2);
            g.DrawCurve(bkStift, pointsLeft);
            g.DrawCurve(bkStift, pointsRight);

        }

        public void Draw2(Graphics g, int length, List<KeyValuePair<int, int>> actualWeights)
        {

            drawEdge(g);

            double heightInterval = ((double)size.Height) / ((double)length);

            List<PointF> pointsList = new List<PointF>();

            // weights from only on bit to all btis
            int sum = 0;
            Enumerable.Range(1, length / 2).Select(i => sum += i).ToList();

            double weightOffset = ((double)size.Width) / (double)(2*sum);
            int xCenter = conorTL.X + size.Width/2;

            pointsList.Add(new PointF(xCenter, conorTL.Y + size.Height));

            foreach (KeyValuePair<int, int> pair in actualWeights)
            {
                pointsList.Add(new PointF(xCenter+(int)(((double)pair.Key)*weightOffset),(float)(conorTL.Y+size.Height-heightInterval*pair.Value)));
            }



            Pen bkStift = new Pen(Color.Red, 2);

            // draw the bit line
            PointF[] pointsBit = new PointF[actualWeights.Count + 2];
            if (size.Width/length>5&&size.Height/length>5)
            {
                pointsList.ForEach(
                x => {
                    g.DrawEllipse(bkStift, new Rectangle(new Point((int)x.X - 5, (int)x.Y - 5), new Size(10, 10)));
                });
            }
            
            if (pointsList.Count()>1)
            {
                g.DrawLines(bkStift,pointsList.ToArray());
            }
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
