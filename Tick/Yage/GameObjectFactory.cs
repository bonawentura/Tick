namespace Tick.Yage;

public class GameObjectFactory : IGameObjectFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private IServiceScope _serviceScope;

    public GameObjectFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public T Create<T>() where T : GameObject
    {
        // var type = _serviceScope.ServiceProvider.GetRequiredService<T>();
        _serviceScope?.Dispose();

        _serviceScope = _serviceScopeFactory.CreateScope();

        var type = _serviceScope.ServiceProvider.GetRequiredService<T>();
        return type;
    }
}