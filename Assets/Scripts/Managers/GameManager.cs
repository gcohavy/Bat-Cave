/// <summary>
/// This class serves to keep track of GameState and Score
/// potential to expand it to keep track of high scores or to load different levels
/// for now there is only one level so things are not currently made to be expanded
/// This class contains methods for:
///     - Updating GameState
///     - Increment Score
/// </summary>

using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Create Game States
    public enum GameState 
    {
        PREGAME,
        RUNNING,
        POSTGAME
    }
    //Initialize current GameState to PREGAME
    GameState _currentGameState = GameState.PREGAME;
    //Initialize a score to 0
    public int score = 0;

    //Create a public access to the current state
    public GameState CurrentGameState
    {
        get {return _currentGameState;}
        private set {_currentGameState = value;}
    }

    //Create a GameStateChange event
    public Events.EventGameStateChange OnGameStateChange;

    //Method to Update the state and fire the event
    public void UpdateState(GameState state)
    {
        //Keep track of current and previous states
        GameState previousGameState = _currentGameState;
        CurrentGameState = state;

        //Invoke the event
        OnGameStateChange.Invoke(CurrentGameState, previousGameState);

        //Handle state change
        if(CurrentGameState == GameState.RUNNING && previousGameState == GameState.PREGAME)
        {
            //Debug.Log("Starting Game Manager Coroutine");
            StartCoroutine("IncrementScore");
        }
        else if (CurrentGameState == GameState.PREGAME && previousGameState == GameState.POSTGAME)
        {
            score = 0;
        }
    }

    //Create coroutine to increment the score
    IEnumerator IncrementScore()
    {
        while(CurrentGameState == GameState.RUNNING)
        {
            yield return new WaitForSeconds(1.5f);
            score++;
        }
    }
}
