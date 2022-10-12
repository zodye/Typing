using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen = null;
    bool isPaused = false;

    void Update()
    {
        if(isPaused)
        {
            if(Input.GetKeyDown("escape"))
            {
                isPaused = false;
                Resume();
            }
        }
        else
        {
            if(Input.GetKeyDown("escape"))
            {
                isPaused = true;
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoHome()
    {
        pauseScreen.SetActive(false);
        PrefVariables.gameEndReasonChoose = 3;
        Time.timeScale = 1f;
        PrefVariables.isGameRun = false;
    }
}
