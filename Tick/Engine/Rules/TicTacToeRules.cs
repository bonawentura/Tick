namespace Tick.Engine.Rules;


public class Player
{
    public char Symbol { get; set; }
}




public class LogicEngineEvent : EventArgs {}

public class IncorrectMoveLogicEvent : LogicEngineEvent
{
    public Player Player;
    public int X;
    public int Y;

    public IncorrectMoveLogicEvent(Player player, int x, int y)
    {
        Player = player;
        X = x;
        Y = y;
    }
}

public class RoundEndLogicEvent: LogicEngineEvent
{
    public Player Player;
    public RoundEndType EndType;
    public int Coordinate;

    public RoundEndLogicEvent(Player player, RoundEndType endType, int coordinate)
    {
        Player = player;
        EndType = endType;
        Coordinate = coordinate;
    }
}

public enum RoundEndType
{
    Column,
    Row,
    Diagonal,
    Antidiagonal,
    Tie,
}

public class TicTacToeRules
{
    private Player[][] GameGrid { get; set; }
    public Player[] Players { get; set; }
    public Player ActivePlayer { get; set; }
    public GamePhase GamePhase { get; set; } = GamePhase.Start;
    public EndGameState EndGameState { get; set; } = null;
    public int MoveCount { get; set; } = 0;


    private readonly IGameSettings _gameSettings;
    private readonly IMessageBus _messageBus;

    public TicTacToeRules(IGameSettings gameSettings, IMessageBus messageBus)
    {
        _gameSettings = gameSettings;
        _messageBus = messageBus;
        Initialize();
        _messageBus.NextMessage += OnRuleEvent;
    }

    void OnRuleEvent(object _, EventArgs arg)
    {
        Console.WriteLine("event raised");
    }


    bool IsMoveLegal(int x, int y)
    {
        var gridSize = GameGrid.Length - 1;
        return x <= gridSize && y <= gridSize && GameGrid[x][y] is null;
    }

    bool IsGameFinished( int x, int y)
    {
        var col = GameGrid[x];
        var row = new Player[GameGrid.Length];
        var diag = new Player[GameGrid.Length];
        var antidiag = new Player[GameGrid.Length];

        for (int i = 0; i < GameGrid.Length; i++)
        {
            row[i] = GameGrid[i][y];
            diag[i] = GameGrid[i][i];
            antidiag[i] = GameGrid[i][GameGrid.Length - 1 - i];
        }

        if (HasSameElements(col))
        {
            _messageBus.Dispatch(new RoundEndLogicEvent(ActivePlayer, RoundEndType.Column, x));
            return true;
        }

        if (HasSameElements(row))
        {
            _messageBus.Dispatch(new RoundEndLogicEvent(ActivePlayer, RoundEndType.Row, y));
            return true;
        }

        if (HasSameElements(diag))
        {
            _messageBus.Dispatch(new RoundEndLogicEvent(ActivePlayer, RoundEndType.Diagonal, 0));
            return true;
        }

        if (HasSameElements(antidiag))
        {
            _messageBus.Dispatch(new RoundEndLogicEvent(ActivePlayer, RoundEndType.Antidiagonal, 0));
            return true;
        }

        if (MoveCount == GameGrid.Length * GameGrid.Length)
        {
            _messageBus.Dispatch(new RoundEndLogicEvent(null, RoundEndType.Tie, 0));
            return true;
        }

        return false;

    }

    private bool HasSameElements(Player[] row)
    {
        return (Array.TrueForAll(row, elem => elem.Symbol == row[0].Symbol));
    }

    void PlayerMove(Player player, int x, int y)
    {
        if (!IsMoveLegal(x, y))
        {
            _messageBus.Dispatch(new IncorrectMoveLogicEvent(ActivePlayer, x, y));
            return;
        }

        GameGrid[x][y] = player;
        MoveCount++;

        if (!IsGameFinished(x, y))
        {
            SwitchPlayer();
        }
        else
        {
            GamePhase = GamePhase.Ended;
        }




    }

    private void SwitchPlayer()
    {
        ActivePlayer = (Players[0] == ActivePlayer) ? Players[1] : Players[0];
    }

    public void Initialize() 
    {
        var (players, gridSize) = _gameSettings.GetInitialGameParams();
        GameGrid = new Player[gridSize][];
        for (var i = 0; i < GameGrid.Length; i++)
        {
            GameGrid[i] = new Player[gridSize];
        }

        Players = players;
        ActivePlayer = Players[0];
        GamePhase = GamePhase.PlayerTurn;
    }
}


public interface IMessageBus
{
    public event EventHandler<EventArgs> NextMessage;

    public void Dispatch(EventArgs args, object sender = null);
}

public record InitialGameParams(Player[] Players, int GridSize);

public interface IGameSettings
{
    public InitialGameParams GetInitialGameParams();
    
}

public record EndGameState
{
    public Player Winner { get; set; }
}

public enum GamePhase
{
    Start,
    PlayerTurn,
    Ended,
}