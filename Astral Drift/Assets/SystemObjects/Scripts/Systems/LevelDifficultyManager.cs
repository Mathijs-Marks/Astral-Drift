using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (EnemyWaveSpawner))]
public class LevelDifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<SpawnableEnemyFormation> enemyWaves = new List<SpawnableEnemyFormation>();

    private EnemyWaveSpawner spawner;
    private float difficultyLevel = 10;
    private float screenAspect;
    private Vector2 previousPos;

    void Start()
    {
        spawner = GetComponent<EnemyWaveSpawner>();
        screenAspect = (float)Screen.width / (float)Screen.height;
        GenerateEnemyWave();
    }
    private void FixedUpdate()
    {
        if(GlobalReferenceManager.MainCamera.transform.position.y > previousPos.y)
        {
            GenerateEnemyWave();
        }
    }
    private void GenerateEnemyWave()
    {
        for (int i= 0; i < Random.Range(6,8); i++) {
            SpawnableEnemyFormation enemyFormation = new SpawnableEnemyFormation();
            enemyWaves.Add(enemyFormation = new SpawnableEnemyFormation());

            //Randomize the amount of enemies that will spawn
            enemyFormation.Amount = Random.Range(1, 4);

            //Randomize enemies and instantiate correct prefab per enemy
            ChooseEnemyType(enemyFormation);

            //Set formation type of enemy formation
            //enemyFormation.FormationType = Enumerators.GetRandomEnumValue<Enumerators.EnemyFormationTypes>();
            enemyFormation.FormationType = Enumerators.EnemyFormationTypes.HorizontalLine;

            //Spawn formation above visible playing area with random offset
            float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize/1.5f);
            enemyFormation.EnemyPosition = new Vector2(Random.Range(-screenAspect * GlobalReferenceManager.MainCamera.orthographicSize, screenAspect * GlobalReferenceManager.MainCamera.orthographicSize), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);

            spawner.SpawnEnemyFormation(enemyFormation);
        }
        previousPos = enemyWaves[enemyWaves.Count - 1].EnemyPosition;
    }

    //Randomize enemies and instantiate correct prefab per enemy
    private void ChooseEnemyType(SpawnableEnemyFormation enemySection)
    {
        //Get random value within the enumerator
        Enumerators.EnemyTypes enemyType;
        enemyType = Enumerators.GetRandomEnumValue<Enumerators.EnemyTypes>();

        switch (enemyType)
        {
            case Enumerators.EnemyTypes.nonShooting:
                enemySection.EnemyPrefab = enemyPrefabs[0];
                break;
            case Enumerators.EnemyTypes.stationary:
                enemySection.EnemyPrefab = enemyPrefabs[1];
                break;
            case Enumerators.EnemyTypes.rotating:
                enemySection.EnemyPrefab = enemyPrefabs[2];
                break;
            case Enumerators.EnemyTypes.shotgun:
                enemySection.EnemyPrefab = enemyPrefabs[3];
                break;
            case Enumerators.EnemyTypes.laser:
                enemySection.EnemyPrefab = enemyPrefabs[4];
                break;
            case Enumerators.EnemyTypes.waveShot:
                enemySection.EnemyPrefab = enemyPrefabs[5];
                break;
            case Enumerators.EnemyTypes.gatling:
                enemySection.EnemyPrefab = enemyPrefabs[6];
                break;
            case Enumerators.EnemyTypes.homing:
                enemySection.EnemyPrefab = enemyPrefabs[7];
                break;
            case Enumerators.EnemyTypes.bloom:
                enemySection.EnemyPrefab = enemyPrefabs[8];
                break;
            case Enumerators.EnemyTypes.superBloom:
                enemySection.EnemyPrefab = enemyPrefabs[9];
                break;
        }
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
