using UnityEngine;

public class GameManager
{

    public GameState GameState { get; private set; }
    public delegate void OnGameStateChangedHandler();
    public event OnGameStateChangedHandler OnGameStateChanged;
    private static GameManager _instance = null;
    public static GameManager Instance 
    {
        get 
        {
            if(_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    public bool IsHost { get; set; }

    public void OnApplicationQuit()
    {
        _instance = null;
    }

    public void SetGameState(GameState state)
    {
        GameState = state;
        OnGameStateChanged();
    }
}

public enum GameState
{
    InGame
}