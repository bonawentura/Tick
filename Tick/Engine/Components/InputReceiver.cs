using System.Numerics;

namespace Tick.Engine.Components;

public class InputReceiver : Component
{
    private readonly Collider _boxCollider;
    private readonly InputManager _inputManager = InputManager.GetInstance();

    public InputReceiver()
    {
        _boxCollider = new BoxCollider(new RectF(new PointF(0, 0), new SizeF(10)));
    }

    public void InitializeCollider()
    {
        _boxCollider.SetGameObjet(Owner);
        _inputManager.Click += HandleClickEvent;
    }

    private void HandleClickEvent(object sender, ClickEventArgs e)
    {
        var hasCollision = _boxCollider.HasCollision(e.Target);
        Console.WriteLine(hasCollision);
        if (hasCollision) _inputManager.TargetHit(Owner, e);
    }

    ~InputReceiver()
    {
        // @todo: will crash if called after IM is destroyed
        _inputManager.Click -= HandleClickEvent;
    }
}

/*
 * @todo
 * Collider has to have a private shape that is transformable by Matrix3x2
 * so it can be transformed to check for collisions in world space
 * 
 */

public interface ICollider
{
    bool HasCollision(PointF target);
}

public abstract class Collider : Component, ICollider
{
    // private Rect _shape;

    protected IList<PointF> ColliderShapePoints { get; init; } = new List<PointF>();


    protected Matrix3x2 AncestorsTransform => Owner?.Transform.GetWorldTransform() ?? Matrix3x2.Identity;
    // protected Matrix3x2? AncestorsInverseTransform => Owner?.Transform.GetInverseWorldTransform();


    public abstract bool HasCollision(PointF target);
}

public class BoxCollider : Collider
{
    public BoxCollider(RectF box)
    {
        ColliderShapePoints = SetupShape(box);
    }

    public override bool HasCollision(PointF target)
    {
        var shape = GetCurrentShape();
        return shape.HasValue && shape.Value.Contains(target);
    }

    private List<PointF> SetupShape(RectF box)
    {
        var points = new List<PointF>
        {
            new(box.Left, box.Top),
            new(box.Right, box.Top),
            new(box.Right, box.Bottom),
            new(box.Left, box.Bottom)
        };
        return points;
    }

    private RectF? GetCurrentShape()
    {
        var transform = AncestorsTransform;
        var transformedPoints = ColliderShapePoints.Select(x => x.TransformBy(transform)).ToArray();
        var result = RectF.FromLTRB(transformedPoints[0].X, transformedPoints[0].Y, transformedPoints[2].X, transformedPoints[2].Y);
        return result;
    }
}