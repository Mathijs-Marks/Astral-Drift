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

    [SerializeField] private FirerateUI firerateScript;
    public TextMeshProUGUI normalScore;
    public TextMeshProUGUI endGameScore;
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
        UpdateScore(normalScore);
    }
    public void UpdateScore(TextMeshProUGUI target)
    {
        target.text = scoreValue.ToString();
    }
    public void ShootingSpeedUpgrade()
    {
        currentUpgrade++;

        firerateScript.UpdateFirerateBar();
    }
}
