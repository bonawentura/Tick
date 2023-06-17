namespace Tick.Yage;

public interface IScene : IDrawable, IRender, IUpdate {}

public abstract class Scene : GameObject, IScene
{
    public void Draw(ICanvas canvas, RectF dirtyRect) => Render(canvas, dirtyRect);

    public void Update(double dt)
    {
        throw new NotImplementedException();
    }
}

public interface IRender
{
    public void Render(ICanvas canvas, RectF dirtyRect);
}

public interface IUpdate
{
    public void Update(double dt);
}