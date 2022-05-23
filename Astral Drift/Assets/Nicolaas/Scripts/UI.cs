using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UI : MonoBehaviour
{
    public UnityEvent UpdateDamage
    {
        get { return updateDamage; }
        set { updateDamage = value; }
    }

    static public UI instance;

    private UnityEvent updateDamage;

    [SerializeField] private PlayerHealth playerHealth;
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
        updateDamage = new UnityEvent();
        updateDamage.AddListener(UpdateHitpoints);

        UpdateHitpoints();
        score.text = "Score: 0";
        shootingRate.text = "Fire Rate: 0/" + maxUpgrade;
    } 

    public void UpdateHitpoints()
    {
        this.hitpoints.text = "HP: " + GlobalReferenceManager.PlayerHealthScript.CurrentHitpoints + "/" + GlobalReferenceManager.PlayerHealthScript.maxHitpoints;
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
