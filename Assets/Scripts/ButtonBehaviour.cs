using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonBehaviour : MonoBehaviour
{
    public Toggle timerToggle;
    public Toggle wordsTargetToggle;
    public Toggle mistakesTargetToggle;
    public Toggle keyboardToggle;
    [SerializeField] Toggle handsToggle = null;
    
    public TMP_InputField gameTimeInput;
    public TMP_InputField gameSuccessInput;
    public TMP_InputField gamePenaltyInput;
    public TMP_InputField gameWordsTargetInput;
    public TMP_InputField gameMistakeTargetInput;

    public TextMeshProUGUI detikText;

    void Start()
    {
        // gameTimeInput.GetComponent<TMP_InputField>().text = PrefVariables.gameTime.ToString();
        // timerToggle.isOn = PlayerPrefs.GetInt("isTimerOn") == 1;
        timerToggle.isOn = PrefVariables.isTimerOn;
        TimerInteractabilityCheck(timerToggle);
        timerToggle.onValueChanged.AddListener(delegate {
            TimerInteractabilityCheck(timerToggle);
        });

        wordsTargetToggle.isOn = PrefVariables.isWordsTargetToggleOn;
        WordsTargetInteractabilityCheck(wordsTargetToggle);
        wordsTargetToggle.onValueChanged.AddListener(delegate {
            WordsTargetInteractabilityCheck(wordsTargetToggle);
        });

        mistakesTargetToggle.isOn = PrefVariables.isMistakesTargetToggleOn;
        MistakesTargetInteractabilityCheck(mistakesTargetToggle);
        mistakesTargetToggle.onValueChanged.AddListener(delegate {
            MistakesTargetInteractabilityCheck(mistakesTargetToggle);
        });
        
        gameTimeInput.text = PrefVariables.gameTime.ToString();
        gameSuccessInput.text = PrefVariables.successTime.ToString();
        gamePenaltyInput.text = PrefVariables.penaltyTime.ToString();
        gameWordsTargetInput.text = PrefVariables.wordsTarget.ToString();
        gameMistakeTargetInput.text = PrefVariables.mistakesTarget.ToString();

        gameTimeInput.onDeselect.AddListener(delegate {
            TimerInputChecker(gameTimeInput);
        });
        gameSuccessInput.onDeselect.AddListener(delegate {
            SuccPenInputChecker(gameSuccessInput);
        });
        gamePenaltyInput.onDeselect.AddListener(delegate {
            SuccPenInputChecker(gamePenaltyInput);
        });
        gameWordsTargetInput.onDeselect.AddListener(delegate {
            TargetInputChecker(gameWordsTargetInput);
        });
        gameMistakeTargetInput.onDeselect.AddListener(delegate {
            TargetInputChecker(gameMistakeTargetInput);
        });

        keyboardToggle.isOn = PrefVariables.isKeyboardOn;
        handsToggle.isOn = PrefVariables.isHandsOn;
    }

    public void OnPlayBtnClick()
    {
        // PlayerPrefs.SetInt("isTimerOn", timerToggle.isOn ? 1 : 0);
        PrefVariables.isTimerOn = timerToggle.isOn;
        PrefVariables.isWordsTargetToggleOn = wordsTargetToggle.isOn;
        PrefVariables.isMistakesTargetToggleOn = mistakesTargetToggle.isOn;
        
        PrefVariables.gameTime = float.Parse(gameTimeInput.text);
        PrefVariables.successTime = float.Parse(gameSuccessInput.text);
        PrefVariables.penaltyTime = float.Parse(gamePenaltyInput.text);
        PrefVariables.wordsTarget = int.Parse(gameWordsTargetInput.text);
        PrefVariables.mistakesTarget = int.Parse(gameMistakeTargetInput.text);

        PrefVariables.isKeyboardOn = keyboardToggle.isOn;
        PrefVariables.isHandsOn = handsToggle.isOn;

        LoadPlayScene();
    }

    public void OnExitBtnClick()
    {
        QuitGame();
    }

    void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void TimerInteractabilityCheck(Toggle check)
    {
        if(check.isOn)
        {
            gameTimeInput.interactable = true;
            gameSuccessInput.interactable = true;
            gamePenaltyInput.interactable = true;
            detikText.color = Color.white;
        }
        else
        {
            gameTimeInput.interactable = false;
            gameSuccessInput.interactable = false;
            gamePenaltyInput.interactable = false;
            detikText.color = Color.gray;
        }
    }

    void WordsTargetInteractabilityCheck(Toggle check)
    {
        if(check.isOn)
        {
            gameWordsTargetInput.interactable = true;
        }
        else
        {
            gameWordsTargetInput.interactable = false;
        }
    }

    void MistakesTargetInteractabilityCheck(Toggle check)
    {
        if(check.isOn)
        {
            gameMistakeTargetInput.interactable = true;
        }
        else
        {
            gameMistakeTargetInput.interactable = false;
        }
    }

    void SuccPenInputChecker(TMP_InputField check)
    {
        if(check.text == "" || int.Parse(check.text) < 0)
        {
            check.text = "0";
        }
    }

    void TimerInputChecker(TMP_InputField check)
    {
        if(check.text == "" || int.Parse(check.text) <= 0)
        {
            check.text = "30";
        }
    }

    void TargetInputChecker(TMP_InputField check)
    {
        if(check.text == "" || int.Parse(check.text) <= 0)
        {
            check.text = "1";
        }
    }
    
    public GameObject detailBubble;
    public void OnMouseHoverDetail()
    {
        detailBubble.SetActive(true);
    }
    public void OnMouseNotHoverDetail()
    {
        detailBubble.SetActive(false);
    }
}
