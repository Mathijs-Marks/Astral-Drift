using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UnityEventGameObject : UnityEvent<GameObject>
{

}

public class GameOverHandler : MonoBehaviour
{
    public UnityEventGameObject ScreenEvent
    {
        get { return screenEvent; }
        set { screenEvent = value; }
    }

    public static GameOverHandler instance;
    private UnityEventGameObject screenEvent;

    [HideInInspector] public bool gameEnd;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    private void Awake()
    {
        GlobalReferenceManager.GameOverMenu = this;
        screenEvent = new UnityEventGameObject();
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

        Time.timeScale = 0;
        GlobalReferenceManager.PauseMenu.GamePaused = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
