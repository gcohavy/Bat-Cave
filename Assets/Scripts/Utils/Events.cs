using UnityEngine.Events;

public class Events 
{
    //Event for GameState change
    [System.Serializable] public class EventGameStateChange : UnityEvent<GameManager.GameState,GameManager.GameState>{}
}
