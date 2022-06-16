using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (EnemyWaveSpawner))]
public class LevelDifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<int> difficultyList;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private float difficultyLevel = 10, minAmountPercent = 0.25f, maxAmountPercent = 0.8f, difficultyIncrease = 0.1f;

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
        amountOfEnemies = (int)Random.Range(difficultyLevel * minAmountPercent, difficultyLevel * maxAmountPercent);
        int processedDifficultyLevel = (int)difficultyLevel - amountOfEnemies;
        for (int i = 0; i < amountOfEnemies; i++) {
            EnemyData newEnemyData;

            //This is part of the inspector view list. can be removed later!
            enemyDataList.Add(newEnemyData = new EnemyData());

            //Pick random number for enemy prefab and subtract it from diff, if it cant anymore just spawn what is left from diff
            int random = Random.Range(0, enemyPrefabs.Length);
            if (processedDifficultyLevel > random) {
                processedDifficultyLevel -= random;
                newEnemyData.EnemyPrefab = enemyPrefabs[random];
            } else
            {
                newEnemyData.EnemyPrefab = enemyPrefabs[processedDifficultyLevel];
                processedDifficultyLevel = 0;
            }

            //Randomize this enemies position within the screen bounds
            newEnemyData.EnemyPosition = randomisePosition();

            //Activate spawner with generated data
            spawner.SpawnEnemy(newEnemyData);
        }
        lastTopIndex = enemyDataList.Count;
        previousPos = enemyDataList[enemyDataList.Count - 1].EnemyPosition;
    }
    public Vector2 randomisePosition()
    {
        //Set spawn position above visible playing area with random offset
        float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize);
        float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - screenEdgeOffset;
        Vector2 newPos = new Vector2(Random.Range(-withinScreenRange, withinScreenRange), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);
        return newPos;
    }
}
