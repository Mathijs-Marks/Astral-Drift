using UnityEngine;

public class BaseGunBarrel : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject gunMuzzle;

    [SerializeField] protected bool shootOnStart = false;
    [SerializeField] protected float shootingRate = 1;
    protected float elapsedTime;

    [HideInInspector] public bool allowedToShoot = false;

    protected void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation);
    }

    protected void Shoot()
    {
        if (allowedToShoot)
        {
            SpawnProjectile(gunMuzzle);
        }
    }

    public void IncreaseShootingSpeed(float amount)
    {
        shootingRate -= amount;
    }
}
