using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (EnemyWaveSpawner))]
public class LevelDifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] public List<EnemyData> enemyDataList = new List<EnemyData>();
    [SerializeField] private int amountOfEnemies;

    private EnemyWaveSpawner spawner;
    private float difficultyLevel = 10;
    private int LastSpawnedIndex;
    private Vector2 previousPos;

    
    void Start()
    {
        spawner = GetComponent<EnemyWaveSpawner>();
        GenerateEnemies();
    }
    private void FixedUpdate()
    {
        if(GlobalReferenceManager.MainCamera.transform.position.y > previousPos.y)
        {
            GenerateEnemies();
        }
    }
    private void GenerateEnemies()
    {
        //Creating random amount of datasets for formations
        amountOfEnemies = Random.Range(2, 7);
        for (int i = 0; i < amountOfEnemies; i++) {
            //This is part of the inspector view list. can be removed later!
            EnemyData newEnemyData;
            enemyDataList.Add(newEnemyData = new EnemyData());

            //Randomize enemies and instantiate correct prefab per enemy
            newEnemyData.EnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            //Randomize this enemies position within the screen bounds
            newEnemyData.EnemyPosition = randomisePosition();

            //Check enemy position if its overlapping with another enemy
            OverlapCheck(enemyDataList[i], amountOfEnemies);

            //Activate spawner with generated data
            spawner.SpawnEnemy(newEnemyData);
        }
        previousPos = enemyDataList[enemyDataList.Count - 1].EnemyPosition;
    }
    private void OverlapCheck(EnemyData enemyData, int amountOfEnemies)
    {
        for (int i = enemyDataList.Count; i < enemyDataList.Count; i++) {
            if (Mathf.Abs(enemyData.EnemyPosition.x - enemyDataList[i].EnemyPosition.x) < 1 && Mathf.Abs(enemyData.EnemyPosition.y - enemyDataList[i].EnemyPosition.y) < 1)
            {
                Debug.Log("Checked position" + i + " enemyDataList Count: " + enemyDataList.Count);
                Debug.Log("enemyDataList.Count - amountOfEnemies = " + (enemyDataList.Count - amountOfEnemies));
                enemyData.EnemyPosition = randomisePosition();
                //OverlapCheck(enemyData, amountOfEnemies);
            }
        }
    }
    public Vector2 randomisePosition()
    {
        //Set spawn position above visible playing area with random offset
        float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize / 1.3f);
        float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - 1;
        return new Vector2(Random.Range(-withinScreenRange, withinScreenRange), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);
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
