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

    private void PickUp()
    {
        UI.instance.AddScore(1);
        gameObject.SetActive(false);
    }
}
