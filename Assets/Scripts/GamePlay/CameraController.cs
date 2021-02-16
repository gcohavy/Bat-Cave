using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody player;
    private float cameraSpeed = 5;
    private float xBound = 7;
    private float yBound = 3;

    // Update is called once per frame
    void LateUpdate()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            if(player.transform.position.x < transform.position.x && transform.position.x > -xBound)
            {
                transform.Translate(Vector3.left * Time.deltaTime * cameraSpeed);
            }
            else if(player.transform.position.x > transform.position.x && transform.position.x < xBound)
            {
                transform.Translate(Vector3.right * Time.deltaTime * cameraSpeed);
            }
            else if(player.transform.position.y > transform.position.y && transform.position.y < yBound)
            {
                transform.Translate(Vector3.up * Time.deltaTime * cameraSpeed);
            }
            else if(player.transform.position.y < transform.position.y && transform.position.y > -yBound)
            {
                transform.Translate(Vector3.down * Time.deltaTime * cameraSpeed);
            }
        }
            
    }
}
