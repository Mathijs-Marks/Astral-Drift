using UnityEngine;

[RequireComponent(typeof(SimplePool))]
public class BaseGunBarrel : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject gunMuzzle;
    private SimplePool pool;
    [SerializeField] protected float projectileSpeed = 2;
    [SerializeField] protected int projectileDamage = 30;

    [Header("Shooting offset timer is the starting timer for this barrel")]
    [SerializeField] protected float shootingRate = 1;
    [SerializeField] protected float shootingOffsetTimer = 0;
    protected float elapsedTime;

    [HideInInspector] public bool allowedToShoot = false;

    protected virtual void Start()
    {
        pool = gameObject.GetComponent<SimplePool>();
        pool.AddBulletVariables(projectileDamage, projectileSpeed);

        elapsedTime = shootingOffsetTimer;
    }

    protected void SpawnProjectile()
    {
        pool.SpawnFrompool(gunMuzzle.transform.position, gunMuzzle.transform.rotation);
    }

    protected void Shoot()
    {
        if (allowedToShoot)
        {
            SpawnProjectile();
        }
    }

    public void IncreaseShootingSpeed(float amount)
    {
        shootingRate -= amount;
    }
}
