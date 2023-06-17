namespace Tick.Yage.Components;

public abstract class Renderer : Component
{
    private void OnBeforeRender(ICanvas canvas)
    {
        canvas.ConcatenateTransform(Transform.GetWorldTransform());
    }

    private void OnAfterRender(ICanvas canvas)
    {
        canvas.ResetState();
    }

    public void ProcessRender(ICanvas canvas, RectF dirtyRect)
    {
        OnBeforeRender(canvas);
        Render(canvas, dirtyRect);
        OnAfterRender(canvas);
    }


    public abstract void Render(ICanvas canvas, RectF dirtyRect);
}