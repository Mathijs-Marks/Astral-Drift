using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private float maxEnemyCollisionRange;
    [SerializeField] private List<GameObject> enemies;
    private LevelDifficultyManager difficultyManager;

    private void Start()
    {
        difficultyManager = GetComponent<LevelDifficultyManager>();
        enemies = new List<GameObject>();
    }
    public void SpawnEnemy(EnemyData enemyData)
    {
        GameObject enemy = Instantiate(enemyData.EnemyPrefab, enemyData.EnemyPosition, Quaternion.identity);
        enemies.Add(enemy);
    }
    public void OverlapCheck()
    {
        for (int a = difficultyManager.lastTopIndex; a < difficultyManager.enemyDataList.Count; a++)
        {   
            for (int b = difficultyManager.lastTopIndex; b < difficultyManager.enemyDataList.Count; b++)
            {

                if (Mathf.Abs(enemies[a].transform.position.x - enemies[b].transform.position.x) < maxEnemyCollisionRange && Mathf.Abs(enemies[a].transform.position.y - enemies[b].transform.position.y) < maxEnemyCollisionRange)
                {
                    Vector2 direction = (enemies[b].transform.position - enemies[a].transform.position).normalized;
                    direction *= maxEnemyCollisionRange;
                    enemies[a].transform.position -= new Vector3(direction.x, direction.y, 0);
                    outOfBoundsCheck(enemies[a]);
                }
            }
        }
    }
    private void outOfBoundsCheck(GameObject enemy)
    {
        float halfScreenX = GlobalReferenceManager.ScreenCollider.sizeX / 2;

        if (enemy.transform.position.x < -halfScreenX)
        {
            Debug.Log("Out of bounds: Left");
            float distOutOfBounds = enemy.transform.position.x + halfScreenX;
            Vector2 newPos = new Vector2((distOutOfBounds * -1) + enemy.transform.localScale.x / 2, 0);
            enemy.transform.position += (Vector3)newPos;
        }else if (enemy.transform.position.x > halfScreenX)
        {
            Debug.Log("Out of bounds: Right");
            float distOutOfBounds = halfScreenX - enemy.transform.position.x;
            Vector2 newPos = new Vector2(distOutOfBounds - enemy.transform.localScale.x / 2, 0);
            enemy.transform.position += (Vector3)newPos;
        }

        /*for (int a = difficultyManager.lastTopIndex; a < difficultyManager.enemyDataList.Count; a++)
        {
            if (Mathf.Abs(enemy.transform.position.x - enemies[a].transform.position.x) < maxEnemyCollisionRange && Mathf.Abs(enemy.transform.position.y - enemies[a].transform.position.y) < maxEnemyCollisionRange)
            {
            }
        }*/
    }
}

/*
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