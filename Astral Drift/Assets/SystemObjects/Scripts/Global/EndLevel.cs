using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) // Collision
        {
            GlobalReferenceManager.GameOverMenu.ScreenEvent.Invoke(GlobalReferenceManager.GameOverMenu.victoryScreen);
        }
    }
}
