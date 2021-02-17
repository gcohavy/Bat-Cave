using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public Rigidbody player;
    private float cameraSpeed = 4;
    private float xBound = 7;
    private float yBound = 2;
    float accuracy = 0.2f;

    // Update is called once per frame
    void LateUpdate()
    {
        float distanceX = player.transform.position.x - transform.position.x;
        float distanceY = player.transform.position.y - transform.position.y;

        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            //Move horizontally
            if(Math.Abs(distanceX) > accuracy)
            {
                if(player.transform.position.x < transform.position.x && transform.position.x > -xBound)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * cameraSpeed);
                }
                else if(player.transform.position.x > transform.position.x && transform.position.x < xBound)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * cameraSpeed);
                }
            }
            

            //Move vertically
            if(Math.Abs(distanceY) > accuracy)
            {
                if(player.transform.position.y > transform.position.y && transform.position.y < yBound)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * cameraSpeed, Space.World);
                }
                else if(player.transform.position.y < transform.position.y && transform.position.y > -yBound)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * cameraSpeed, Space.World);
                }
            }
        }
            
    }
}
