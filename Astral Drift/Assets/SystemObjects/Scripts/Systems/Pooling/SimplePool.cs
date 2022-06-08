using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    private GameObject[] poolArray;

    [SerializeField] private GameObject spawnItem;

    private int currentItemIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        poolArray = new GameObject[poolSize];

        for(int i = 0; i<poolSize; i++)
        {
            Instantiate(spawnItem);
        }
    }
    public void SpawnFrompool(Vector2 pos, Quaternion rotation)
    {
        GameObject itemToSpawn = poolArray[currentItemIndex];
        itemToSpawn.transform.position = new Vector3(pos.x, pos.y, 0);
        itemToSpawn.transform.rotation = rotation;
        itemToSpawn.SetActive(true);

        if(currentItemIndex == poolSize - 1)
        {
            currentItemIndex = 0;
        }
        else
        {
            currentItemIndex++;
        }
    }
}
