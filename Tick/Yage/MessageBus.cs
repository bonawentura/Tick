using Tick.Yage.Events;

namespace Tick.Yage;

public class MessageBus : IMessageBus
{
    public event EventHandler<EventArgs> NextMessage;
    public event EventHandler<EventArgs> SceneEvent;
    
    public void Dispatch(EventArgs args, object sender = null)
    {
        switch (args)
        {
            case LoadSceneEvent load:
                SceneEvent?.Invoke(null, load);
                break;
            case TapEvent tap:
                SceneEvent?.Invoke(null, tap);
                break;
        }
    }
}