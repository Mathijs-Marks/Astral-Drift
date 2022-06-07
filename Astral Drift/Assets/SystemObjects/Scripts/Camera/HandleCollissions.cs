using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollissions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(7))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
