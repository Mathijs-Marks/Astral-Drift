using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
//This is a simple object pooler. It is mostly used for bullets. Simply add the item you want to instaniate and add it to the object that has to instantiate said item.
//</Summary>

public class SimplePool : MonoBehaviour
{
    [SerializeField] private int poolSize = 20;
    private GameObject[] poolArray;
    private BaseBullet[] bulletArray;

    [SerializeField] private GameObject spawnItem;

    private int currentItemIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        poolArray = new GameObject[poolSize];
        bulletArray = new BaseBullet[poolSize];
        for(int i = 0; i<poolSize; i++)
        {
            poolArray[i] = Instantiate(spawnItem);
            poolArray[i].SetActive(false);
            bulletArray[i] = poolArray[i].GetComponent<BaseBullet>();
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
    public void AddBulletVariables(int damage, float speed)
    {
        for (int i = 0; i < poolSize; i++)
        {
            bulletArray[i].InitializeBullet(damage, speed);
        }
    }
}
