using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    // this dictionary keeps all the pools separate and helps finding the right pool type to spawn from
    public Dictionary<GlobalReferenceManager.PoolType, Queue<GameObject>> poolDictionary;
    public int poolSize = 100;

    // create an object pool and call the function which populates it
    public void AddPool(GlobalReferenceManager.PoolType poolType, GameObject poolObject)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            fillPool(poolType, poolObject);
        }
    }

    // populate a pool with the corresponding objects and set them to inactive
    private void fillPool(GlobalReferenceManager.PoolType poolType, GameObject poolObject)
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
    // returns one object from the corresponding pool type
    public GameObject SpawnFromPool(GlobalReferenceManager.PoolType poolType, Vector3 spawnPoint, Quaternion rotation)
    {

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = spawnPoint;

        objectToSpawn.transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);

        poolDictionary[poolType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
