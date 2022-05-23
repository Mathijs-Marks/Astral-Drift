using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public UnityEvent DeathEvent
    {
        get { return deathEvent; }
        set { deathEvent = value; }
    }

    public static GameOverHandler instance;
    private UnityEvent deathEvent;

    [HideInInspector] public bool gameLost;
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        GlobalReferenceManager.GameOverMenu = this;
        deathEvent = new UnityEvent();
    }

    private void Start()
    {
        deathEvent.AddListener(GameOver);

        instance = this;

        // Disable the game over screen
        gameOverScreen.SetActive(false);
        gameLost = false;
    }

    // Enable the game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameLost = true;

        Time.timeScale = 0;
        GlobalReferenceManager.PauseMenu.GamePaused = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
