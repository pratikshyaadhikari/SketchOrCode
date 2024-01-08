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
#pragma warning disable CS0649 // Field 'Square.size' is never assigned to, and will always have its default value 0
        protected int size;
#pragma warning restore CS0649 // Field 'Square.size' is never assigned to, and will always have its default value 0

        public Square(GraphicsAdapter graphics, bool isFillOn, Color color, int xPos, int yPos, List<string> parameter) : base(graphics, isFillOn, color, xPos, yPos, parameter)
        {
        }

        public override void Validate()
        {
            if (parameterList.Count != 2)
            {
                throw new SketchApplicationException("Square param error. Required two param");
            }

            Boolean isNumeric1 = int.TryParse(parameterList[0], out _);
            if (!isNumeric1)
            {
                throw new SketchApplicationException("Square param first value is not a number.");
            }

            Boolean isNumeric2 = int.TryParse(parameterList[1], out _);
            if (!isNumeric2)
            {
                throw new SketchApplicationException("Square param second value is not a number.");
            }
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual void Draw()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            //implemented in child cmd process class
        }

    }
}
