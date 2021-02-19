using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _menuAmbience;
    [SerializeField] private AudioClip _gameSound;
    // Start is called before the first frame update
    void Start()
    {
        PlayMenuMusic();
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    void PlayMenuMusic()
    {
        _audioSource.Stop();
        _audioSource.clip = _menuAmbience;
        _audioSource.Play();
    }

    void PlayGameMusic()
    {
        _audioSource.Stop();
        _audioSource.clip = _gameSound;
        _audioSource.Play();
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME)
        {
            PlayGameMusic();
        }
        else if(currentState == GameManager.GameState.POSTGAME && previousState == GameManager.GameState.RUNNING)
        {
            PlayMenuMusic();
        }
    }
}
