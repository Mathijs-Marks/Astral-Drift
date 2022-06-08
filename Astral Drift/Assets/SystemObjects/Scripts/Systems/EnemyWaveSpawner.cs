using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    public void SpawnEnemyFormation(SpawnableEnemyFormation enemyFormation)
    {
        //This spawns an enemy section in any given enemy formation. Difference between switch cases is the placement of the enemy.
        Enumerators.EnemyFormationTypes formation;
        int halfAmount = enemyFormation.Amount / 2;
        formation = enemyFormation.FormationType;

        //Check which formation to spawn 'Amount' amount of enemies in.
        switch (formation)
        {
            case Enumerators.EnemyFormationTypes.HorizontalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount * n, 0), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.VerticalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(0, halfAmount * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.RightDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount + n, halfAmount * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.LeftDiagonal:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount - n, halfAmount * n), Quaternion.identity);
                }
                break;
            case Enumerators.EnemyFormationTypes.VFormation:

                for (int n = -halfAmount; n < halfAmount + 1; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount + n, Mathf.Pow(n, 2)), Quaternion.identity);
                }
                break;
        }
    }
}
