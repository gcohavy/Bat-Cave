/// <summary>
/// This script serves to move the camera behind the player, and return it 
///  to the original position when returning to a menu
/// </summary>

using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    //Keep track of player, boundaries and original position
    public Rigidbody player;
    private float xBound = 7;
    private float yBound = 2;
    private Vector3 originalPosition;

    //Stop camera shake by delaying movement
    float accuracy = 0.2f;
    private float cameraSpeed = 4;

    //Start runs before the first frame update
    void Start()
    {
        //Subscrive to the GamestateChange event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        //keep track of original position for the return to menu
        originalPosition = transform.position;
    }

    // Update is called once per frame, using LateUpdate to slow camera shake
    void LateUpdate()
    {
        //Keep track of the distance from the player
        float distanceX = player.transform.position.x - transform.position.x;
        float distanceY = player.transform.position.y - transform.position.y;

        //Only move the camera while Game is in RUNNING state
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

    //Handle the GameStateChange event
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        //Move the camera back to original position when returning to menu
        if(currentState == GameManager.GameState.PREGAME && previousState == GameManager.GameState.POSTGAME)
        {
            transform.position = originalPosition;
        }
    }
}
