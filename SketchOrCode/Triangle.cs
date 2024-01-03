using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    internal class Triangle : Shape
    {
        public Triangle(GraphicsAdapter graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }

        public override void Validate()
        {
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("Triangle param error. Required two param");
            }

            Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
            if (!isNumeric1)
            {
                throw new SketchApplicationException("Triangle param first value is not a number.");
            }

            Boolean isNumeric2 = int.TryParse(parameterList[1], out _);
            if (!isNumeric2)
            {
                throw new SketchApplicationException("Triangle param second value is not a number.");
            }
        }

        public override void Draw()
        {
            int x = int.Parse(parameterList[0]);
            int y = int.Parse(parameterList[1]);
            

            Point p = new Point(xPos, yPos);
            if (isFillOn)
            {
                Graphics.FillPolygon(new SolidBrush(color), xPos, yPos, x, y);
            }
            else
            {
                Graphics.DrawPolygon(new Pen(color), xPos, yPos, x, y); ;
            }
        }
    }
}
