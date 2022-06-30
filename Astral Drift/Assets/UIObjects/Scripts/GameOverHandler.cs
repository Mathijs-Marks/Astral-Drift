using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    // Event used to show game over or victory screen. Requires UI object that needs to be enabled as parameter
    public UnityEvent<GameObject> ScreenEvent
    {
        get { return screenEvent; }
        set { screenEvent = value; }
    }

    public static GameOverHandler instance;
    private UnityEvent<GameObject> screenEvent;

    [HideInInspector] public bool gameEnd;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    private void Awake()
    {
        GlobalReferenceManager.GameOverMenu = this;
        screenEvent = new UnityEvent<GameObject>();
    }

    private void Start()
    {
        screenEvent.AddListener(EndGame);

        instance = this;

        // Disable the game over screen
        gameOverScreen.SetActive(false);
        gameEnd = false;
    }

    // Enable a UI screen with a parameter
    public void EndGame(GameObject screen)
    {
        screen.SetActive(true); // Enable screen
        gameEnd = true; // Stop game from unpauzing
        
        UI.instance.UpdateScore(GlobalReferenceManager.UIMenu.endGameScore); // Update score
        Time.timeScale = 0; // Stop the game from running in the background

        GlobalReferenceManager.StateHandler.GamePaused = true; // Game is now pauzed
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
