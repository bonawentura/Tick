namespace Tick.Yage.Components;

public abstract class Component
{
    protected GameObject Owner;
    protected GameObject Parent => Owner.Parent;
    protected Transform Transform => Owner.Transform;

    public void SetGameObjet(GameObject gameObject)
    {
        Owner = gameObject;
        OnComponentAdded();
    }

    protected virtual void OnComponentAdded(){}

    protected IList<GameObject> ParentChildren()
    {
        return Owner.Children;
    }

    public abstract class Collider : Component, ICollider
    {
        public virtual bool HasCollision(PointF point)
        {
            throw new NotImplementedException();
        }
    }

    public class BoxCollider : Collider
    {
        private readonly GizmoRenderer _gizmoRenderer;

        public BoxCollider(GizmoRenderer gizmoRenderer)
        {
            _gizmoRenderer = gizmoRenderer;
        }

        protected override void OnComponentAdded()
        {
            Owner.AddComponent(_gizmoRenderer);

        }

        public override bool HasCollision(PointF point)
        {
            
            var collisionPoint = point.TransformBy(Owner.Transform.GetInverseWorldTransform());
            return Owner.BoundsF.Contains(collisionPoint);
        }
    }
}

public interface ICollider
{
    bool HasCollision(PointF point);
}