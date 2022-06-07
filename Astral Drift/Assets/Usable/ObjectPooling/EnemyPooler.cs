using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : Pooler
{
   /* private void Awake()
    {
        // assign the global enemy object pools
        Global.enemies = this;
        poolDictionary = new Dictionary<Global.PoolType, Queue<GameObject>>();
    }

    // spawn an enemy with a given position from the corresponding object pool
    public GameObject Spawn(Global.PoolType poolType, Vector3 pos)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            Debug.LogWarning("Unkown tag:" + poolType);
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.SetActive(true);

        objectToSpawn.transform.position = pos;

        poolDictionary[poolType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }*/
}
