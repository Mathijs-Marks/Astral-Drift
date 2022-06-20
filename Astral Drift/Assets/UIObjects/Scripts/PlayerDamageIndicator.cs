using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerDamageIndicator : MonoBehaviour
{
    [SerializeField] float alphaSpeed;
    private Image indicator;
    private void Start()
    {
        indicator = GetComponent<Image>();
        alphaSpeed /= 255;
        GlobalReferenceManager.PlayerHealthScript.PlayerOnHitEvent.AddListener(ShowIdicator);
    }
    private void ShowIdicator()
    {
        FadeIn();
        FadeOut();
    }
    private void FadeIn()
    {
        for (float i = 0; i < 1; i += alphaSpeed)
        {
            indicator.color = new Color(indicator.color.r, indicator.color.g, indicator.color.b, i);
        }
    }
    private void FadeOut()
    {
        for (float i = 1; i > 0; i -= alphaSpeed)
        {
            indicator.color = new Color(indicator.color.r, indicator.color.g, indicator.color.b, i);
        }
    }
}
