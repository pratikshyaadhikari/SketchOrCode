using System.Drawing;

namespace SketchOrCode
{
    internal class Square : Rectangle
    {
        protected int size;

        public Square(Color colour, int x, int y, int size) : base(colour, x, y, size, size)
        {
            this.size = size;
        }

    }
}
