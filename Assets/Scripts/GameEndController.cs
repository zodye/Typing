using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEndController : MonoBehaviour //buat daftar kata yg sdh diketik
{
    [SerializeField] Typer typer = null;
    [SerializeField] Timer timer = null;
    [SerializeField] GameObject gameEndScreen = null;
    [SerializeField] Transform typedListParent = null;
    [SerializeField] TextMeshProUGUI playTimeText = null;
    [SerializeField] TextMeshProUGUI gameEndReasonText = null;
    [SerializeField] TextMeshProUGUI wordsTypedCountText = null;
    [SerializeField] TextMeshProUGUI mistakesCountText = null;
    [SerializeField] TextMeshProUGUI typedListText = null;

    PrefVariables pref = new PrefVariables();
    bool mistakesListShown = false;

    private void Update()
    {
        if(!PrefVariables.isGameRun)
        {
            gameEndScreen.SetActive(true);
            DisplayPlayTime(timer.TimePlayed);
            gameEndReasonText.text = pref.GameEndReason;
            wordsTypedCountText.text = "Jumlah Kata yang Diketik: " + typer.WordsTypedCount.ToString();
            mistakesCountText.text = "Jumlah Kata dengan Kesalahan: " + typer.MistakesCount.ToString();
            if(!mistakesListShown){
                DisplayMistakesList();
                mistakesListShown = true;
            }
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    void DisplayPlayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if(hours == 0)
            playTimeText.text = string.Format("{0}: {1:00}:{2:00}", "Lama Permainan Berjalan", minutes, seconds);
        else
            playTimeText.text = string.Format("{0}: {1:00}:{2:00}:{3:00}", "Lama Permainan Berjalan", hours, minutes, seconds);
    }

    void DisplayMistakesList()
    {
        string typedString = string.Empty, mistakesIndex = string.Empty, typedStringDisplay = string.Empty;
        for(int i = 0; i < typer.TypedWords.Count; i++){
            typedString = typer.TypedWords[i];
            mistakesIndex = typer.RecordedMistakesIndex[i];
            
            if(mistakesIndex != string.Empty){
                typedStringDisplay = typedString.Substring(0, int.Parse(mistakesIndex[0].ToString())) + "<color=#ff0000ff>"+typedString[int.Parse(mistakesIndex[0].ToString())]+"</color>";
                if(mistakesIndex.Length > 1){
                    for(int j = 1; j < mistakesIndex.Length; j++){
                        typedStringDisplay += typedString.Substring(int.Parse(mistakesIndex[j-1].ToString())+1, (int.Parse(mistakesIndex[j].ToString())-int.Parse(mistakesIndex[j-1].ToString()))-1) + "<color=#ff0000ff>"+typedString[int.Parse(mistakesIndex[j].ToString())]+"</color>";
                    }
                }
                typedStringDisplay += typedString.Substring(int.Parse(mistakesIndex[mistakesIndex.Length-1].ToString())+1);
            }
            else{
                typedStringDisplay = typedString;
            }

            typedListText.text = typedStringDisplay;
            Instantiate(typedListText, new Vector3(transform.position.x, 0, 0), Quaternion.identity, typedListParent);
        }
    }

    public void SeeWrongText()
    {
        int childNumber = 0;
        foreach(Transform child in typedListParent){
            if(typer.RecordedMistakesIndex[childNumber] == string.Empty){
                // print(child.GetComponent<TextMeshProUGUI>().text);
                child.gameObject.SetActive(false);
            }
            else if(typer.RecordedMistakesIndex[childNumber] != string.Empty){
                child.gameObject.SetActive(true);
            }
            childNumber++;
        }
    }

    public void SeeCorrectText()
    {
        int childNumber = 0;
        foreach(Transform child in typedListParent){
            if(typer.RecordedMistakesIndex[childNumber] != string.Empty){
                child.gameObject.SetActive(false);
            }
            else if(typer.RecordedMistakesIndex[childNumber] == string.Empty){
                child.gameObject.SetActive(true);
            }
            childNumber++;
        }
    }

    public void SeeAllText()
    {
        foreach(Transform child in typedListParent){
            child.gameObject.SetActive(true);
        }
    }

    [SerializeField] GameObject detailBubble = null;
    public void OnMouseHoverDetail()
    {
        detailBubble.SetActive(true);
    }
    public void OnMouseNotHoverDetail()
    {
        detailBubble.SetActive(false);
    }
}
