using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyTypes[] circlingEnemies;
    [SerializeField] private EnemyTypes[] strafingEnemies;
    private void Start()
    {
        circlingEnemies = new EnemyTypes[circlingEnemies.Length];

        //Spawn all enemies that we want
        for (int i = 0; i < circlingEnemies.Length; i++)
        {
            circlingEnemies[i].SpawnEnemy();
        }

        strafingEnemies = new EnemyTypes[strafingEnemies.Length];

        //Spawn all enemies that we want
        for (int i = 0; i < strafingEnemies.Length; i++)
        {
            strafingEnemies[i].SpawnEnemy();
        }
    }
}
