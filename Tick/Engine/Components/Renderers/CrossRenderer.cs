// namespace Tick.Engine.Components.Renderers;
//
// public class CrossRenderer : Renderer
// {
//     public override void Render(ICanvas canvas, RectF dirtyRect)
//     {
//         var tl = new PointF(0, 0);
//         var tr = new PointF(10, 0);
//         var bl = new PointF(0, 10);
//         var br = new PointF(10, 10);
//
//         var path = new PathF();
//         path.MoveTo(tl);
//         path.LineTo(br);
//         path.MoveTo(bl);
//         path.LineTo(tr);
//
//         canvas.StrokeColor = (Owner as CrossSymbol)?.LocalColor;
//         canvas.DrawPath(path);
//     }
// }