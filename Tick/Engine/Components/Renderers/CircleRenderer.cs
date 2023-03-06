namespace Tick.Engine.Components.Renderers;

public class CircleRenderer : Renderer
{
    public Color Color { get; set; } = Colors.Red;

    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Color;
        canvas.DrawEllipse(5, 5, 10, 10);
    }
}