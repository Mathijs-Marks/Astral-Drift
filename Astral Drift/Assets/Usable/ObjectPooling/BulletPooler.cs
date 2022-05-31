using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : Pooler
{
  /*  private void Awake()
    {
        // assign the global bullet object pools
        Global.bullets = this;
        poolDictionary = new Dictionary<Global.PoolType, Queue<GameObject>>();
    }

    // spawn a bullet with the given parameters from the corresponding object pool
    public GameObject Spawn(Global.PoolType poolType, Vector3 pos, float rotation, float speed, int dmg)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            Debug.LogWarning("Unkown tag:" + poolType);
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.GetComponent<BulletBehavior>().Spawn(pos, rotation, speed, dmg);

        poolDictionary[poolType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }*/
}
