/// <summary>
/// Class to manage and play the background music
/// </summary>

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Get the AudioSource, the actual mp3 file, and the different starting times
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _music;
    private float[] _startTimes = {1, 120, 488.5f, 598, 765, 1034, 1322, 1470, 2020, 2232};

    // Start is called before the first frame update
    void Start()
    {
        //Play a Random song at start
        PlayRandomSong();
        //Subscribe to the GameStateChange event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    //Method to play a random song from the mp3 file
    void PlayRandomSong()
    {
        _audioSource.Stop();
        _audioSource.clip = _music;
        _audioSource.time = _startTimes[Random.Range(0, _startTimes.Length)];
        _audioSource.Play();
    }

    //Handle the gamestate change event
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        //Start a new song at specific GameState changes
        if(currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME ||
            currentState == GameManager.GameState.POSTGAME && previousState == GameManager.GameState.RUNNING)
        {
            PlayRandomSong();
        }
    }
}
