using System.Numerics;

namespace Tick.Engine.Components.Renderers;

public class BoxRenderer : Renderer
{
    public Vector2 Dimensions { get; set; }
    public Vector2 Pivot { get; set; } = Vector2.Zero;
    public Color SelfColor { get; set; } = Colors.Red;
    public float StrokeSize { get; set; } = 1;


    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        var rect = new RectF(new PointF(Pivot), new SizeF(Dimensions));

        canvas.StrokeColor = SelfColor;
        canvas.StrokeSize = StrokeSize;
        canvas.DrawRectangle(rect);
    }
}