/// <summary>
/// This class serves to manage all the UI elements
/// This is good practice for expanding the game in the future
/// </summary>

using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //get instances of Game Menus
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PregameMenu _pregameMenu;
    [SerializeField] private TextMeshProUGUI _scoreText;

    //Start is called before the first frame
    void Start()
    {
        //Subscribe to the StateChange event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    //Method to handle GameState change
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
        _mainMenu.MainMenuExit();
    }

    public void ReturnToMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _mainMenu.MainMenuEnter();
    }

    //Pregame Menu
    public void SetPregameMenuActive()
    {
        _pregameMenu.SetToActive();
        _pregameMenu.BeginInstructionAnimation();
    }
}
