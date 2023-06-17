using System.Numerics;
using Button = Tick.Yage.Components.Button;

namespace Tick.Yage;

/**
 * has one button and has to receive and send messages to scene manager
 */
public class MainMenuScene : Scene
{
    private readonly Button _startGameButton;

    private readonly IGameObjectFactory _gameObjectFactory;

    public MainMenuScene(IGameObjectFactory gameObjectFactory)
    {
        _gameObjectFactory = gameObjectFactory;
        _startGameButton = _gameObjectFactory.Create<Button>();
        AddChild(_startGameButton);
        Init();
    }

    private void Init()
    {
        _startGameButton.Size = new SizeF(new Vector2(100f, 20f));
        _startGameButton.Label = "start game";
        _startGameButton.Transform.Translate(new Vector2(100f, 100f));

    }

    private void StartGame(object sender, EventArgs e)
    {
        Console.WriteLine("start game event handler");
    }

}