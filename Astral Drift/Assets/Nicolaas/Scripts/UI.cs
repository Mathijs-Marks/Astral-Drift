using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    static public UI instance; 

    [SerializeField] private Player player;
    public int scoreValue;

    public TextMeshProUGUI hitpoints;
    public TextMeshProUGUI score;
    public TextMeshProUGUI shootingRate;

    private void Start()
    {
        instance = this;
        scoreValue = 0;

        UpdateHitpoints(player.maxHitpoints);
        score.text = "Score: 0";
        shootingRate.text = "Fire Rate: 0/X";
    }

    public void UpdateHitpoints(int hitpoints)
    {
        this.hitpoints.text = "HP: " + hitpoints + "/" + player.maxHitpoints;
    }

    public void AddScore(int score)
    {
        scoreValue += score;
        this.score.text = "Score: " + scoreValue;
    }
}
