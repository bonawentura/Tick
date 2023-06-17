namespace Tick.Yage;

public class GameSceneView : GraphicsView
{
    private IScene _scene;

    public IScene Scene
    {
        get => _scene;
        set
        {
            _scene = value;
            Drawable = value;
        }
    }
}