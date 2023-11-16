namespace SketchOrCode
{
    internal class Rectangle : Shape
    {
        protected int width, height;
        public Rectangle(int width, int height)
        {
            this.width = width;// different from shape
            this.height = height;
        }
        private override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(p, x, y, width, height);
        }
    }

}
