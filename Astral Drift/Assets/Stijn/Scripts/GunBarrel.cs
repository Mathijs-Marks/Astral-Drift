using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    [SerializeField] private string collisionTag;

    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private GameObject gunMuzzle;

    [SerializeField]
    public float projectileMovementMultiplier = 1f;
    [SerializeField]
    private float secondsBeforeFiringAgain = 1;
    [SerializeField]
    private Vector3 projectileSize = new Vector3(1, 1, 1);
    [SerializeField] float bulletLifespan = 10f;
    [SerializeField] private bool shootOnStart = false;
    public bool allowedToShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        if(shootOnStart)
            StartCoroutine(SpawnObject());
    }

    void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        GameObject spawnedProjectile = Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation);
        spawnedProjectile.GetComponent<Bullet>().ActivateBullet(collisionTag, gunMuzzle.transform.position, new Vector3(0, 1, 0), projectileMovementMultiplier, 1, bulletLifespan);
        spawnedProjectile.transform.localScale = projectileSize;
    }

    public IEnumerator SpawnObject()
    {
        SpawnProjectile(gunMuzzle);
        yield return new WaitForSeconds(secondsBeforeFiringAgain);
        if (allowedToShoot)
            StartCoroutine(SpawnObject());
    }

    public void IncreaseShootingSpeed(float amount)
    {
        secondsBeforeFiringAgain -= amount;
    }
}
