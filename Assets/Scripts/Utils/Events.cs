/// <summary>
/// Class to place all events into.<!-- Currently only 1, but good practice for expanding the game-->
/// </summary>

using UnityEngine.Events;

public class Events 
{
    //Event for GameState change
    [System.Serializable] public class EventGameStateChange : UnityEvent<GameManager.GameState,GameManager.GameState>{}
}
