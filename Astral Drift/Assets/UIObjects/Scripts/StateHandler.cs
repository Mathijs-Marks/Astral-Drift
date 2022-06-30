using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This script is responsible for keeping track of the current game state, and changing the game's behaviour accordingly.
/// </summary>
public class StateHandler : MonoBehaviour
{
    /// <summary>
    /// Property for easy external access
    /// </summary>
    public bool GamePaused
    {
        get { return gamePaused; }
        set { gamePaused = value; }
    }

    /// <summary>
    /// Property for easy external access
    /// </summary>
    public bool GameStarted
    {
        get { return gameStarted; }
        set { gameStarted = value; }
    }

    private bool gameStarted;
    [SerializeField] private bool pauseOnRelease;
    private bool released; // Check if the mouse/touch input is released.
    public static bool gamePaused;
    public GameObject pauseMenuUI; // Reference to the Unity UI Game object.

    void Awake()
    {
        GlobalReferenceManager.StateHandler = this; // Make a reference to the Global Reference Manager.
        Time.timeScale = 0; // Start the game 'frozen' in time.
        GameStarted = false;
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player lifts the finger to pause...
        if (pauseOnRelease) 
        {
            // Check if the game isn't finished and the game has started
            if (!GlobalReferenceManager.GameOverMenu.gameEnd && GameStarted)
            {
                // Check if the mouse button/finger is lifted and the game is not paused
                if (Input.GetMouseButtonUp(0) && !GamePaused)
                {
                    Pause();
                }
                // Check if the mouse button/finger is lifted and the game is paused
                else if (Input.GetMouseButtonDown(0) && GamePaused)
                {
                    Resume();
                }
            }
        }
        else
        {
            // If the game isn't finished...
            if (!GlobalReferenceManager.GameOverMenu.gameEnd)
            {
                // Check if the game is paused
                if (!GamePaused)
                {
                    // If the mouse button/finger is lifted
                    if (Input.GetMouseButtonUp(0))
                    {
                        // Slow the game down
                        Time.timeScale = 0.5f;
                        released = true;
                    }
                    // Otherwise, check if the mouse button/finger is pressed
                    else if (Input.GetMouseButtonDown(0))
                    {
                        // Resume normal speed
                        Time.timeScale = 1f;
                        released = false;
                    }
                }
            }
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (released)
        {
            // Keep moving the player with the same speed as the camera.
            GlobalReferenceManager.PlayerScript.targetPosition += new Vector3(0, GlobalReferenceManager.cameraScript.speed, 0);
        }
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }
}