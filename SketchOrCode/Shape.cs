using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    abstract class Shape
    {
        protected Graphics Graphics;
        protected bool isFillOn;
        protected Color color;
        protected int xPos;
        protected int yPos;
        protected List<String> parameterList;

        public Shape(Graphics graphics, bool isFillOn, Color color, int xPos, int yPos, List<String> parameterList)
        {
            Graphics = graphics;
            this.isFillOn = isFillOn;
            this.color = color;
            this.xPos = xPos;
            this.yPos = yPos;
            this.parameterList = parameterList;
        }

        public virtual void Validate()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
