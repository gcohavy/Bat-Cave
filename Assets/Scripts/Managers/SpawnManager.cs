using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float delay = 3;
    
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
            if(delay > 0.3f) delay -= 0.05f;
        }
        
    }

    Vector3 ReturnRandomSpawnPosition(bool top)
    {
        float yPos = top ? -2.8f : 2.8f;
        return new Vector3(Random.Range(-8, 8), yPos, Random.Range(15,12));
    }

    Quaternion ReturnSpawnRotation(bool top)
    {
        return Quaternion.Euler(top ? -90 : 90, 0 , 0);
    }

    bool ReturnTopOrBottom()
    {
        return Random.Range(0, 100) > 50;
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            StartCoroutine("Spawn");
        }
    }
}
