using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    public void SpawnEnemyFormation(SpawnableEnemyFormation enemyFormation)
    {
        float ScreenY = GlobalReferenceManager.MainCamera.orthographicSize * 2; //Screen X size
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float ScreenX = ScreenY * aspectRatio; //Screen Y size
        float halfScreenX = ScreenX / 2;

        //This spawns an enemy section in any given enemy formation. Difference between switch cases is the placement of the enemy.
        Enumerators.EnemyFormationTypes formation;
        float halfAmount = enemyFormation.Amount / 2;
        float distBetweenEnemies = 1.5f;

        Debug.Log(-halfScreenX);

        Vector2 newStartPos = enemyFormation.EnemyPosition - new Vector2(distBetweenEnemies * halfAmount, 0);
        if (newStartPos.x < -halfScreenX)
        {
            float diff = newStartPos.x + halfScreenX;
            newStartPos.x += diff;
        }
        else if (newStartPos.x + (distBetweenEnemies * enemyFormation.Amount) > halfScreenX)
        {
            float diff = newStartPos.x - halfScreenX;
            newStartPos.x -= diff;
        }

        formation = enemyFormation.FormationType;

        //Check which formation to spawn 'Amount' amount of enemies in.
        switch (formation)
        {
            case Enumerators.EnemyFormationTypes.HorizontalLine:
                for (int n = 0; n < enemyFormation.Amount; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, newStartPos + (new Vector2(distBetweenEnemies * n, 0)), Quaternion.identity);
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

                for (int n = (int)-halfAmount; n < halfAmount + 1; n++)
                {
                    Instantiate(enemyFormation.EnemyPrefab, enemyFormation.EnemyPosition + new Vector2(halfAmount + n, Mathf.Pow(n, 2)), Quaternion.identity);
                }
                break;
        }
    }
}
