
namespace Tick.Core;



// public class Board : GameObject
// {
//     private readonly int _boardSize;
//
//     private readonly FieldState[,] _boardState = new FieldState[3, 3];
//
//     public Board(int boardSize = 3)
//     {
//         _boardSize = boardSize;
//     }
//
//     public void AddSymbol(int x, int y, FieldState fieldState)
//     {
//         if (_boardState[x, y] is not FieldState.None)
//             return;
//         _boardState[x, y] = fieldState;
//     }
//
//     public override void Render(ICanvas canvas, RectF dimensions)
//     {
//         base.Render(canvas, dimensions);
//         DrawBoard(canvas, dimensions);
//         DrawSymbols(canvas, dimensions);
//     }
//
//     private void DrawBoard(ICanvas canvas, RectF dirtyRect)
//     {
//         var width = dirtyRect.Width;
//         canvas.StrokeColor = Colors.Red;
//         canvas.StrokeSize = 1;
//
//         var cs = width / _boardSize;
//
//         for (var i = 1; i < _boardSize; i++) canvas.DrawLine(0, i * cs, _boardSize * cs, i * cs);
//         for (var i = 1; i < _boardSize; i++) canvas.DrawLine(i * cs, 0, i * cs, _boardSize * cs);
//
//         // AddObject(new SymbolCircle(new PointF(0, 0), cs));
//
//         // canvas.Translate(150, 100);
//     }
//
//     private void DrawSymbols(ICanvas canvas, RectF dim)
//     {
//         var cellWidth = dim.Width / _boardSize;
//         var celHalfWidth = cellWidth / 2f;
//
//         for (var i = 0; i < _boardSize; i++)
//         for (var j = 0; j < _boardSize; j++)
//         {
//             var cellState = _boardState[i, j];
//             var pivot = new PointF(j * cellWidth + celHalfWidth, i * cellWidth + celHalfWidth);
//
//             Symbol symbol = cellState switch
//             {
//                 FieldState.One => new SymbolCross(pivot),
//                 FieldState.Two => new SymbolCircle(pivot),
//                 _ => null
//             };
//
//             symbol?.Render(canvas, dim);
//         }
//     }
//
// }
//
// public abstract class Symbol : GameObject
// {
//     protected readonly PointF Pivot;
//     protected readonly float Width;
//
//     protected Symbol(PointF pivot)
//     {
//         Pivot = pivot;
//         Width = 0.3f;
//     }
// }
//
// public class SymbolCross : Symbol
// {
//     public SymbolCross(PointF pivot) : base(pivot)
//     {
//     }
//
//     public override void Render(ICanvas canvas, RectF dimensions)
//     {
//         var halfWidth = new SizeF(Width * dimensions.Width * .5f, 0);
//         var halfHeight = new SizeF(0, Width * dimensions.Width * .5f);
//
//         var tl = Pivot - halfWidth - halfHeight;
//         var br = Pivot + halfWidth + halfHeight;
//         var bl = Pivot - halfWidth + halfHeight;
//         var tr = Pivot + halfWidth - halfHeight;
//         canvas.DrawLine(tl, br);
//         canvas.DrawLine(bl, tr);
//     }
// }
//
// public class SymbolCircle : Symbol
// {
//     public SymbolCircle(PointF pivot) : base(pivot)
//     {
//     }
//
//     public override void Render(ICanvas canvas, RectF dimensions)
//     {
//         canvas.DrawCircle(Pivot, .5 * Width * dimensions.Width);
//     }
// }