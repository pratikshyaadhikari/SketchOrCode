using System.Drawing;

namespace SketchOrCode
{
    internal class Circle : Shape
    {
        int radius;
        public Circle(Color colour, int radius, int x, int y) : base(colour, x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x, y, radius, 150);
            g.DrawEllipse(p, x, y, radius, 150);
        }
    }
}
