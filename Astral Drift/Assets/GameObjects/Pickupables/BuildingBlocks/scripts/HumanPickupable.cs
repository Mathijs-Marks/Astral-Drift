using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPickupable : Pickupable
{
    // A model is needed to not get issues with the collider.
    [SerializeField] private GameObject model;

    [SerializeField] private int scoreIncrease = 10;
    [SerializeField] [Range(0, 1)] private float scaleDecrease; // This is a percentage value, thus ranging from 0 to 1

    private Vector3 originalScale;
    private bool beingPickedUp;
    private void Start()
    {
        originalScale = model.transform.localScale;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Pick up this object and scale it down in size
        if (beingPickedUp)
        {
            model.transform.localScale -= new Vector3(scaleDecrease, scaleDecrease, scaleDecrease) * Time.deltaTime;
            if (model.transform.localScale.x <= scaleDecrease * 2)
            {
                ConfirmPickUp();
            }
        }
    }

    public override void OnPickUp(Collider2D collision)
    {
        // Do not call for base as that will remove the pickupable on collision

        beingPickedUp = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Stop trying to pick up this object
        beingPickedUp = false;
        model.transform.localScale = originalScale;
    }

    // Actual pickup
    private void ConfirmPickUp()
    {
        UI.instance.AddScore(scoreIncrease);
        gameObject.SetActive(false);

        //Play pickup sound
        if (GlobalReferenceManager.AudioManagerRef != null)
            GlobalReferenceManager.AudioManagerRef.PlaySound(pickUpAudioName);

        //Spawn particle effect
        if (particlePrefab != null)
        {
            GameObject newPickup = Instantiate(particlePrefab, transform.position, transform.rotation);
            Destroy(newPickup, particleDestroyTimer);
        }

        //This may be used for statisics or extra info to players. THIS IS NOT YET VISIBLE IN-GAME
        GlobalReferenceManager.HumanSpawnerRef.currentPickedUpHumans++;
    }
}