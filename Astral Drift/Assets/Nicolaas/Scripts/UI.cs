using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//
public class UI : MonoBehaviour
{
    static public UI instance; 

    [SerializeField] private Health playerHealth;
    public int maxUpgrade;
    [HideInInspector] public int currentUpgrade;

    [HideInInspector] public int scoreValue;

    public TextMeshProUGUI hitpoints;
    public TextMeshProUGUI score;
    public TextMeshProUGUI shootingRate;

    private void Awake()
    {
        GlobalReferenceManager.UIMenu = this;
    }

    private void Start()
    {
        instance = this;
        scoreValue = 0;
        currentUpgrade = 0;

        UpdateHitpoints(playerHealth.maxHitpoints);
        score.text = "Score: 0";
        shootingRate.text = "Fire Rate: 0/" + maxUpgrade;
    }

    public void UpdateHitpoints(int hitpoints)
    {
        this.hitpoints.text = "HP: " + hitpoints + "/" + playerHealth.maxHitpoints;
    }

    public void AddScore(int score)
    {
        scoreValue += score;
        this.score.text = "Score: " + scoreValue;
    }

    public void ShootingSpeedUpgrade()
    {
        currentUpgrade++;

        shootingRate.text = "Fire Rate: " + currentUpgrade + "/" + maxUpgrade;
    }
}
