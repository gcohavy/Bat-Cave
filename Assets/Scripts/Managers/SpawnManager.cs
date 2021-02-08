using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float delay = 1;
    [SerializeField] private GameObject _spikePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void SpawnSpike()
    {
        _spikePrefab.transform.position = ReturnRandomSpawnPosition();
        _spikePrefab.gameObject.SetActive(true);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);
        SpawnSpike();
        delay -= 0.1f;
    }

    Vector3 ReturnRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-8, 8), 0, Random.Range(15,12));
    }
}
