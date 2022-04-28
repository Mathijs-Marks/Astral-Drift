using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes
{
    GameObject enemyPrefab;
    Vector3 enemyPosition;
}


public class EnemyWaveSystem : MonoBehaviour
{
    EnemyTypes[] enemyList;
    private void Start()
    {
        enemyList = new EnemyTypes[enemyList.Length];

        //Spawn all enemies that we want

    }
}
