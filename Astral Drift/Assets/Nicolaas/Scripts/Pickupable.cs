using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PickUp();
        }
    }

    protected virtual void PickUp()
    {
        gameObject.SetActive(false);
    }
}
