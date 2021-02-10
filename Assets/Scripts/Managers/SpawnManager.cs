using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float delay = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
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
            yield return new WaitForSeconds(delay);
            SetSpike();
            SetSpike();
            delay -= 0.05f;
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
}
