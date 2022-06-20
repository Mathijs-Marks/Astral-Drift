using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class FlashOnHit : MonoBehaviour
{
    private Material material;

    private Texture2D modelTexture;
    [SerializeField] private Texture2D flashTexture;

    [SerializeField] private float flashTime = 0.1f;
    private float timer;

    private void Start()
    {
        timer = 0;
        material = GetComponent<Renderer>().material;
        modelTexture = (Texture2D)material.GetTexture("_MainTex");

        Flash();
    }

    public void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                material.SetTexture("_MainTex", modelTexture);
            }
        }
    }

    public void Flash()
    {
        material.SetTexture("_MainTex", flashTexture);
        timer = flashTime;
    }
}
