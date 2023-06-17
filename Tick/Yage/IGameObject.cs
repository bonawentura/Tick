using Tick.Yage.Components;

namespace Tick.Yage;

public interface IGameObject
{
    Transform Transform { get; }
    IList<GameObject> Children { get; }
    GameObject Parent { get; set; }
    T GetComponent<T>() where T : Component;
    IEnumerable<T> GetComponents<T>() where T : Component;
    void AddComponent(Component component);
    void AddChild(GameObject gameObject);
}