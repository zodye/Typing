using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typer : MonoBehaviour
{
    public Animator animator;

    public WordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;
    public Timer timer = null;
    public AudioSource audioSource;
    
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string typedString = string.Empty;
    private string mistakes = string.Empty;
    private string activeLetter = string.Empty;
    private string wrongLetter = string.Empty;
    private int wordsTypedCount = 0;
    private int consecutiveSuccessCount = 0;
    private int mistakesCount = 0;
    private bool isSpecialKeyPressed = false;
    private bool willSaveMistakes = false;

    List<int> mistakesIndex = new List<int>();
    private List<string> typedWords = new List<string>();
    private List<string> recordedMistakesIndex = new List<string>();
    private List<float> wordTimeList = new List<float>();

    public List<string> TypedWords{
        get{
            return typedWords;
        }
    }

    public List<string> RecordedMistakesIndex{
        get{
            return recordedMistakesIndex;
        }
    }

    public List<float> WordTimeList{
        get{
            return wordTimeList;
        }
        set{
            wordTimeList = value;
        }
    }
    
    public bool WillSaveMistakes{
        get{
            return willSaveMistakes;
        }
        set{
            willSaveMistakes = value;
        }
    }

    public bool IsSpecialKeyPressed{
        get{
            return isSpecialKeyPressed;
        }
        set{
            isSpecialKeyPressed = value;
        }
    }

    public string WrongLetter{
        get{
            return wrongLetter;
        }
        set{
            wrongLetter = value;
        }
    }

    public string ActiveLetter{
        get{
            return activeLetter;
        }
    }

    public int ConsecutiveSuccessCount{
        get{
            return consecutiveSuccessCount;
        }
        set{
            consecutiveSuccessCount = value;
        }
    }

    public string Mistakes{
        get{
            return mistakes;
        }
        set{
            mistakes = value;
        }
    }
    
    public int WordsTypedCount{
        get{
            return wordsTypedCount;
        }
    }
    
    public int MistakesCount{
        get{
            return mistakesCount;
        }
    }

    private void Start()
    {
        PrefVariables.isGameRun = true;
    }

    public void SetCurrentWord()
    {
        if(PrefVariables.isGameRun){
            currentWord = wordBank.GetWord();
            SetRemainingWord(currentWord);
            if(currentWord == string.Empty)
            {
                wordBank.WordOutputUpdate();
                SetCurrentWord();
            }
        }
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<color=#008000ff>"+typedString+"</color>" + remainingWord;
    }

    private void Update()
    {
        if(timer.startTime == 0 && PrefVariables.isGameRun)
        {
            if(remainingWord != string.Empty)
                activeLetter = remainingWord[0].ToString().ToLower();
                
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown){
            string keysPressed = Input.inputString.ToUpper();

            if(keysPressed.Length == 1)
                EnterLetter(keysPressed);
            else if(keysPressed.Length == 0)
                isSpecialKeyPressed = true;
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if(IsWordComplete())
            {
                if(willSaveMistakes){
                    wordsTypedCount++;
                    typedWords.Add(currentWord);

                    string recMistakesIndexString = string.Empty;
                    foreach(int misIndex in mistakesIndex){
                        recMistakesIndexString += misIndex;
                    }
                    recordedMistakesIndex.Add(recMistakesIndexString);
                }
                
                if(mistakes != string.Empty && willSaveMistakes)
                {
                    mistakesCount++;
                    consecutiveSuccessCount = 0;
                }
                else if(willSaveMistakes)
                {
                    consecutiveSuccessCount++;
                }
                
                if(wordsTypedCount == PrefVariables.wordsTarget && PrefVariables.isWordsTargetToggleOn)
                {
                    PrefVariables.gameEndReasonChoose = 1;
                    PrefVariables.isGameRun = false;
                    timer.isPlayTimeRun = false;
                    return;
                }
                else if(mistakesCount == PrefVariables.mistakesTarget && PrefVariables.isMistakesTargetToggleOn)
                {
                    PrefVariables.gameEndReasonChoose = 2;
                    PrefVariables.isGameRun = false;
                    timer.isPlayTimeRun = false;
                    return;
                }
                
                timer.timeRemain += PrefVariables.successTime;

                typedString = string.Empty;

                currentWord = string.Empty;
                mistakesIndex.Clear();
                
                if(willSaveMistakes){
                    wordTimeList.Add(timer.WordTime);
                }
                
                SetCurrentWord();
                timer.WordTime = 0;
            }
        }
        else
        {
            WrongInputEffect();
            wrongLetter = typedLetter.ToLower();

            if(willSaveMistakes){
                if(!mistakesIndex.Contains(currentWord.IndexOf(remainingWord[0], typedString.Length-1 < 0 ? 0 : typedString.Length-1)))
                {
                    mistakes = mistakes + remainingWord[0];
                    mistakesIndex.Add(currentWord.IndexOf(remainingWord[0], typedString.Length-1 < 0 ? 0 : typedString.Length-1));
                }
            }

            timer.timeRemain -= PrefVariables.penaltyTime;
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        typedString = typedString + remainingWord[0].ToString();
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void WrongInputEffect()
    {
        animator.SetTrigger("wrongInput");
        audioSource.PlayOneShot(audioSource.clip, 1);
    }
}
