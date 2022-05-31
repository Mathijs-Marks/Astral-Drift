using UnityEngine;

public class BaseGunBarrel : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject gunMuzzle;

    [SerializeField] protected float projectileSpeed = 2;
    [SerializeField] protected int projectileDamage = 30;

    [SerializeField] protected bool shootOnStart = false;
    [SerializeField] protected float shootingRate = 1;
    protected float elapsedTime;

    [HideInInspector] public bool allowedToShoot = false;

    protected void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        BaseBullet bulletScript = Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation).GetComponent<BaseBullet>();

        bulletScript.InitializeBullet(projectileDamage, projectileSpeed);
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
