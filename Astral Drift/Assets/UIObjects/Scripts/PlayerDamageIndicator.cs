using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerDamageIndicator : MonoBehaviour
{
    [SerializeField] private float fadingSpeed = 1.5f; //Speed at which to fade the indicator
    private Image indicator;
    private float alpha;

    private void Start()
    {
        indicator = GetComponent<Image>();

        //Activate indicator on player hit
        GlobalReferenceManager.PlayerHealthScript.OnHitEvent.AddListener(ActivateDamageIndicator);
    }
    private void FixedUpdate()
    {
        //Slowly fade damage indicator over time
        FadeIndicator();
    }

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