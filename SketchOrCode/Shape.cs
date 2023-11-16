using System.Drawing;

namespace SketchOrCode
{
    abstract class Shape
    {
        protected Color colour; // colour of the shape  
        protected int x, y; //c# properties
        Pen p;



        public Shape(Color colour, int x, int y)
        {
            this.colour = colour; //shape color
            this.x = x; // x pos    
            this.y = y; // y pos
        }
        public abstract void draw(Graphics g);// any derived class must implement this method

        public override string ToString()
        {
            return base.ToString(); +" " + this.x + "," + this.y + ",";
        }

        public void PenColor(string color)
        {
            var clr
        }
    }
}
