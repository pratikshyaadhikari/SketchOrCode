using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal class Circle : Shape
    {
        public Circle(GraphicsAdapter graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }

        public override void Validate()
        {
            if (parameterList.Count != 1)
            {
                throw new SketchApplicationException("Circle param error. Required one param");
            }

            Boolean isNumeric = int.TryParse(parameterList[0], out _);
            if (!isNumeric)
            {
                throw new SketchApplicationException("Circle param value is not a number.");
            }
        }

        public override void Draw()
        {
            int radius = int.Parse(parameterList[0]);

            if (isFillOn)
            {
                Graphics.FillEllipse(new SolidBrush(color), xPos, yPos , radius);
            }
            else
            {
                Graphics.DrawEllipse(new Pen(color), xPos, yPos, radius);
            }
        }
    }
}
