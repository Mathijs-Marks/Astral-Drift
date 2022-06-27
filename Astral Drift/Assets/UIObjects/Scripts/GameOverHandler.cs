using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
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

    // Enable the game over screen
    public void EndGame(GameObject screen)
    {
        screen.SetActive(true);
        gameEnd = true;
        UI.instance.UpdateScore(GlobalReferenceManager.UIMenu.endGameScore);
        Time.timeScale = 0;
        GlobalReferenceManager.StateHandler.GamePaused = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
