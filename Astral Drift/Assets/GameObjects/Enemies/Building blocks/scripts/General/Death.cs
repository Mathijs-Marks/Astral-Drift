using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    protected UnityEvent deathEvent;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject pickupPrefab;

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
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        if (pickupPrefab != null)
        {
            Instantiate(pickupPrefab, transform.position, transform.rotation);
        }
    }
}
