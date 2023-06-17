namespace Tick.Yage.Components;

public class GizmoRenderer : Renderer
{
    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Green;
        canvas.DrawRectangle(Owner.BoundsF); 
    }
}