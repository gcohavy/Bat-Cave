using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    TextMeshProUGUI thisText;

    void Awake()
    {
        thisText = gameObject.GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        StartCoroutine("IncrementScore");
    }

    IEnumerator IncrementScore()
    {
        while(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            yield return new WaitForSeconds(1.5f);
            thisText.text = "" + GameManager.Instance.score;
        }
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING && previousState == GameManager.GameState.PREGAME)
        {
            StartCoroutine("IncrementScore");
        }
    }
}
