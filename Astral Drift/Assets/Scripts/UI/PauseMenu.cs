using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused
    {
        get { return gamePaused;}
        set { gamePaused = value; }
    }

    public static bool gamePaused;
    public GameObject pauseMenuUI;

    void Awake()
    {
        GlobalReferenceManager.PauseMenu = this;
        GamePaused = true;
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalReferenceManager.GameOverMenu.gameEnd)
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