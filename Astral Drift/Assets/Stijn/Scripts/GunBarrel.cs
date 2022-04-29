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
    private GameObject spawnedProjectile;

    [SerializeField]
    public float projectileMovementMultiplier = 1f;
    [SerializeField]
    private float secondsBeforeFiringAgain = 1;
    [SerializeField]
    private Vector3 projectileSize = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        spawnedProjectile = (GameObject)Instantiate(projectilePrefab, Object.transform.position, Object.transform.rotation);
        spawnedProjectile.GetComponent<Bullet>().ActivateBullet(collisionTag, gunMuzzle.transform.position, new Vector3(0, 0, 1), projectileMovementMultiplier, 1, 10);
        spawnedProjectile.transform.localScale = projectileSize;
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBeforeFiringAgain);
            SpawnProjectile(gunMuzzle);
        }

    }

    public void IncreaseShootingSpeed(float amount)
    {
        secondsBeforeFiringAgain -= amount;
    }
}
