using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float upForce = 3000;
    private float sideStep = 2000;
    Rigidbody playerRb;
    Vector3 startingPosition;

    [SerializeField] private AudioSource _playerAudio;

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
        if(!_playerAudio.isPlaying)
        {
            _playerAudio.Stop();
            _playerAudio.time = 1.8f;
            _playerAudio.Play();
        }
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

    void ResetPosition(bool useGrav)
    {
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;
        playerRb.angularVelocity = Vector3.zero;
        playerRb.useGravity = useGrav;
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            ResetPosition(true);
        }
        else if (currentState == GameManager.GameState.PREGAME && previousState == GameManager.GameState.POSTGAME)
        {
            ResetPosition(false);
        }
    }
}
