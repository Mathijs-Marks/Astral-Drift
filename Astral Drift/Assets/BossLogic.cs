using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] bossParts;
    int currentInactiveParts = 0;

    void FixedUpdate()
    {
        currentInactiveParts = 0;
        for(int i = 0; i<bossParts.Length-1;i++)
        {
            if (!bossParts[i].activeSelf)
            {
                currentInactiveParts++;
            }
        }
        if(currentInactiveParts == bossParts.Length)
        {
            this.gameObject.SetActive(false);
        }
    }
}
