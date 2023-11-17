using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal class Rectangle:Shape
    {
        protected int width, height;
        public Rectangle(Graphics graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }
        public override void Validate()
        {
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("Rectangle param error");
            }

            Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
            if (!isNumeric1)
            {
                throw new SketchApplicationException("Rectangle param first value is not a number.");
            }

            Boolean isNumeric2 = int.TryParse(parameterList[1], out _);
            if (!isNumeric2)
            {
                throw new SketchApplicationException("Rectangle param second value is not a number.");
            }
        }

        public override void Draw()
        {
            int Length = int.Parse(parameterList[0]);
            int Width = int.Parse(parameterList[1]);

            if (isFillOn)
            {
                Graphics.FillRectangle(new SolidBrush(color), xPos, yPos, Length, Width);
            }
            else
            {
                Graphics.DrawRectangle(new Pen(color), xPos, yPos, Length, Width);
            }
        }

    }

}
