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

    //Check if placed enemy overlaps with all other NEW enemies.
    //We only check the new enemies within a new wave to reduce performance cost.
    public void OverlapCheck()
    {
        for (int a = difficultyManager.lastTopIndex; a < difficultyManager.enemyDataList.Count; a++)
        {   
            for (int b = difficultyManager.lastTopIndex; b < difficultyManager.enemyDataList.Count; b++)
            {
                //If enemy A is within maxEnemyCollisionRange distance of enemy B then move enemy A
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

    //Once we have potentionally moved an enemy we need to check if we moved it outside of the game bounds, if so move it back within bounds.
    private void outOfBoundsCheck(GameObject enemy)
    {
        float halfScreenX = GlobalReferenceManager.ScreenCollider.sizeX / 2;

        //If enemy is outside the left side of the screen move it to the right.
        if (enemy.transform.position.x < -halfScreenX)
        {
            float distOutOfBounds = enemy.transform.position.x + halfScreenX;
            Vector2 newPos = new Vector2((distOutOfBounds * -1) + enemy.transform.localScale.x / 2, 0);
            enemy.transform.position += (Vector3)newPos;
        
        }
        //If enemy is outside the right side of the screen move it to the left.
        else if (enemy.transform.position.x > halfScreenX)
        {
            float distOutOfBounds = halfScreenX - enemy.transform.position.x;
            Vector2 newPos = new Vector2(distOutOfBounds - enemy.transform.localScale.x / 2, 0);
            enemy.transform.position += (Vector3)newPos;
        }
    }
}