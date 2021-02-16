/// <summary>
/// This class serves to keep track of GameState and Score
/// potential to expand it to keep track of high scores or to load different levels
/// for now there is only one level so things are not currently made to be expanded
/// This class contains methods for:
///     - 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState 
    {
        PREGAME,
        RUNNING,
        POSTGAME
    }

    GameState _currentGameState = GameState.PREGAME;

    public Events.EventGameStateChange OnGameStateChange;

    public int score = 0;

    public GameState CurrentGameState
    {
        get {return _currentGameState;}
        private set {_currentGameState = value;}
    }

    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        CurrentGameState = state;

        OnGameStateChange.Invoke(CurrentGameState, previousGameState);

        if(CurrentGameState == GameState.RUNNING && previousGameState == GameState.PREGAME)
        {
            Debug.Log("Starting Game Manager Coroutine");
            StartCoroutine("IncrementScore");
        }
    }

    IEnumerator IncrementScore()
    {
        while(CurrentGameState == GameState.RUNNING)
        {
            yield return new WaitForSeconds(1.5f);
            score++;
        }
    }
}
