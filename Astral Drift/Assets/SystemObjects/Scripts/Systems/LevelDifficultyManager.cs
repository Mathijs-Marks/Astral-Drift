using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (EnemyWaveSpawner))]
public class LevelDifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<int> difficultyList;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private float difficultyLevel = 10, minAmountPercent = 0.8f, maxAmountPercent = 1f, difficultyIncrease = 0.1f;

    private EnemyWaveSpawner spawner;
    private float screenEdgeOffset = 0.25f;
    private Vector2 previousPos;

    public List<EnemyData> enemyDataList = new List<EnemyData>();
    public int lastTopIndex = 0;

    void Start()
    {
        spawner = GetComponent<EnemyWaveSpawner>();
        foreach(GameObject enemyPrefab in enemyPrefabs)
        {
            difficultyList.Add(enemyPrefab.GetComponent<EnemyDifficulty>().enemyDifficulty);
        }
        GenerateEnemies();
    }
    private void FixedUpdate()
    {
        if(GlobalReferenceManager.MainCamera.transform.position.y > previousPos.y)
        {
            GenerateEnemies();
        }
        difficultyLevel += difficultyIncrease * Time.deltaTime;
    }
    private void GenerateEnemies()
    {
        //Creating random amount of datasets for formations
        int spendableDifficultyLevel = (int)Random.Range(difficultyLevel * minAmountPercent, difficultyLevel * maxAmountPercent);
        while (spendableDifficultyLevel > 0) {
            EnemyData newEnemyData;
            //This is part of the inspector view list.
            enemyDataList.Add(newEnemyData = new EnemyData());

            //Pick random number for enemy prefab and subtract it from diff, if it cant anymore just spawn what is left from diff
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            if (spendableDifficultyLevel >= difficultyList[randomEnemy]) {
                spendableDifficultyLevel -= difficultyList[randomEnemy];
                newEnemyData.EnemyPrefab = enemyPrefabs[randomEnemy];
            } else
            {
                int newMaxRandomEnemy = Random.Range(0, spendableDifficultyLevel + 1);
                if (spendableDifficultyLevel >= difficultyList[newMaxRandomEnemy])
                {
                    spendableDifficultyLevel -= difficultyList[newMaxRandomEnemy];
                    newEnemyData.EnemyPrefab = enemyPrefabs[newMaxRandomEnemy];
                }
                else
                {
                    spendableDifficultyLevel -= difficultyList[0];
                    newEnemyData.EnemyPrefab = enemyPrefabs[0];
                }
            }

            //Randomize this enemies position within the screen bounds
            newEnemyData.EnemyPosition = randomisePosition();

            //Activate spawner with generated data
            spawner.SpawnEnemy(newEnemyData);
        }
        spawner.OverlapCheck();
        lastTopIndex = enemyDataList.Count;
        previousPos = enemyDataList[enemyDataList.Count - 1].EnemyPosition;
    }
    public Vector2 randomisePosition()
    {
        //Set spawn position above visible playing area with random offset
        float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize * 2);
        float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - screenEdgeOffset;
        Vector2 newPos = new Vector2(Random.Range(-withinScreenRange, withinScreenRange), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);
        return newPos;
    }
}
