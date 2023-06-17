namespace Tick.Yage;

public interface IGameObjectFactory
{
    T Create<T>() where T : GameObject;
}