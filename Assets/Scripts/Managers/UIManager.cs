﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //get instances of Game Menus
    [SerializeField] private GameObject _gameOverMenu;

    void Start()
    {
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.POSTGAME && previousState == GameManager.GameState.RUNNING)
        {
            _gameOverMenu.gameObject.SetActive(true);
        }
    }
}