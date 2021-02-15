using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 10;
    private float zBound = -50;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        
        if(transform.position.z < zBound)
        {
            gameObject.SetActive(false);
        }
    }
}
