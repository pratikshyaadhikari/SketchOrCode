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
        public Triangle(Graphics graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }

        public override void Validate()
        {
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("Triangle param error");
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
            int size = 100;

            Point p = new Point(xPos, yPos);
            if (isFillOn)
            {
                Graphics.FillPolygon(Brushes.Aquamarine, new Point[] { p, new Point(x, y * 2), new Point(x + size, y * 2) });
            }
            else
            {
                Graphics.FillPolygon(Brushes.Aquamarine, new Point[] { p, new Point(x, y * 2), new Point(x + size, y * 2) });
            }
        }
    }
}
