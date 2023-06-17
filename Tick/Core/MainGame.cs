using Tick.Engine;

namespace Tick.Core;

// public class MainGame : IDrawable
// {
    // private readonly InputManager _inputManager = InputManager.GetInstance();
    // private readonly GameObject _mainGameObject;
    //
    // public MainGame()
    // {
    //     _mainGameObject = new Container();
    //     _mainGameObject.AddChild(new GridObject());
    //     _mainGameObject.AddChild(InputManager.GetInstance());
    //     var board = new Board();
    //     _mainGameObject.AddChild(board);
    // }
    //
    // public void Draw(ICanvas canvas, RectF dirtyRect)
    // {
    //     _mainGameObject.Draw(canvas, dirtyRect);
    // }
    //
    // public void Update(float dt)
    // {
    //     _mainGameObject.Update(dt);
    // }
    //
    // // @todo: this event shouldn't be drilled down
    // public void AddEvent(object sender, TappedEventArgs e)
    // {
    //     _inputManager.AddEvent(sender, e);
    // }
// }