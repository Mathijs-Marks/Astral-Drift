using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPickupable : Pickupable
{
    // A model is needed to not get issues with the collider.
    [SerializeField] private GameObject model;

    [SerializeField] private int scoreIncrease = 10;
    [SerializeField] private float pickupTime;
    [SerializeField] [Range(0, 1)] private float scaleWhenCollected; // This is a percentage value, thus ranging from 0 to 1

    private Vector3 originalScale;
    private float timer;
    private bool beingPickedUp;

    private void Start()
    {
        // This causes it to do less math for fixed update. Not done the other way around to make serialize field easier to understand.
        scaleWhenCollected = 1 - scaleWhenCollected;
        originalScale = model.transform.localScale;
    }

    // Timers
    private void FixedUpdate()
    {
        if (beingPickedUp)
        {
            timer += Time.deltaTime;
            model.transform.localScale = originalScale * (1 - (timer * scaleWhenCollected) / pickupTime);

            if (timer > pickupTime)
            {
                ConfirmPickUp();
            }
        }
    }

    protected override void PickUp(Collider2D collision)
    {
        // Do not call for base as that will remove the pickupable on collision

        beingPickedUp = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset timer and scale.
        beingPickedUp = false;
        timer = 0;
        model.transform.localScale = originalScale;
    }

    // Actual pickup
    private void ConfirmPickUp()
    {
        UI.instance.AddScore(scoreIncrease);
        gameObject.SetActive(false);
    }
}
