using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageIndicator : MonoBehaviour
{
    [SerializeField] private float fadingSpeed = 1.5f;
    private Image indicator;
    private float alpha;

    private void Start()
    {
        indicator = GetComponent<Image>();
        GlobalReferenceManager.PlayerHealthScript.PlayerOnHitEvent.AddListener(ActivateDamageIndicator);
    }
    private void FixedUpdate()
    {
        FadeIndicator();
    }

    //Slowly fade damage indicator over time
    private void FadeIndicator()
    {
        if (alpha > 0)
        {
            alpha -= Time.deltaTime * fadingSpeed;
            indicator.color = new Color(1, 1, 1, alpha);
        }
    }

    //Make damage indicator completely visible
    private void ActivateDamageIndicator()
    {
        alpha = 1;
    }
}