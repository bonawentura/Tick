namespace Tick.Yage.Events;

public class SceneEvent : EventArgs
{
    
}

public class LoadSceneEvent : SceneEvent
{
    public Scene Scene { get; set; }
}

public class TapEvent : EventArgs
{
    public TapEvent(Point point)
    {
        this.point = point;
    }

    public Point point { get; set; }
}