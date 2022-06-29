using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with this object, invoke a pop up screen event in game over menu from global reference manager
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GlobalReferenceManager.GameOverMenu.ScreenEvent.Invoke(GlobalReferenceManager.GameOverMenu.victoryScreen);
            UI.instance.UpdateScore(GlobalReferenceManager.UIMenu.victoryScore);
        }
    }
}
