using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MovementBehaviours
{
    [SerializeField] private GameObject[] bossParts;
    int currentInactiveParts = 0;

    private Vector3 startpos;
    [SerializeField] private float movingTime = 4;
    private bool movingRight;
    private float passedTime;
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

        if (movingRight)
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        else
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;

        passedTime += Time.deltaTime;
        if (passedTime > movingTime)
        {
            movingRight = !movingRight;
            passedTime = 0;
        }
    }
}
