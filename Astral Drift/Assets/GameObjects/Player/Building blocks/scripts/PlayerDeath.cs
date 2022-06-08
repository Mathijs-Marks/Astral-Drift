using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : Death
{
    protected override void KillObject()
    {
        base.KillObject();

        GlobalReferenceManager.GameOverMenu.ScreenEvent.Invoke(GlobalReferenceManager.GameOverMenu.gameOverScreen);
    }
}
