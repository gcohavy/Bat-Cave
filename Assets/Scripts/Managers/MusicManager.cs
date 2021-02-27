using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _music;
    private float[] _startTimes = {1, 120, 488.5f, 598, 765, 1034, 1322, 1470, 2020, 2232};

    // Start is called before the first frame update
    void Start()
    {
        PlayRandomSong();
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    void PlayRandomSong()
    {
        _audioSource.Stop();
        _audioSource.clip = _music;
        _audioSource.time = _startTimes[Random.Range(0, _startTimes.Length)];
        _audioSource.Play();
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME)
        {
            PlayRandomSong();
        }
        else if(currentState == GameManager.GameState.POSTGAME && previousState == GameManager.GameState.RUNNING)
        {
            PlayRandomSong();
        }
    }
}
