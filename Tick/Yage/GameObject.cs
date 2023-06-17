using Tick.Yage.Components;

namespace Tick.Yage;

public abstract class GameObject : IGameObject
{
    private readonly List<Component> _components = new List<Component>();
    private readonly List<GameObject> _children = new List<GameObject>();

    public Transform Transform => GetComponent<Transform>();
    public SizeF Size = SizeF.Zero; // @todo: change to SizeF?
    public RectF BoundsF => new(Transform.LocalPositionPointF, Size);
    public IList<GameObject> Children => _children;
    public GameObject Parent { get; set; }
    
    
    protected GameObject()
    {
        AddComponent(new Transform());
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

    public void Render(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SetFillPaint(new SolidPaint(Colors.Beige), dirtyRect);
        canvas.FillRectangle(dirtyRect);
        foreach (var renderer in GetComponents<Renderer>())
        {
            renderer.ProcessRender(canvas, dirtyRect);
        }

        foreach (var child in Children)
        {
            child.Render(canvas, dirtyRect);
        }
    }
}