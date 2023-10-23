﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal abstract class Shape
    {
        protected Color colour; // colour of the shape  
        protected int x, y; //c# properties


        public Shape(Color colour, int x, int y)
        {
            this.colour = colour; //shape color
            this.x = x; // x pos    
            this.y = y; // y pos
        }
        abstract public void draw(Graphics g);
    }
}
