namespace Tick.Engine.Components.Renderers;

public class GridRenderer : Renderer
{
    public float VerticalStep { get; set; } = 100;
    public float HorizontalStep { get; set; } = 100;
    public Color StrokeColor { get; set; } = Colors.White;
    public float StrokeSize { get; set; } = 1;

    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = StrokeColor;
        canvas.StrokeSize = StrokeSize;
        var verticalPos = 0f;
        while (verticalPos <= dirtyRect.Height)
        {
            canvas.DrawLine(0, verticalPos, dirtyRect.Width, verticalPos);
            verticalPos += VerticalStep;
        }

        var horizontalPos = 0f;
        while (horizontalPos <= dirtyRect.Width)
        {
            canvas.DrawLine(horizontalPos, 0, horizontalPos, dirtyRect.Height);
            horizontalPos += HorizontalStep;
        }
    }
}