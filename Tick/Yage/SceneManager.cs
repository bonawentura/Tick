using Tick.Yage.Components;
using Tick.Yage.Events;

namespace Tick.Yage;

public class SceneManager : ISceneManager
{
    private Scene _activeScene;

    private GameSceneView _gameSceneView;

    private readonly IServiceScopeFactory _serviceScopeFactory;
    private IServiceScope _serviceScope;
    private readonly IMessageBus _messageBus;

    public SceneManager(IMessageBus messageBus, IServiceScopeFactory serviceScopeFactory)
    {
        _messageBus = messageBus;
        _serviceScopeFactory = serviceScopeFactory;
        _messageBus.SceneEvent += OnSceneEvent;
    }

    public void OnSceneEvent(object _, EventArgs e)
    {
        switch (e)
        {
            case TapEvent tap:
                OnTapped(tap);
                break;
        }
    }

    // @todo yuck
    private void OnTapped(TapEvent e)
    {
        var colliders = _activeScene.Children.SelectMany(x => x.GetComponents<Component.Collider>());
        foreach (var collider in colliders)
        {
            var hit = collider.HasCollision(e.point);
            Console.WriteLine(hit);
        }
    }

    public void LoadScene<TScene>(GameSceneView view) where TScene : Scene
    {
        _serviceScope?.Dispose();
        _serviceScope = _serviceScopeFactory.CreateScope();
        var scene = _serviceScope.ServiceProvider.GetRequiredService<TScene>();

        _activeScene = null;
        _activeScene = scene;
        _gameSceneView = view;
        view.Scene = _activeScene;
    }

    ~SceneManager()
    {
        _messageBus.SceneEvent -= OnSceneEvent;
    }
}