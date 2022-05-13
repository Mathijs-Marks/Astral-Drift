using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    [SerializeField] private SpawnableEnemyFormation[] enemies;
    private void Start()
    {
        //This spawns all enemies in every given enemy formation. Diffrence between switch cases is the placement of the enemy.
        Enumerators.EnemyFormationTypes formation;
        for (int i = 0; i < enemies.Length; i++)
        {
            int halfAmount = enemies[i].getAmount() / 2;
            formation = enemies[i].getFormation();

            //Check which formation to spawn 'getAmount()' amount of enemies in.
            switch (formation)
            {
                case Enumerators.EnemyFormationTypes.HorizontalLine:
                    for(int n = 0; n < enemies[i].getAmount(); n++)
                    {
                        Instantiate(enemies[i].getPrefab(), enemies[i].getPos() - new Vector2(halfAmount + n, 0), Quaternion.identity);
                    }
                    break;
                case Enumerators.EnemyFormationTypes.VerticalLine:
                    for (int n = 0; n < enemies[i].getAmount(); n++)
                    {
                        Instantiate(enemies[i].getPrefab(), enemies[i].getPos() - new Vector2(0, halfAmount + n), Quaternion.identity);
                    }
                    break;
                case Enumerators.EnemyFormationTypes.RightDiagonal:
                    for (int n = 0; n < enemies[i].getAmount(); n++)
                    {
                        Instantiate(enemies[i].getPrefab(),enemies[i].getPos() - new Vector2(halfAmount + n, halfAmount + n), Quaternion.identity);
                    }
                    break;
                case Enumerators.EnemyFormationTypes.LeftDiagonal:
                    for (int n = 0; n < enemies[i].getAmount(); n++)
                    {
                        Instantiate(enemies[i].getPrefab(), enemies[i].getPos() - new Vector2(halfAmount + n, halfAmount - n), Quaternion.identity);
                    }
                    break;
                case Enumerators.EnemyFormationTypes.VFormation:

                    for (int n = -halfAmount; n < halfAmount + 1; n++)
                    {
                        Instantiate(enemies[i].getPrefab(), enemies[i].getPos() + new Vector2(halfAmount + n, Mathf.Pow(n, 2)), Quaternion.identity);
                    }
                    break;
            }
        }
    }
}
