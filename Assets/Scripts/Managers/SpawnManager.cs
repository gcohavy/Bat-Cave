/// <summary>
/// This class serves to manage the Spawning of random spikes
/// It needs to communicate the the Object Pool in order to reactivate when of the 
///  instantiated spikes
/// This class will also play the sonar sound
/// </summary>

using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Set initial delay and width
    float delay = 3;
    float xSpawnRange = 8.5f;

    //Get the audio source to play the sound on spawn
    [SerializeField] private AudioSource _sonarAudioSource;
    [SerializeField] private AudioClip _sonarSound;

    //Keep track of possible materials for spawned spikes
    public Material[] materials;
    
    // Start is called before the first frame update
    void Start()
    {
        //Subscribe to the State change event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    //Method to set a spike to "spawn" it
    void SetSpike()
    {
        //Get a spike from the object pool
        GameObject Spike = ObjectPooler.SharedInstance.GetPooledObject();

        //Randomly set the spike's position
        bool topOrBottom = ReturnTopOrBottom();
        Spike.transform.position = ReturnRandomSpawnPosition(topOrBottom);
        Spike.transform.rotation = ReturnSpawnRotation(topOrBottom);

        //Set a random material for the spike
        Spike.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];

        //Set spike to active
        Spike.gameObject.SetActive(true);
    }

    //Coroutine to spawn spikes
    IEnumerator Spawn()
    {
        //Only spawn spikes while game is running
        while(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            //Debug.Log("Spawning Spike in: " + delay + " seconds");
            yield return new WaitForSeconds(delay);
            SetSpike();
            SetSpike();
            if(!_sonarAudioSource.isPlaying)
                PlaySonar();
            //decrease the delay between spawns to a minimum delay
            if(delay > 0.5f) delay -= 0.05f;
        }
        
    }

    //Method to return a random Spawn position for the spike
    Vector3 ReturnRandomSpawnPosition(bool top)
    {
        float yPos = top ? -2.8f : 2.8f;
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), yPos, Random.Range(20,25));
    }

    //Method to rotate the spike according to whether it is upside down or not
    Quaternion ReturnSpawnRotation(bool top)
    {
        return Quaternion.Euler(top ? -90 : 90, 0 , 0);
    }

    //Method to randomly return top or bottom
    bool ReturnTopOrBottom()
    {
        return Random.Range(0, 100) > 50;
    }

    //Method to play the sonar audio
    void PlaySonar()
    {
        _sonarAudioSource.Stop();
        _sonarAudioSource.clip = _sonarSound;
        _sonarAudioSource.time = 3.2f;
        _sonarAudioSource.Play();
    }

    //Handle the GameStateChange event
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            StartCoroutine("Spawn");
        }
        else if (currentState == GameManager.GameState.PREGAME && previousState == GameManager.GameState.POSTGAME)
        {
            delay = 3;
            ObjectPooler.SharedInstance.ResetAllInactive();
        }
    }
}
