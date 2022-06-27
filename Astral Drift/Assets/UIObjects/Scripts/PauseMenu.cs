using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused
    {
        get { return gamePaused; }
        set { gamePaused = value; }
    }
    [SerializeField] private bool pauseOnRelease;
    private bool released;
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
        if (pauseOnRelease)
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
        else
        {
            if (!GlobalReferenceManager.GameOverMenu.gameEnd)
            {
                if (!GamePaused)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        Time.timeScale = 0.5f;
                        released = true;
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        Time.timeScale = 1f;
                        released = false;
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (released)
        {
            GlobalReferenceManager.PlayerScript.targetPosition += new Vector3(0, GlobalReferenceManager.background.moveSpeed, 0);
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