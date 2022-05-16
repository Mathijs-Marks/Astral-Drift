using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingEnemy : AIMovementBehaviours
{
    [SerializeField] private float shootCooldown, shootForTime;
    [SerializeField] private GameObject lookatTarget;
    [SerializeField] private Transform barrelHolder;
    [SerializeField] private List<BaseGunBarrel> gunBarrelScripts = new List<BaseGunBarrel>();
    private float elapsedTime;
    private bool hasFired;
    void Start()
    {
        foreach (Transform child in barrelHolder)
            gunBarrelScripts.Add(child.GetComponentInChildren<BaseGunBarrel>());

        lookatTarget = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootCooldown)
        {
            if (!hasFired)
            {
                Vector3 direction = lookatTarget.transform.position - transform.position;
                for (int i = 0; i < gunBarrelScripts.Count; i++)
                {
                    gunBarrelScripts[i].allowedToShoot = true;
                    StartCoroutine(RotateAndShoot(direction, i));
                }
                hasFired = true;
            }
        }
        if (elapsedTime > shootCooldown + shootForTime)
        {
            for (int i = 0; i < gunBarrelScripts.Count; i++)
            {
                //gunBarrelScripts[i].StopCoroutine(gunBarrelScripts[i].SpawnObject());
                gunBarrelScripts[i].allowedToShoot = false;
            }

            elapsedTime = 0;
            hasFired = false;
        }
    }
    public IEnumerator RotateAndShoot(Vector3 direction, int barrel)
    {
        float elapsed = 0;
        float duration = 1;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            //Rotate towards player before shooting

            Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.forward);
            rotation.x = transform.rotation.x;
            rotation.y = transform.rotation.y;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, elapsed / duration);
            
            if(transform.rotation.z < rotation.z - 1)
            {
                elapsed = duration;
                transform.rotation = rotation;
            }

            yield return null;
        }
        //shoot at player
        //gunBarrelScripts[barrel].StartCoroutine(gunBarrelScripts[barrel].SpawnObject());
    }
}
