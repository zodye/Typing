using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    const int NUMBER_OF_RANDOM_WORDS_PICKED = 250;
    [SerializeField] private Typer typer = null;

    private List<string> workingWords = new List<string>();

    private List<string> pickingWords = new List<string>();
    private List<string> printingWords = new List<string>();
    
    private List<string> usedWords = new List<string>();

    public TextAsset wordListFile;

    private void Awake()
    {
        workingWords.AddRange(WordListReader.ReadWordFile(wordListFile));

        usedWords.Add(MakeRandomString());
    }

    public void WordOutputUpdate()
    {
        if(usedWords.Count > 2500){
            string usedWordsLast = usedWords.Last();
            usedWords.Clear();
            usedWords.Add(usedWordsLast);
        }
        
        string mistakesWord = typer.Mistakes.ToLower();
        // float timeNow = Time.realtimeSinceStartup;
        if(WillPrintAlpha())
        {
            float meanWordTime = 0; int indexOfMaxWordTime = 0;

            if(typer.WordTimeList.Count == 1){
                meanWordTime = typer.WordTimeList.Last();
            }
            else if(typer.WordTimeList.Count > 1){
                float maxWordTime = 0;

                for(int i = 0; i < typer.WordTimeList.Count; i++){
                    meanWordTime += typer.WordTimeList[i];
                    
                    if(maxWordTime < typer.WordTimeList[i]){
                        maxWordTime = typer.WordTimeList[i];
                        indexOfMaxWordTime = i;
                    }
                }
                meanWordTime = meanWordTime / typer.WordTimeList.Count;
            }
            typer.WordTimeList.Clear();

            typer.WillSaveMistakes = true;
            
            if(mistakesWord == string.Empty && typer.ConsecutiveSuccessCount < 7 && meanWordTime <= 3)
            {
                pickingWords = PickRandomWords(workingWords);
                printingWords.Add(LevenCosine.FindOptimalBestWord(pickingWords, usedWords[(usedWords.Count-1)-indexOfMaxWordTime]));
                usedWords.Add(printingWords.Last());
            }
            else if(mistakesWord == string.Empty && typer.ConsecutiveSuccessCount >= 7 && meanWordTime <= 3)
            {
                pickingWords = PickRandomWords(workingWords);
                printingWords.Add(LevenCosine.FindOptimalWorstWord(pickingWords, usedWords[(usedWords.Count-1)-indexOfMaxWordTime]));
                usedWords.Add(printingWords.Last());
                typer.ConsecutiveSuccessCount = 0;
            }
            else if(mistakesWord == string.Empty && meanWordTime > 3)
            {
                pickingWords = PickRandomWords(workingWords);
                printingWords.Add(LevenCosine.FindOptimalBadTimeWord(pickingWords, usedWords[(usedWords.Count-1)-indexOfMaxWordTime]));
                usedWords.Add(printingWords.Last());
                typer.ConsecutiveSuccessCount = 0;
            }
            else if(mistakesWord != string.Empty)
            {
                for(int i = 0; i < mistakesWord.Length; i++)
                {
                    pickingWords = PickRandomWords(workingWords);
                    printingWords.Add(LevenCosine.FindOptimalMistakesWord(pickingWords, usedWords[(usedWords.Count-1)-indexOfMaxWordTime], mistakesWord[i].ToString()));
                    usedWords.Add(printingWords.Last());
                }
                typer.ConsecutiveSuccessCount = 0;
                typer.Mistakes = string.Empty;
            }
        }
        else
        {
            typer.WillSaveMistakes = false;
            printingWords = RandomNonAlphaList();
        }
        // Debug.Log("Waktu: "+((Time.realtimeSinceStartup - timeNow)*1000)+" ms");
        // Shuffle(printingWords);
        ConvertToUpper(printingWords);
    }

    private List<string> PickRandomWords(List<string> list)
    {
        int random;
        List<int> randomNumbers = new List<int>();
        List<string> randomWords = new List<string>();

        for(int i = 0; i < NUMBER_OF_RANDOM_WORDS_PICKED; i++)
        {
            random = Random.Range(0, list.Count);

            while(randomNumbers.Contains(random) || list[random].Length > 10 || list[random].Length < 4 || usedWords.Contains(list[random])) //no same number
            {
                random = Random.Range(0, list.Count);
            }

            randomNumbers.Add(random);
            randomWords.Add(list[random]);
        }

        return randomWords;
    }

    private void Shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToUpper(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
            list[i] = list[i].ToUpper();
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(printingWords.Count != 0)
        {
            newWord = printingWords.Last();
            // usedWords.Add(newWord.ToLower()); //new addition
            printingWords.Remove(newWord);
        }

        return newWord;
    }
    
    private string MakeRandomString()
    {
        string randomString = string.Empty;

        for(int i = 0; i < Random.Range(1, 27); i++)
        {
            randomString = randomString + (char)Random.Range('a', 'z');
        }

        return randomString;
    }

    private bool WillPrintAlpha()
    {
        int random = Random.Range(0, 200);

        if(random == 42 || random == 100 || random == 69)
            return false;
        else
            return true;
    }

    private List<string> RandomNonAlphaList()
    {
        string nonAlphaContainer = "1234567890`-=[];\"',./\\~!@#$%^&*()_+|{}:<>? ";
        char randomNonAlphaChar;
        string randomNonAlphaString = string.Empty;
        List<string> randomNonAlphaList = new List<string>();
        
        for(int i = 0; i < Random.Range(2, 4); i++)
        {
            randomNonAlphaChar = nonAlphaContainer[Random.Range(0, nonAlphaContainer.Length)];

            while(randomNonAlphaString.Contains(randomNonAlphaChar)){
                randomNonAlphaChar = nonAlphaContainer[Random.Range(0, nonAlphaContainer.Length)];
            }
            
            randomNonAlphaString += randomNonAlphaChar;
        }

        for(int i = 0; i < randomNonAlphaString.Length; i++){
            randomNonAlphaList.Add(randomNonAlphaString[i].ToString());
        }

        return randomNonAlphaList;
    }
}
