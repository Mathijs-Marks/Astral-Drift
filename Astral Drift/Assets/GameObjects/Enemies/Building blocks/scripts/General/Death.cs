using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    protected UnityEvent deathEvent;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float healthDropChance = 0.1f;
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private GameObject healthDrop;

    public UnityEvent DeathEvent
    {
        get { return deathEvent; }
        set { deathEvent = value; }
    }

    private void Start()
    {
        DeathEvent = new UnityEvent();
        DeathEvent.AddListener(KillObject);
    }

    protected virtual void KillObject()
    {
        gameObject.SetActive(false);
        InstantiateObjects();
        
    }
protected virtual void InstantiateObjects()
    {
        if (gameObject.layer != LayerMask.NameToLayer("Player") && GlobalReferenceManager.PlayerHealthScript.canSpawnHealthPickups)
        {
            float healthSpawn = Random.Range(0f, 1f);
            if (healthSpawn < healthDropChance)
                Instantiate(healthDrop, transform.position, Quaternion.identity);
        }

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        if (pickupPrefab != null)
        {
            //Debug.Log("Dropped a star by: " + gameObject.name);
            Instantiate(pickupPrefab, transform.position, transform.rotation);
        }

        if(GlobalReferenceManager.AudioManagerRef != null)
            GlobalReferenceManager.AudioManagerRef.PlaySound("Explosion");
    }
}
