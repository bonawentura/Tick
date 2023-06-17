// namespace Tick.Engine;
//
// public class ClickEventArgs : EventArgs
// {
//     public readonly PointF Target;
//
//     public ClickEventArgs(PointF target)
//     {
//         Target = target;
//     }
// }
//
// public sealed class InputManager : GameObject
// {
//     private static InputManager _instance;
//     private readonly List<EventArgs> _frameEvents = new();
//     private readonly List<(GameObject, EventArgs)> _triggeredObjects = new();
//
//     private InputManager()
//     {
//     }
//
//     public static InputManager GetInstance()
//     {
//         _instance ??= new InputManager();
//         return _instance;
//     }
//
//     public event EventHandler<ClickEventArgs> Click;
//
//     public void TargetHit(GameObject gameObject, EventArgs evt)
//     {
//         _triggeredObjects.Add((gameObject, evt));
//     }
//
//     // @todo: input manager shouldn't need a to know about MAUI TappedEventArgs and View cast
//     public void AddEvent(object sender, TappedEventArgs evt)
//     {
//         var eventPosition = evt.GetPosition((View)sender);
//         if (!eventPosition.HasValue)
//             return;
//
//         var (x, y) = eventPosition.Value;
//         var target = new PointF(Convert.ToSingle(x), Convert.ToSingle(y));
//         var clickEvent = new ClickEventArgs(target);
//         _frameEvents.Add(clickEvent);
//     }
//
//     private void OnClick(ClickEventArgs e)
//     {
//         Click?.Invoke(this, e);
//     }
//
//
//     private void ProcessEvents()
//     {
//         _frameEvents.ForEach(BroadcastEvent);
//         
//         foreach (var (gameObject, evt) in _triggeredObjects)
//         {
//             gameObject.OnClick(evt);
//         }
//
//     }
//
//     private void OnEndFrame()
//     {
//         _triggeredObjects.Clear();
//         _frameEvents.Clear();
//     }
//
//     private void BroadcastEvent(EventArgs evt)
//     {
//         if (evt is ClickEventArgs e)
//             OnClick(e);
//     }
//
//     public override void Update(float dt)
//     {
//         ProcessEvents();
//         OnEndFrame();
//     }
// }