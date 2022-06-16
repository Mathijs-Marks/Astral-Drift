using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private int positionMaxRerolls;
    private LevelDifficultyManager difficultyManager;
    private int usedTries;

    private void Start()
    {
        difficultyManager = GetComponent<LevelDifficultyManager>();
    }
    public void SpawnEnemy(EnemyData enemyData)
    {
        usedTries = 0;
        GameObject enemy = Instantiate(enemyData.EnemyPrefab, enemyData.EnemyPosition, Quaternion.identity);
        OverlapCheck(enemy);
    }
    private void OverlapCheck(GameObject enemy)
    {
        if (usedTries <= positionMaxRerolls)
        {
            for (int i = difficultyManager.lastTopIndex; i < difficultyManager.enemyDataList.Count; i++)
            {
                if (Mathf.Abs(enemy.transform.position.x - difficultyManager.enemyDataList[i].EnemyPosition.x) < 0.5f && Mathf.Abs(enemy.transform.position.y - difficultyManager.enemyDataList[i].EnemyPosition.y) < 0.5f)
                {
                    enemy.transform.position = difficultyManager.randomisePosition();
                    OverlapCheck(enemy);
                }
            }
            usedTries++;
        }
    }
}

/*private void outOfBoundsCheck()
{
    for (int i = 1; i < spawnedEnemies.Count; i++)
    {
        bool isOutofBounds = spawnedEnemies[i].transform.position.x < -halfScreenX || spawnedEnemies[i].transform.position.x > halfScreenX;

        if (isOutofBounds)
        {
            float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - 1;
            Debug.Log(spawnedEnemies[i].name + " is out of bounds");
            Vector2 newPos = new Vector2(Random.Range(-withinScreenRange, withinScreenRange), spawnedEnemies[Random.Range(0, )].transform.position.y + distBetweenEnemies);
            spawnedEnemies[i].transform.position = newPos;
        }
    }
}
    
switch (formation)
        {
            case Enumerators.EnemyFormationTypes.HorizontalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    spawnedEnemies.Add(Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(distBetweenEnemies * n, 0), Quaternion.identity));
                }
                break;
            case Enumerators.EnemyFormationTypes.VerticalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    spawnedEnemies.Add(Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(0, distBetweenEnemies * n), Quaternion.identity));
                }
                break;
            case Enumerators.EnemyFormationTypes.RightDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    spawnedEnemies.Add(Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity));
                }
                break;
            case Enumerators.EnemyFormationTypes.LeftDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    spawnedEnemies.Add(Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity));
                }
                break;
            case Enumerators.EnemyFormationTypes.VFormation:
                for (int n = (int)-halfAmount; n < halfAmount + 1; n++)
                {
                    spawnedEnemies.Add(Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount + n, Mathf.Pow(n, 2)), Quaternion.identity));
                }
                break;
        }*/