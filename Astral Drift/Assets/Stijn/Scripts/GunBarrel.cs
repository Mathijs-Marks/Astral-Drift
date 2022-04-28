using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    //Get Owner variables
    public GameObject ownerRef;
    private StationaryEnemy enemyRef;
    [HideInInspector]
    public float movementSpeed;

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
    private Vector3 projectileSize;

    // Start is called before the first frame update
    void Start()
    {
        enemyRef = ownerRef.GetComponent<StationaryEnemy>();
        movementSpeed = enemyRef.movementSpeed;
        StartCoroutine(SpawnObject());
    }

    void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        spawnedProjectile = (GameObject)Instantiate(projectilePrefab, Object.transform);
        spawnedProjectile.GetComponent<Bullet>().ActivateBullet("Player", gunMuzzle.transform.position, new Vector3(0, 0, 1), projectileMovementMultiplier, 1, 10);
        //spawnedProjectile.GetComponent<Bullet>().speedMultiplier = projectileMovementMultiplier;
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
}
