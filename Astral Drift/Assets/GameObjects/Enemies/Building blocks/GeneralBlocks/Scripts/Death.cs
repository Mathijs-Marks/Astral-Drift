using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    protected UnityEvent deathEvent;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float healthDropChance = 0.1f, firerateUpgradeChance = 0.1f;
    [SerializeField] private int maxDroppableAmountStars = 5;
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject healthDrop;
    [SerializeField] private GameObject fireratePrefab;

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
        //Drops a random amount of stars
        int amountOfStars = Random.Range(1, maxDroppableAmountStars);
        if (starPrefab != null)
        {
            for (int i = 0; i < amountOfStars; i++)
            {
                Instantiate(starPrefab, transform.position, transform.rotation);
            }
        }

        int randomPickup = PickupPicker();
        if (randomPickup == 0) {
            //Have a chance to drop health pickup
            if (gameObject.layer != LayerMask.NameToLayer("Player") && healthDrop != null)
            {
                float healthChanceValue = Random.Range(0f, 1f);
                if (healthChanceValue < healthDropChance)
                    Instantiate(healthDrop, transform.position, Quaternion.identity);
            }
            //Have a chance to drop shooting upgrade pickup
        } else if (randomPickup == 1)
        {
            if (fireratePrefab != null)
            {
                float fireupgadeChanceValue = Random.Range(0f, 1f);
                if (fireupgadeChanceValue < firerateUpgradeChance)
                    Instantiate(fireratePrefab, transform.position, Quaternion.identity);
            }
        }

        //Spawns explosion effect
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            //Play's explosion death sound
            if (GlobalReferenceManager.AudioManagerRef != null)
                GlobalReferenceManager.AudioManagerRef.PlaySound("Explosion");
        }
    }
    private int PickupPicker()
    {
        if (UI.instance.currentUpgrade < UI.instance.maxUpgrade)
        {
            return Random.Range(0, 2);
        }
        else if(GlobalReferenceManager.PlayerHealthScript.canSpawnHealthPickups)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
