using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float delay = 3;
    float xSpawnRange = 8.5f;

    [SerializeField] private AudioSource _sonarAudioSource;
    [SerializeField] private AudioClip _sonarSound;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    void SetSpike()
    {
        GameObject Spike = ObjectPooler.SharedInstance.GetPooledObject();
        bool topOrBottom = ReturnTopOrBottom();
        Spike.transform.position = ReturnRandomSpawnPosition(topOrBottom);
        Spike.transform.rotation = ReturnSpawnRotation(topOrBottom);
        Spike.gameObject.SetActive(true);
    }

    IEnumerator Spawn()
    {
        while(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            Debug.Log("Spawning Spike in: " + delay + " seconds");
            yield return new WaitForSeconds(delay);
            SetSpike();
            SetSpike();
            if(!_sonarAudioSource.isPlaying)
                PlaySonar();
            if(delay > 0.5f) delay -= 0.05f;
        }
        
    }

    Vector3 ReturnRandomSpawnPosition(bool top)
    {
        float yPos = top ? -2.8f : 2.8f;
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), yPos, Random.Range(20,25));
    }

    Quaternion ReturnSpawnRotation(bool top)
    {
        return Quaternion.Euler(top ? -90 : 90, 0 , 0);
    }

    bool ReturnTopOrBottom()
    {
        return Random.Range(0, 100) > 50;
    }

    void PlaySonar()
    {
        _sonarAudioSource.Stop();
        _sonarAudioSource.clip = _sonarSound;
        _sonarAudioSource.Play();
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            StartCoroutine("Spawn");
        }
    }
}
