using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private float distBetweenEnemies = 1.5f, outOfBoundsOffset;
    private float halfScreenX;
    private void Start()
    {
        halfScreenX = GlobalReferenceManager.ScreenCollider.sizeX / 2;
    }
    public void SpawnEnemyFormation(SpawnableEnemyFormation enemyFormation)
    {
        //TODO MAYBE?
        // make wall check statements per formation
        // remove v formation

        //This spawns an enemy section in any given enemy formation. Difference between switch cases is the placement of the enemy.
        Enumerators.EnemyFormationTypes formation = enemyFormation.FormationType;
        float halfAmount = enemyFormation.Amount / 2;
        
        Vector2 centerdStartPosition = enemyFormation.EnemyPosition - new Vector2(distBetweenEnemies * halfAmount, 0);
        if (centerdStartPosition.x < -halfScreenX)
        {
            float diff = centerdStartPosition.x + halfScreenX;
            Debug.Log("Left wall collision: " + enemyFormation.Amount + " " + enemyFormation.EnemyPrefab.name + " Old pos: " + centerdStartPosition.x + " New pos:" + (centerdStartPosition.x - diff));
            centerdStartPosition.x -= diff - outOfBoundsOffset;
        }
        else if (centerdStartPosition.x + (distBetweenEnemies * enemyFormation.Amount - 1) > halfScreenX)
        {
            float diff = centerdStartPosition.x - halfScreenX;
            Debug.Log("Right wall collision: " + enemyFormation.Amount + " " + enemyFormation.EnemyPrefab.name + " Old pos: " + (centerdStartPosition.x + (distBetweenEnemies * enemyFormation.Amount - 1)) + " New pos:" + (centerdStartPosition.x + diff));
            centerdStartPosition.x += diff + outOfBoundsOffset;
        }

        //Check which formation to spawn 'Amount' amount of enemies in.
        switch (formation)
        {
            case Enumerators.EnemyFormationTypes.HorizontalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, centerdStartPosition + new Vector2(distBetweenEnemies * n, 0), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.VerticalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, centerdStartPosition + new Vector2(0, distBetweenEnemies * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.RightDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, centerdStartPosition + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.LeftDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, centerdStartPosition + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.VFormation:

                for (int n = (int)-halfAmount; n < halfAmount + 1; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount + n, Mathf.Pow(n, 2)), Quaternion.identity);
                }
                break;
        }
    }
}
