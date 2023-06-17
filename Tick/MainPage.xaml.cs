using Tick.Yage;
using Tick.Yage.Events;

namespace Tick;

public partial class MainPage : ContentPage
{
    private readonly ISceneManager _sceneManager;
    private readonly IMessageBus _messageBus;


    public MainPage(ISceneManager sceneManager, IMessageBus messageBus)
    {
        InitializeComponent();
        _sceneManager = sceneManager;
        _messageBus = messageBus;
        _sceneManager.LoadScene<MainMenuScene>(GameView);
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        // throw new NotImplementedException();
        var point = e.GetPosition(GameView);
        if (point is not null)
            _messageBus.Dispatch(new TapEvent((Point)point));
    }
}