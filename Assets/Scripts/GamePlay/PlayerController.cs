using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float upForce = 500;
    private float sideStep = 500;
    Rigidbody playerRb;
    Vector3 startingPosition;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);

        startingPosition = transform.position;
        playerRb.useGravity = false;
    }

    void Update()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            MovePlayer();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.UpdateState(GameManager.GameState.POSTGAME);
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.identity;
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * upForce);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0,0,40);
            playerRb.AddForce(Vector3.left * sideStep);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0,0,-40);
            playerRb.AddForce(Vector3.right * sideStep);
        }
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            transform.position = startingPosition;
            playerRb.useGravity = true;
        }
    }
}
