using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{
    public GameObject fullBar, mask;

    
    public int percentage;
    
    public float spriteSize = 686;
    private float amount;
    // Start is called before the first frame update
    void Start()
    {
        percentage = 50;
       
    }

    // Update is called once per frame
    void Update()
    {
        amount = (100-percentage) * spriteSize / 100;

        fullBar.transform.localPosition = new Vector3(0, amount, 0);
        mask.transform.localPosition = new Vector3(0, -amount, 0);
    }
}
