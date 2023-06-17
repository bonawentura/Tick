namespace Tick.Yage.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseYage(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<ISceneManager, SceneManager>()
            .AddSingleton<IMessageBus, MessageBus>()
            .AddSingleton<IGameObjectFactory, GameObjectFactory>()
            .AddSingleton<ISceneFactory, SceneFactory>()
            ;
        
        return builder;
    }
}