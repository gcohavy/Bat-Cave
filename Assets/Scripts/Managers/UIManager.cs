using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //get instances of Game Menus
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PregameMenu _pregameMenu;
    [SerializeField] private TextMeshProUGUI _scoreText;

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

        else if (currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME)
        {
            _pregameMenu.gameObject.SetActive(false);
            _scoreText.gameObject.SetActive(true);
        }
    }

    //Main Menu
    public void StartButton()
    {
        _mainMenu.MenuMenuExit();
    }

    public void ReturnToMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _mainMenu.MainMenuEnter();
    }

    //Pregame Menu
    public void SetPregameMenuActive()
    {
        _pregameMenu.gameObject.SetActive(true);
    }
}
