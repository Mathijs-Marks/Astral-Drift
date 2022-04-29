using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBarrel : MonoBehaviour
{
    [SerializeField] private string collisionTag;
    [SerializeField] private float bulletLifespan;

    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject gunMuzzle;
    private GameObject spawnedProjectile;

    [SerializeField]
    private float secondsBeforeFiringAgain = 1;
    [SerializeField]
    private float laserWidth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    void SpawnProjectile(GameObject Object)
    {
        //Spawn a projectile
        spawnedProjectile = (GameObject)Instantiate(laserPrefab, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
        spawnedProjectile.GetComponent<Laser>().Instantiate(collisionTag, gunMuzzle.transform.position, new Vector3(0, 0, 1), 1, bulletLifespan);
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