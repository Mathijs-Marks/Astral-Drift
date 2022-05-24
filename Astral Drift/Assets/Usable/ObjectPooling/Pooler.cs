using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
   /* // this dictionary keeps all the pools separate and helps finding the right pool type to spawn from
    public Dictionary<Global.PoolType, Queue<GameObject>> poolDictionary;
    public List<Global.PoolType> instantiatedObjects;
    public int poolSize = 100;

    // create an object pool and call the function which populates it
    public void AddPool(Global.PoolType poolType, GameObject poolObject)
    {
        if (!checkIfPoolExist(poolType))
        {
            instantiatedObjects.Add(poolType);
            fillPool(poolType, poolObject);
        }
    }

    // populate a pool with the corresponding objects and set them to inactive
    private void fillPool(Global.PoolType poolType, GameObject poolObject)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(poolObject);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(poolType, objectPool);
    }

    // makes sure we have one pool per object type
    private bool checkIfPoolExist(Global.PoolType poolType)
    {
        for (int i = 0; i < instantiatedObjects.Count; i++)
        {
            if (instantiatedObjects[i] == poolType)
                return true;
        }
        return false;
    }

    // returns one object from the corresponding pool type
    public GameObject SpawnFromPool(Global.PoolType poolType, Vector3 spawnPoint, Quaternion rotation)
    {
        // prevents errors caused by spawning from a non-existant pool
        if (!poolDictionary.ContainsKey(poolType))
        {
            Debug.LogWarning("Unkown tag:" + poolType);
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = spawnPoint;

        objectToSpawn.transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);

        poolDictionary[poolType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }*/
}
