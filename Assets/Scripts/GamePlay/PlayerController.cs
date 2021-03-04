/// <summary>
/// Controls the player and resets it when restarting
/// Also has an audio listener to play the splat sound on collision
/// And also controls when the player should be affected by Gravity
/// </summary>

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Keep track of necessary force
    private float upForce = 3000;
    private float sideStep = 2000;
    // Get player rigidbody component and keep track of starting position
    Rigidbody playerRb;
    Vector3 startingPosition;
    //Keep track of audiosource component
    [SerializeField] private AudioSource _playerAudio;

    //Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody component, since we are moving through the use of force
        playerRb = gameObject.GetComponent<Rigidbody>();
        //Subscribe to the GameStateChange event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);

        //Keep track of starting position
        startingPosition = transform.position;
        //Begin by not using gravity so the player doesn't fall 
        playerRb.useGravity = false;
    }

    //Update is called at every frame
    void Update()
    {
        //Only move while GameState is RUNNING
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            MovePlayer();
        }
    }

    //End game and play Splat sound when player collides with anything
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

    //Method to move the player based on input
    void MovePlayer()
    {
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

    //Method to reset player's position and rotation
    void ResetPosition(bool useGrav)
    {
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;
        playerRb.angularVelocity = Vector3.zero;
        playerRb.useGravity = useGrav;
    }

    //Reset player's position based on GameState change
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
