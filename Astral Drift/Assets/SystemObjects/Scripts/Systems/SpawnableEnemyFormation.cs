using System.Collections;
using UnityEngine;

[System.Serializable]
public class SpawnableEnemyFormation
{
    //These are all the variables required to spawn one enemy formation.
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector2 enemyPosition;
    [SerializeField] private Enumerators.EnemyFormationTypes formationType;
    [SerializeField] private int amount;

    public GameObject EnemyPrefab { get { return enemyPrefab; } set { enemyPrefab = value; } }
    public Vector2 EnemyPosition { get { return enemyPosition; } set { enemyPosition = value; } }
    public Enumerators.EnemyFormationTypes FormationType { get { return formationType; } set { formationType = value; } }
    public int Amount { get { return amount; } set { amount = value; } }
}