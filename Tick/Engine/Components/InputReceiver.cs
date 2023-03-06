using System.Numerics;

namespace Tick.Engine.Components;

public class InputReceiver : Component
{
    private readonly Collider _boxCollider;
    private readonly InputManager _inputManager = InputManager.GetInstance();

    public InputReceiver()
    {
        _boxCollider = new Collider(new RectF(new PointF(0,0), new SizeF(10)));
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
public class Collider : Component
{
    private readonly PointF[] _points = new PointF[4];
    private Rect _shape;


    public Collider(RectF shape)
    {
        _shape = shape;
        var (x, y, w, h) = shape;
        _points[0] = new PointF(x, y);
        _points[1] = new PointF(x + w, y);
        _points[2] = new PointF(x + w, y + h);
        _points[3] = new PointF(x, y + h);
    }

    private Matrix3x2? AncestorsTransform => Owner?.Transform.GetWorldTransform();
    private Matrix3x2? AncestorsInverseTransform => Owner?.Transform.GetInverseWorldTransform();

    private RectF? GetCurrentShape()
    {
        var transform = AncestorsTransform ?? Matrix3x2.Identity;
        var transformedPoints = _points.Select(x => x.TransformBy(transform)).ToArray();
        var result = RectF.FromLTRB(transformedPoints[0].X, transformedPoints[0].Y, transformedPoints[2].X, transformedPoints[2].Y);
        return result;
    }


    public bool HasCollision(PointF target)
    {
        var transformedShape = GetCurrentShape();
        if (!transformedShape.HasValue) return false;

        var hasCollision = transformedShape.Value.Contains(target);
        return hasCollision;
    }
}