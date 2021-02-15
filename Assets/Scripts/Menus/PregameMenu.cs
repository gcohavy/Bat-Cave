using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregameMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
            gameObject.SetActive(false);
        }
    }
}
