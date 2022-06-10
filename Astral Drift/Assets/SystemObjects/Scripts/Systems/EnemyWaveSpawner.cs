using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour
{
    //Screen resolution variables
    float ScreenY, aspectRatio, ScreenX, halfScreenX;
    //Basic enemy variables
    float enemySize = 0.5f, distBetweenEnemies = 1.5f;

    private void Start()
    {
        ScreenY = GlobalReferenceManager.MainCamera.orthographicSize * 2; //Screen X size
        aspectRatio = (float)Screen.width / (float)Screen.height;
        ScreenX = ScreenY * aspectRatio;
        halfScreenX = ScreenX / 2;
    }

    public void SpawnEnemyFormation(SpawnableEnemyFormation enemyFormation)
    {
        //This spawns an enemy section in any given enemy formation. Difference between switch cases is the placement of the enemy. 
        float halfAmount = enemyFormation.Amount / 2;

        Vector2 newStartPos = enemyFormation.EnemyPosition - new Vector2(distBetweenEnemies * halfAmount, 0);
        if (newStartPos.x < -halfScreenX)
        {
            float diff = -halfScreenX - newStartPos.x;
            newStartPos.x += diff + enemySize;
        }
        else if (newStartPos.x + (distBetweenEnemies * enemyFormation.Amount - 1) > halfScreenX)
        {
            float diff = newStartPos.x + ((distBetweenEnemies * enemyFormation.Amount - 1) - halfScreenX);
            newStartPos.x -= diff + enemySize;
        }

        Enumerators.EnemyFormationTypes formation;
        formation = enemyFormation.FormationType;

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
