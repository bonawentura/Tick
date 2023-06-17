namespace Tick.Yage.Components;

public  class Button : GameObject
{
    private string _label;
    public string Label
    {
        get => _label;
        set
        {
            _buttonRenderer.SetText(value);
            _label = value;
        }
    }

    public float BorderSize { get; set; } = 1f;
    
    public event EventHandler<EventArgs> Click;

    private readonly ButtonRenderer _buttonRenderer;
    private readonly Component.BoxCollider _boxCollider; 
    public Button(ButtonRenderer buttonRenderer, Component.BoxCollider boxCollider)
    {
        _buttonRenderer = buttonRenderer;
        _boxCollider = boxCollider;
        AddComponent(_buttonRenderer);
        AddComponent(_boxCollider);
    }
}