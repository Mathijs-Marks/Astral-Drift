using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    //THIS SYSTEM IS AN EXAMPLE OF WHAT A COMPLEX POOLING SYSTEM COULD LOOK LIKE. THIS SYTEM IS NOT IN USE.

    //public Dictionary<GlobalReferenceManager.PoolType, Queue<GameObject>> poolDictionary;
    //public int poolSize = 100;

 /*   public void AddPool(GlobalReferenceManager.PoolType poolType, GameObject poolObject)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            fillPool(poolType, poolObject);
        }
    }*/

/*    private void fillPool(GlobalReferenceManager.PoolType poolType, GameObject poolObject)
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
    }*/
/*    public GameObject SpawnFromPool(GlobalReferenceManager.PoolType poolType, Vector3 spawnPoint, Quaternion rotation)
    {

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = spawnPoint;

        objectToSpawn.transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);

        poolDictionary[poolType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }*/
}
