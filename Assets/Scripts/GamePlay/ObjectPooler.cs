/// <summary>
/// This class serves to create a pool of objects to pull from to improve performance
///  rather than constantly instantiating and destroying objects.
/// </summary>

using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Create a shared instance to pull from
    public static ObjectPooler SharedInstance;
    //Keep track of items in pool
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    //Awake is called when the object is activated
    void Awake()
    {
        //Set the Shared instance variable to this instance
        SharedInstance = this;
    }

    //Start is called before the first frame
    void Start()
    {
        //Initialize list of pooled objects
        pooledObjects = new List<GameObject>();

        //Instantiate all the objects and add them to the list
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //public method to get the next pooled object in the list
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    //public method to deactivate all the objects once again
    public void ResetAllInactive()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }
}
