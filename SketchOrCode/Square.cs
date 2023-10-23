using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal class Square : Rectangle
    {
        protected int size;

        public Square(Color colour, int x, int y, int size) : base(colour, x, y, size, size)
        {
            this.size = size;
        }
        public override void draw(Graphics g)
        {
            Base.draw;

        }
    }
}
