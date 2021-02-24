using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ExitToMainMenu();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        LeaveMenu();
        UIManager.Instance.SetPregameMenuActive();
    }

    public void ExitToMainMenu()
    {
        LeaveMenu();
        UIManager.Instance.ReturnToMainMenu();
    }

    void LeaveMenu()
    {
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
        gameObject.SetActive(false);
    }
}
