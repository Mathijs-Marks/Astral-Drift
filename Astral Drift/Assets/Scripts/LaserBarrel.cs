using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBarrel : MonoBehaviour
{
    [SerializeField] private LineRenderer aimingLaserRenderer;

    [SerializeField] private string collisionTag;
    [SerializeField] private float laserLifespan;
    [SerializeField] private float laserLength;

    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject gunMuzzle;
    private GameObject spawnedLaser;

    [SerializeField]
    private float secondsBeforeFiringAgain = 1;
    [SerializeField]
    private float laserWidth = 0.1f;
    [SerializeField] private float laserAimingWidth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());

        aimingLaserRenderer.startWidth = laserAimingWidth;
        aimingLaserRenderer.SetPosition(1, new Vector3(0, 0, 1) * laserLength);
    }

    void SpawnLaser(GameObject Object)
    {
        //Spawn a laser
        spawnedLaser = (GameObject)Instantiate(laserPrefab, gunMuzzle.transform);
        spawnedLaser.GetComponent<Laser>().Instantiate(collisionTag, gunMuzzle.transform.position, new Vector3(0, 0, 1), laserLength, 1, laserLifespan, laserWidth);
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBeforeFiringAgain);
            SpawnLaser(gunMuzzle);
        }

    }

    public void IncreaseShootingSpeed(float amount)
    {
        secondsBeforeFiringAgain -= amount;
    }
}
