using Tick.Yage.Components;
using Button = Tick.Yage.Components.Button;

namespace Tick.Yage.Extensions;

public static class GameObjectsExtensions
{
    public static IServiceCollection RegisterGameObjects(this IServiceCollection services)
    {
        services
            // Objects
            .AddTransient<Button>()
            // Components
            .AddTransient<ButtonRenderer>()
            .AddTransient<GizmoRenderer>()
            .AddTransient<Component.BoxCollider>()
            // Scenes
            .AddTransient<MainMenuScene>();

        return services;
    }
}