using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyTypes : MonoBehaviour
{
    //[SerializeField] private GameObject enemyPrefab;
    public Vector3 enemyPosition;
    public Quaternion enemyRotation;

    public void SpawnEnemy()
    {
        //Instantiate(enemyPrefab, enemyPosition, enemyRotation);
    }
}
