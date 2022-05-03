using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject pauseMenuUI;

    void Awake()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
        Debug.Log("Game is resumed!" + GamePaused);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
        Debug.Log("Game is paused!" + GamePaused);
    }
}