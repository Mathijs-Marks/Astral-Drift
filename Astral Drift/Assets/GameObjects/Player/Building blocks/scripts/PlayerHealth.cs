using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    private void Awake()
    {
        GlobalReferenceManager.PlayerHealthScript = this;
    }
}
