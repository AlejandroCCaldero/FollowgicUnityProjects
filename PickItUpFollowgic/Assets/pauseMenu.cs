using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{   
    public bool GameIsPaused = false;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
