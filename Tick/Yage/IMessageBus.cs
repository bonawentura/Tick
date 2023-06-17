namespace Tick.Yage;

public interface IMessageBus
{
    public event EventHandler<EventArgs> NextMessage;

    public event EventHandler<EventArgs> SceneEvent;

    public void Dispatch(EventArgs args, object sender = null);
}