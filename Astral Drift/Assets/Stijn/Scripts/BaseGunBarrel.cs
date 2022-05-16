using System.Collections;
using UnityEngine;

public class BaseGunBarrel : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject gunMuzzle;

    [SerializeField] private bool shootOnStart = false;
    [SerializeField] private float shootingRate = 1;

    public bool allowedToShoot = true;

    private float elapsed;

    void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation);
    }

    protected virtual void FixedUpdate()
    {
        if (allowedToShoot)
        {
            if (elapsed > shootingRate)
            {
                SpawnProjectile(gunMuzzle);
                elapsed = 0;
            }
        }
        elapsed += Time.deltaTime;
    }

    public void IncreaseShootingSpeed(float amount)
    {
        shootingRate -= amount;
    }
}
