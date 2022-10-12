using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Typer typer;
    public TextMeshProUGUI timeText;

    public float startTime = 3;
    public float timeRemain = PrefVariables.gameTime;
    private float timePlayed = 0;
    private float wordTime = 0;

    public float TimePlayed
    {
        get
        {
            return timePlayed;
        }
    }

    public float WordTime
    {
        get
        {
            return wordTime;
        }
        set
        {
            wordTime = value;
        }
    }

    bool isStartTimeRun = false;
    public bool isPlayTimeRun = false;
    
    private void Start()
    {
        isStartTimeRun = true;
    }

    void Update()
    {
        if(PrefVariables.isGameRun)
        {
            if(isStartTimeRun)
            {
                if(startTime > 0)
                {
                    startTime -= Time.deltaTime;
                    DisplayStartTime(startTime);
                }
                else
                {
                    startTime = 0;
                    isStartTimeRun = false;
                    isPlayTimeRun = true;
                    typer.SetCurrentWord();
                }
            }

            if(isPlayTimeRun)
            {
                timePlayed += Time.deltaTime;
                wordTime += Time.deltaTime;
                if(PrefVariables.isTimerOn)
                {
                    if(timeRemain > 0)
                    {
                        timeRemain -= Time.deltaTime;
                        DisplayTime(timeRemain);
                        
                        if(timeRemain <= 5)
                            timeText.color = Color.red;
                        else if(timeRemain > 5)
                            timeText.color = Color.white;
                    }
                    else
                    {
                        timeRemain = 0;
                        isPlayTimeRun = false;
                        PrefVariables.isGameRun = false;
                        PrefVariables.gameEndReasonChoose = 0;
                    }
                }
                else
                {
                    timeText.text="";
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayStartTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay);
        timeText.text = seconds.ToString();
    }
}
