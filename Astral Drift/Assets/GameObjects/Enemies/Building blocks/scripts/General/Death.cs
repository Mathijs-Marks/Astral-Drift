using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    protected UnityEvent deathEvent;

    public UnityEvent DeathEvent
    {
        get { return deathEvent; }
        set { deathEvent = value; }
    }

    private void Start()
    {
        DeathEvent = new UnityEvent();
        DeathEvent.AddListener(KillObject);
    }

    protected virtual void KillObject()
    {
        gameObject.SetActive(false);
    }
}
