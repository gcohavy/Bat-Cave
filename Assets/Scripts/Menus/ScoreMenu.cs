/// <summary>
/// This class serves to show the user their current score
/// </summary>

using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    //Keep track of score text
    TextMeshProUGUI thisText;

    //Using awake instead of Start so that it runs when the game is actually started
    void Awake()
    {
        //Get the text component
        thisText = gameObject.GetComponent<TextMeshProUGUI>();
        //subscrive to the STateChange event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        //Begin incrementing the score
        StartCoroutine("IncrementScore");
    }

    //Coroutine to increment the score, which is kept track of by the GameManager
    IEnumerator IncrementScore()
    {
        while(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            yield return new WaitForSeconds(1.5f);
            thisText.text = "" + GameManager.Instance.score;
        }
    }

    //Handle the GameState change to start the coroutine at the correct time
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME)
        {
            StartCoroutine("IncrementScore");
        }
    }
}
