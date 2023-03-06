using System.Numerics;

namespace Tick.Engine.Components;

public class Transform : Component
{
    public Matrix3x2 LocalPosition { get; set; } = Matrix3x2.Identity;
    public Matrix3x2 LocalScale { get; set; } = Matrix3x2.Identity;
    public Matrix3x2 GlobalPosition { get; set; } = Matrix3x2.Identity;
    public Matrix3x2 GlobalScale { get; set; } = Matrix3x2.Identity;

    /**
     * recursive call on each paint. ugly.
     */
    public Matrix3x2 GetWorldTransform()
    {
        if (Parent is null) return Matrix3x2.Identity;
        return LocalScale * LocalPosition * Parent.Transform.GetWorldTransform();
    }

    public Matrix3x2 GetInverseWorldTransform()
    {

        var worldTransform = GetWorldTransform();
        var inversedScale = Matrix3x2.CreateScale(1/worldTransform.M11, 1/worldTransform.M22);
        var inversedPosition = Matrix3x2.CreateTranslation(-worldTransform.M31, -worldTransform.M32);
        return inversedScale * inversedPosition;
    }
    
    public void Translate(float x, float y)
    {
        Translate(new Vector2(x, y));
    }

    public void Translate(Vector2 vec)
    {
        LocalPosition *= Matrix3x2.CreateTranslation(vec);
    }

    public void Scale(float scale)
    {
        Scale(Vector2.One * scale);
    }

    public void Scale(float x, float y)
    {
        Scale(new Vector2(x, y));
    }

    public void Scale(Vector2 scale)
    {
        LocalScale *= Matrix3x2.CreateScale(scale);
    }
}