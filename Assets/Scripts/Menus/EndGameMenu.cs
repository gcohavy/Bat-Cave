/// <summary>
/// This class serves to control the End Game Menu
/// </summary>

using UnityEngine;

public class EndGameMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Wait for key inputs so the player doesn't need to use their mouse
        if(Input.GetKeyDown(KeyCode.E))
        {
            ExitToMainMenu();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    //Method to restart the game without exiting to menu
    public void RestartGame()
    {
        LeaveMenu();
        UIManager.Instance.SetPregameMenuActive();
    }

    //Method to exit to the main menu
    public void ExitToMainMenu()
    {
        LeaveMenu();
        UIManager.Instance.ReturnToMainMenu();
    }

    //Consolidated code
    void LeaveMenu()
    {
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
        gameObject.SetActive(false);
    }
}
