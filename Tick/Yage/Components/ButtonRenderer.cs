using Font = Microsoft.Maui.Graphics.Font;

namespace Tick.Yage.Components;

public class ButtonRenderer : Renderer
{
    private string _text = String.Empty;
    private float _borderSize = 1f;

    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        var pos = Transform.LocalPositionPointF;
        canvas.Font = Font.Default;
        canvas.DrawString(_text, pos.X, pos.Y, Owner.Size.Width, Owner.Size.Height, HorizontalAlignment.Center, VerticalAlignment.Top);
        canvas.StrokeSize = _borderSize;
        canvas.DrawRectangle(Owner.BoundsF);
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public void SetBorderSize(float size)
    {
        _borderSize = size;
    }
    
    
    
}