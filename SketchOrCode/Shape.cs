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
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("DrawTo param error");
            }

            Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
            if (!isNumeric1)
            {
                throw new SketchApplicationException("DrawTo param first value is not a number.");
            }

            Boolean isNumeric2 = int.TryParse(parameterList[1], out _);
            if (!isNumeric2)
            {
                throw new SketchApplicationException("DrawTo param second value is not a number.");
            }

        }

        public virtual void Draw()
        {
            int xPoint = int.Parse(parameterList[0]);
            int yPoint = int.Parse(parameterList[1]);

            Graphics.DrawLine(new Pen(color), new PointF(xPos, yPos), new PointF(xPoint, yPoint));

        }
    }
}
