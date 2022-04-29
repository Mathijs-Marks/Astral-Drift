using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPickupable : Pickupable
{
    [SerializeField] private int scoreIncrease = 10;
    [SerializeField] private float pickupTime;
    private float timer;
    private bool beingPickedUp;

    // Timers
    private void FixedUpdate()
    {
        if (beingPickedUp)
        {
            timer += Time.deltaTime;

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
        beingPickedUp = false;
    }

    // Actual pickup
    private void ConfirmPickUp()
    {
        UI.instance.AddScore(scoreIncrease);
        gameObject.SetActive(false);
    }
}
