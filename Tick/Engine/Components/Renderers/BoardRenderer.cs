namespace Tick.Engine.Components.Renderers;

public class BoardRenderer : Renderer
{
    private readonly int _size;

    public BoardRenderer(int size = 3)
    {
        _size = size;
    }

    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        // var length = Math.Min(dirtyRect.Width, dirtyRect.Height);
        const float length = 400f;
        const float space = length / 3;
        canvas.StrokeSize = 2;
        canvas.StrokeColor = Colors.Red;
        for (var i = 1; i < _size; i++)
        {
            canvas.DrawLine(i * space, 0, i * space, length);
            canvas.DrawLine(0, i * space, length, i * space);
        }
    }
}