using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject pauseMenuUI;

    void Awake()
    {
        GamePaused = true;
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverHandler.instance.gameLost)
        {
            if (Input.GetMouseButtonUp(0) && !GamePaused)
            {
                Pause();
            }
            else if (Input.GetMouseButtonDown(0) && GamePaused)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }
}