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
        //Idea's list:
        // make wall check statements per formation and then move it?
        // remove v formation
        //
        // If anything spawns outside of the screen just delete it
        // 
        // Only spawn thing in the middle with a *SLIGHT* random change left and right
        // 
        // fix diagonal so they generate from the middle kinda like the rest
        //

        //This spawns an enemy section in any given enemy formation. Difference between switch cases is the placement of the enemy.
        Enumerators.EnemyFormationTypes formation = enemyFormation.FormationType;
        float halfAmount = enemyFormation.Amount / 2;
        
        Vector2 newStartPos = enemyFormation.EnemyPosition - new Vector2(distBetweenEnemies * halfAmount, 0);
        if (newStartPos.x < -halfScreenX)
        {
            float diff = newStartPos.x + halfScreenX;
            Debug.Log("Left wall collision: " + enemyFormation.Amount + " " + enemyFormation.EnemyPrefab.name + " Old pos: " + newStartPos.x + " New pos:" + (newStartPos.x - diff));
            newStartPos.x -= diff - outOfBoundsOffset;
        }
        else if (newStartPos.x + (distBetweenEnemies * enemyFormation.Amount - 1) > halfScreenX)
        {
            float diff = newStartPos.x - halfScreenX;
            Debug.Log("Right wall collision: " + enemyFormation.Amount + " " + enemyFormation.EnemyPrefab.name + " Old pos: " + (newStartPos.x + (distBetweenEnemies * enemyFormation.Amount - 1)) + " New pos:" + (newStartPos.x + diff));
            newStartPos.x += diff + outOfBoundsOffset;
        }

        //Check which formation to spawn 'Amount' amount of enemies in.
        switch (formation)
        {
            case Enumerators.EnemyFormationTypes.HorizontalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, newStartPos + new Vector2(distBetweenEnemies * n, 0), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.VerticalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, newStartPos + new Vector2(0, distBetweenEnemies * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.RightDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, newStartPos + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.LeftDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, newStartPos + new Vector2(distBetweenEnemies * n, distBetweenEnemies * n), Quaternion.identity);
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
