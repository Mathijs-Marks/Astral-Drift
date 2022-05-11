using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public static GameOverHandler instance;

    [HideInInspector] public bool gameLost;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
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
        PauseMenu.GamePaused = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
