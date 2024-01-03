using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SketchOrCode
{
    public class GraphicsAdapter : IGraphics
    {
        Graphics Graphics;

        public GraphicsAdapter()
        {
           
        }

        public GraphicsAdapter(Graphics graphics)
        {
            this.Graphics = graphics;
        }

        public void Clear(Color systemColor)
        {
            Graphics.Clear(systemColor);
        }

        public void FillRectangle(SolidBrush color, int xPos, int yPos, int Length, int Width)
        {
            Graphics.FillRectangle(color, xPos, yPos, Length, Width);
        }

        public void DrawRectangle(Pen color, int xPos, int yPos, int Length, int Width)
        {
            Graphics.DrawRectangle(color, xPos, yPos, Length, Width);
        }

        public void FillEllipse(SolidBrush color, int xPos, int yPos, int radius)
        {
            Graphics.FillEllipse(color, xPos - radius, yPos - radius, 2 * radius, 2 * radius);

        }


        public void DrawEllipse(Pen color, int xPos, int yPos, int radius)
        {
            Graphics.DrawEllipse(color, xPos - radius, yPos - radius, 2 * radius, 2 * radius);

        }


        public void DrawLine(Pen color, int xPos, int yPos, int xPoint, int yPoint)
        {
            Graphics.DrawLine(color, new PointF(xPos, yPos), new PointF(xPoint, yPoint));
        }


        public void FillPolygon(SolidBrush color, int xPos, int yPos, int x, int y)
        {
            Point p = new Point(xPos, yPos);
            int size = 100;
            Graphics.FillPolygon(color, new Point[] { p, new Point(x, y * 2), new Point(x + size, y * 2) });
        }

        public void DrawPolygon(Pen color, int xPos, int yPos, int x, int y)
        {
            Point p = new Point(xPos, yPos);
            int size = 100;
            Graphics.DrawPolygon(color, new Point[] { p, new Point(x, y * 2), new Point(x + size, y * 2) });
        }

    }
}
