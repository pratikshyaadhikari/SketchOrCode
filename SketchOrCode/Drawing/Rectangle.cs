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
#pragma warning disable CS0649 // Field 'Rectangle.height' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'Rectangle.width' is never assigned to, and will always have its default value 0
        protected int width, height;
#pragma warning restore CS0649 // Field 'Rectangle.width' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'Rectangle.height' is never assigned to, and will always have its default value 0
        public Rectangle(GraphicsAdapter graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }
        public override void Validate()
        {
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("Rectangle param error. Required two param");
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
