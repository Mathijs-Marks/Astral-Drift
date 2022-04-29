using System.Collections;
using UnityEngine;

[System.Serializable]
public class SpawnableEnemyFormation
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 enemyPosition;
    [SerializeField] private Enums.enemyFormationTypes formationType;
    [SerializeField] private int amount;


    public int getAmount()
    {
        return amount;
    }
    public Vector3 getPos()
    {
        return enemyPosition;
    }
    public GameObject getPrefab()
    {
        return enemyPrefab;
    }
    public Enums.enemyFormationTypes getFormation()
    {
        return formationType;
    }
}