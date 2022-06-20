using System.Collections;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    //These are all the variables required to spawn one enemy formation.
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector2 enemyPosition;

    public GameObject EnemyPrefab { get { return enemyPrefab; } set { enemyPrefab = value; } }
    public Vector2 EnemyPosition { get { return enemyPosition; } set { enemyPosition = value; } }
}