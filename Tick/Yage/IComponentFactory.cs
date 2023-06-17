using Tick.Yage.Components;

namespace Tick.Yage;

public interface IComponentFactory
{
    public T CreateComponent<T>() where T : Component;
}