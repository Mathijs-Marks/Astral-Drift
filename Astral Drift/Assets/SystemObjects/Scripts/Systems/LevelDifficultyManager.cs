using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (EnemyWaveSpawner))]
public class LevelDifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<int> difficultyList;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private float difficultyLevel = 10;

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
        difficultyLevel += 0.1f * Time.deltaTime;
    }
    private void GenerateEnemies()
    {
        //Creating random amount of datasets for formations
        amountOfEnemies = (int)Random.Range(difficultyLevel / 4, difficultyLevel * 0.8f);
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

    /*
     * Step 1:
     * Generate formations with 1 type of enemy. This formation has to have points.
     * These points are based on the enemy type and their amount. E.G. a standard enemy has 2 points, for a Vformation with 5 enemies, this is worth 10 points.
     * Question: Do these formations have to be made at the start of the level? Are they premade? Or do we generate these on the fly?
     * Step 2: 
     * Assemble different formations
     * Problem: need to get access to movement scripts
     * list of sections with formations inside. Every formation has points. Pick random
     * for loop per enemy type formation amount (5)  new SpawnableEnemyFormation(difficulty, ) Voeg deze allemaal toe aan de lijst
    */
}
