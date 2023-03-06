using Tick.Engine.Components;
using Tick.Engine.Components.Renderers;

namespace Tick.Engine;

public abstract class GameObject : IDrawable
{
    private readonly List<Component> _components = new();
    public readonly List<GameObject> Children = new();

    protected GameObject()
    {
        AddComponent(new Transform());
    }

    public Transform Transform => GetComponent<Transform>();

    public GameObject Parent { get; private set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        Render(canvas, dirtyRect);
    }

    public T GetComponent<T>() where T : Component
    {
        return _components.OfType<T>().FirstOrDefault();
    }

    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return _components.OfType<T>();
    }

    public void AddComponent(Component component)
    {
        component.SetGameObjet(this);
        _components.Add(component);
    }

    public void AddChild(GameObject gameObject)
    {
        gameObject.Parent = this;
        Children.Add(gameObject);
    }

    private void RenderChildren(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var child in Children) child.Render(canvas, dirtyRect);
    }


    private void Render(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var renderer in GetComponents<Renderer>()) renderer.ProcessRender(canvas, dirtyRect);
        RenderChildren(canvas, dirtyRect);
    }


    // @todo: rewrite to make it an event handler?
    public virtual void Update(float dt)
    {
        Children.ForEach(child => child.Update(dt));
    }

    // @todo: move to interface :O
    public virtual void OnClick(EventArgs eventArgs)
    {
    }
}

public class Container : GameObject
{
}

public class GridObject : GameObject
{
    public GridObject()
    {
        var gridRenderer = new GridRenderer();
        AddComponent(gridRenderer);
    }
}

public class BoxObject : GameObject
{
}

public class Board : GameObject
{
    private readonly int _size = 3;

    public Board()
    {
        var renderer = new BoardRenderer();
        AddComponent(renderer);
        AddSymbols();
    }

    private void AddSymbols()
    {
        const float space = 400f / 3;
        for (var i = 0; i < _size; i++)
        for (var j = 0; j < _size; j++)
        {
            var symbol = new CrossSymbol();
            symbol.Transform.Translate(i * space, j * space);
            symbol.Transform.Translate(15, 15);
            symbol.Transform.Scale(10);
            AddChild(symbol);
        }
    }
}

public class CrossSymbol : GameObject
{
    public Color LocalColor = Colors.White;

    public CrossSymbol()
    {
        var renderer = new CrossRenderer();
        AddComponent(renderer);
        var inputReceiver = new InputReceiver();
        AddComponent(inputReceiver);
        inputReceiver.InitializeCollider();
    }

    public override void OnClick(EventArgs eventArgs)
    {
        LocalColor = Equals(LocalColor, Colors.White) ? Colors.Blue : Colors.White;
    }
}

public class CircleSymbol : GameObject
{
    public CircleSymbol()
    {
        AddComponent(new CircleRenderer());
    }
}