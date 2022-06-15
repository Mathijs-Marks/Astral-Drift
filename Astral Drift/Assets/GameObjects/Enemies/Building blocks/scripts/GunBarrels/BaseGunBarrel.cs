using UnityEngine;

[RequireComponent(typeof(SimplePool))]
public class BaseGunBarrel : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject gunMuzzle;
    private SimplePool pool;
    [SerializeField] protected float projectileSpeed = 2;
    [SerializeField] protected int projectileDamage = 30;

    [SerializeField] protected bool shootOnStart = false;
    [SerializeField] protected float shootingRate = 1;
    protected float elapsedTime;

    [HideInInspector] public bool allowedToShoot = false;

    protected virtual void Start()
    {
        pool = gameObject.GetComponent<SimplePool>();
        pool.AddBulletVariables(projectileDamage, projectileSpeed);
    }

    protected void SpawnProjectile()
    {
        pool.SpawnFrompool(gunMuzzle.transform.position, gunMuzzle.transform.rotation);
        //pool.AddBulletVariables(projectileDamage, projectileSpeed);

        //Spawn a projectile
    /*    BaseBullet bulletScript = Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation).GetComponent<BaseBullet>();

        bulletScript.InitializeBullet(projectileDamage, projectileSpeed);*/
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
