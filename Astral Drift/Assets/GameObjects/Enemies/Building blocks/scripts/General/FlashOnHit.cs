using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class FlashOnHit : MonoBehaviour
{
    private Material material;

    private Texture2D modelTexture; // Normal texture to return to when flashing
    [SerializeField] private Texture2D flashTexture; // Flash texture used to get this effect

    [SerializeField] private float flashTime = 0.05f;
    private float timer;

    private void Start()
    {
        timer = 0;
        material = GetComponent<Renderer>().material;
        modelTexture = (Texture2D)material.GetTexture("_MainTex");
    }

    private void FixedUpdate()
    {
        // Only flash for a few seconds. When time is expired, apply the normal texture back again
        TimerTickDown();
    }

    private void TimerTickDown()
    {
        // Check timer values
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // Apply texture
                material.SetTexture("_MainTex", modelTexture);
            }
        }
    }

    // Flash with a texture
    public void Flash()
    {
        material.SetTexture("_MainTex", flashTexture);
        timer = flashTime;
    }
}
