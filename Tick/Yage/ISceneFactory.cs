namespace Tick.Yage;

public interface ISceneFactory
{
    public T CreateScene<T>() where T : Scene;
}

class SceneFactory : ISceneFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SceneFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateScene<T>() where T : Scene
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}