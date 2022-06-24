using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UI : MonoBehaviour
{
    static public UI instance;

    public int maxUpgrade;
    [HideInInspector] public int currentUpgrade;

    [HideInInspector] public int scoreValue;

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
        shootingRate.text = "Fire Rate: 0/" + maxUpgrade;
    }

    public void AddScore(int score)
    {
        scoreValue += score;
        this.score.text = scoreValue.ToString();
    }

    public void ShootingSpeedUpgrade()
    {
        currentUpgrade++;

        shootingRate.text = "Fire Rate: " + currentUpgrade + "/" + maxUpgrade;
    }
}
