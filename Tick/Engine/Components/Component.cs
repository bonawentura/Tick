namespace Tick.Engine.Components;

public abstract class Component
{
    protected GameObject Owner;
    protected GameObject Parent => Owner.Parent;
    protected Transform Transform => Owner.Transform;

    public void SetGameObjet(GameObject gameObject)
    {
        Owner = gameObject;
    }

    protected IList<GameObject> ParentChildren()
    {
        return Owner.Children;
    }
}