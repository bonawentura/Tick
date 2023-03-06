using System.Timers;
using Tick.Core;
using Timer = System.Timers.Timer;

namespace Tick.Pages;

public partial class GamePage : ContentPage
{
    // private readonly List<Type> _players = new()
    //     { typeof(SymbolCross), typeof(SymbolCircle) };
    //
    // private ActorInput _input = null;
    // private DateTime _lastTick = DateTime.Now;
    //
    // private int _playerIterator;
    // private bool _symbolLock = false;

    public GamePage()
    {
        InitializeComponent();
        var updateTimer = new Timer(50);
        updateTimer.Elapsed += (sender, args) => Update(50f / 1000);
        updateTimer.Start();

        var redrawTimer = new Timer(100);
        redrawTimer.Elapsed += Redraw;
        redrawTimer.Start();
    }

    private MainGame MainGameInstance => MainGameView.Drawable as MainGame;

//
//     private Type GetPlayerSymbol()
//     {
//         return _players[_playerIterator];
//     }
//
//     private void NextPlayerSymbol()
//     {
//         _playerIterator = (_playerIterator + 1) % 2;
//     }
//
//     private void DrawSymbol(PointF pivot)
//     {
//         var symbol = Activator.CreateInstance(GetPlayerSymbol(), pivot) as Symbol;
//         var drawable = (MainGame)MainGameView.Drawable;
//         drawable.AddObject(symbol);
//         _symbolLock = true;
//         
//         // drawable.Elems.Add(point);
//         // TickGraphicsView.Invalidate();
//     }
//
    public void Redraw(object source, ElapsedEventArgs e)
    {
        // var dt = e.SignalTime - _lastTick;
        // if (dt.Equals(TimeSpan.Zero))
        //     return;
        // _lastTick = e.SignalTime;
        //
        // var playScene = _mainGame.GetObject<Board>();
        //
        // // var drawable = (TmpDrawable)TickGraphicsView.Drawable;
        // // drawable.CellSize += 1;
        // // TickGraphicsView.Invalidate();
        // _mainGame.Update(dt.TotalMicroseconds);
        MainGameView.Invalidate();
        // _symbolLock = false;
    }

    public void Update(float dt)
    {
        MainGameInstance.Update(dt);
    }

//
    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        MainGameInstance.AddEvent(sender, e);
        // if (_symbolLock)
        //     return;
        // var containerPos = e.GetPosition((View)sender).GetValueOrDefault();
        // if (containerPos.IsEmpty)
        //     return;
        //
        // var point = new PointF((float)containerPos.X, (float)containerPos.Y);
        // DrawSymbol(point);
        // NextPlayerSymbol();
        //
        //
        // MainGameView.Invalidate();
        // var drawable = (TmpDrawable)TickGraphicsView.Drawable;
        // drawable.Elems.Add(point);
        // TickGraphicsView.Invalidate();
    }
// }
//
// public class ActorInput
// {
//     public ActorInput(PointF point, Symbol symbol)
//     {
//         Point = point;
//         Symbol = symbol;
//     }
//
//     public PointF Point { get; }
//     public Symbol Symbol { get; }
}