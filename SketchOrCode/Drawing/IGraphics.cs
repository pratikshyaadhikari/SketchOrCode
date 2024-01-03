using System.Drawing;

public interface IGraphics
{
    void Clear(Color systemColor);
    void FillRectangle(SolidBrush color, int xPos, int yPos, int Length, int Width);
    void DrawRectangle(Pen color, int xPos, int yPos, int Length, int Width);
    void FillEllipse(SolidBrush color, int xPos, int yPos, int radius);
    void DrawEllipse(Pen color, int xPos, int yPos, int radius);

    void DrawLine(Pen color, int xPos, int yPos, int xPoint, int yPoint);

    void FillPolygon(SolidBrush color, int xPos, int yPos, int x, int y);

    void DrawPolygon(Pen color, int xPos, int yPos, int x, int y);

}