using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevenCosine
{
    private static void CreateTxt(List<string> list, List<double> cosineList, List<int> dameLevenList)
    {
        string path = Application.dataPath + "/UI/HasilString.txt";
        if(!File.Exists(path)){
            File.WriteAllText(path, "Hasil pencarian:\n");
        }

        for(int i = 0; i < list.Count; i++){
            File.AppendAllText(path, list[i]+"\n");
        }
        for(int i = 0; i < cosineList.Count; i++){
            File.AppendAllText(path, cosineList[i]+"\n");
        }
        for(int i = 0; i < dameLevenList.Count; i++){
            File.AppendAllText(path, dameLevenList[i]+"\n");
        }
    }

    public static string FindOptimalBestWord(List<string> list, string previousString)
    { //distance low, cosine low
        List<int> dameLevenList = new List<int>();
        List<double> cosineList = new List<double>();

        double[] mistakesVector, comparisonVector;
        double similarityRate = 0, mostSimilarRate = 1.1;
        int distanceRate = 0, lowestDistance = 100;
        string mostOptimalWord = string.Empty;
        
        mistakesVector = CosineSimilarity.StringToVector(previousString);

        for(int i = 0; i < list.Count; i++)
        {
            distanceRate = DamerauLevenshteinDist.GetDistance(list[i], previousString);
            dameLevenList.Add(distanceRate);
            if(distanceRate < lowestDistance)
            {
                lowestDistance = distanceRate;
            }

            comparisonVector = CosineSimilarity.StringToVector(list[i]);
            cosineList.Add(CosineSimilarity.Similarity(mistakesVector, comparisonVector));
        }

        for(int i = 0; i < list.Count; i++)
        {
            // Debug.Log(list[i]+" DameLeven: "+dameLevenList[i]+", Cosine: "+cosineList[i]);
            if(dameLevenList[i] == lowestDistance)
            {
                similarityRate = cosineList[i];
                if(similarityRate < mostSimilarRate)
                {
                    mostSimilarRate = similarityRate;
                    mostOptimalWord = list[i];
                }
            }
        }
        Debug.Log("Most optimal (kondisi 1): "+mostOptimalWord);
        // CreateTxt(list, cosineList, dameLevenList);
        return mostOptimalWord;
    }
    
    public static string FindOptimalWorstWord(List<string> list, string previousString)
    { //distance high cosine low
        List<int> dameLevenList = new List<int>();
        List<double> cosineList = new List<double>();

        double[] mistakesVector, comparisonVector;
        double similarityRate = 0, mostSimilarRate = 1.1;
        int distanceRate = 0, highestDistance = 0;
        string worstOptimalWord = string.Empty;
        
        mistakesVector = CosineSimilarity.StringToVector(previousString);

        for(int i = 0; i < list.Count; i++)
        {
            distanceRate = DamerauLevenshteinDist.GetDistance(list[i], previousString);
            dameLevenList.Add(distanceRate);
            if(distanceRate > highestDistance)
            {
                highestDistance = distanceRate;
            }

            comparisonVector = CosineSimilarity.StringToVector(list[i]);
            cosineList.Add(CosineSimilarity.Similarity(mistakesVector, comparisonVector));
        }

        for(int i = 0; i < list.Count; i++)
        {
            // Debug.Log(list[i]+" DameLeven: "+dameLevenList[i]+", Cosine: "+cosineList[i]);
            if(dameLevenList[i] == highestDistance)
            {
                similarityRate = cosineList[i];
                if(similarityRate < mostSimilarRate)
                {
                    mostSimilarRate = similarityRate;
                    worstOptimalWord = list[i];
                }
            }
        }
        Debug.Log("Worst (kondisi 2): "+worstOptimalWord);
        return worstOptimalWord;
    }

    public static string FindOptimalBadTimeWord(List<string> list, string previousString)
    { //distance low cosine high
        List<int> dameLevenList = new List<int>();
        List<double> cosineList = new List<double>();

        double[] mistakesVector, comparisonVector;
        double similarityRate = 0, mostSimilarRate = 0;
        int distanceRate = 0, lowestDistance = 100;
        string mostOptimalWord = string.Empty;
        
        mistakesVector = CosineSimilarity.StringToVector(previousString);

        for(int i = 0; i < list.Count; i++)
        {
            distanceRate = DamerauLevenshteinDist.GetDistance(list[i], previousString);
            dameLevenList.Add(distanceRate);
            if(distanceRate < lowestDistance)
            {
                lowestDistance = distanceRate;
            }

            comparisonVector = CosineSimilarity.StringToVector(list[i]);
            cosineList.Add(CosineSimilarity.Similarity(mistakesVector, comparisonVector));
        }

        for(int i = 0; i < list.Count; i++)
        {
            // Debug.Log(list[i]+" DameLeven: "+dameLevenList[i]+", Cosine: "+cosineList[i]);
            if(dameLevenList[i] == lowestDistance)
            {
                similarityRate = cosineList[i];
                if(similarityRate > mostSimilarRate)
                {
                    mostSimilarRate = similarityRate;
                    mostOptimalWord = list[i];
                }
            }
        }
        Debug.Log("Most optimal (kondisi 3): "+mostOptimalWord);
        return mostOptimalWord;
    }

    public static string FindOptimalMistakesWord(List<string> list, string previousString, string mistakesLetter)
    { //cosine high distance low (optimal mistakes word)
        List<int> dameLevenList = new List<int>();
        List<double> cosineList = new List<double>();
        List<(int, double, int)> dameCosineList = new List<(int, double, int)>();

        double[] mistakesVector, comparisonVector;
        double similarityRate = 0;
        int distanceRate = 0, lowestDistance = 100;
        string mostOptimalWord = string.Empty;
        
        mistakesVector = CosineSimilarity.StringToVector(mistakesLetter);

        for(int i = 0; i < list.Count; i++)
        {
            comparisonVector = CosineSimilarity.StringToVector(list[i]);
            similarityRate = CosineSimilarity.Similarity(mistakesVector, comparisonVector);
            cosineList.Add(similarityRate);
            // if(similarityRate > mostSimilarRate)
            // {
            //     mostSimilarRate = similarityRate;
            // }
            
            distanceRate = DamerauLevenshteinDist.GetDistance(list[i], previousString);
            dameLevenList.Add(distanceRate);

            dameCosineList.Add((i, similarityRate, distanceRate));
        }

        // CreateTxt(list, cosineList, dameLevenList);
        SortTheValue.QuickSort(dameCosineList, 0, dameCosineList.Count-1);

        double comparingCosineValue = dameCosineList[0].Item2;
        int cosineCount = 1;

        for(int i = 1; i < dameCosineList.Count; i++)
        {
            if(cosineCount > 3){
                dameCosineList.RemoveRange(i - 1, dameCosineList.Count - i + 1);
                break;
            }
            else if(comparingCosineValue == dameCosineList[i].Item2){
                continue;
            }
            else if(comparingCosineValue > dameCosineList[i].Item2){
                comparingCosineValue = dameCosineList[i].Item2;
                cosineCount++;
            }
        }

        // for(int i = 0; i < dameCosineList.Count; i++){
        //     Debug.Log(list[dameCosineList[i].Item1]+" -> "+dameCosineList[i]);
        // }
        
        for(int i = 0; i < dameCosineList.Count; i++)
        {
            // Debug.Log(list[i]+" DameLeven: "+dameLevenList[i]+", Cosine: "+cosineList[i]);
            if(dameCosineList[i].Item3 < lowestDistance)
            {
                lowestDistance = dameCosineList[i].Item3;
                mostOptimalWord = list[dameCosineList[i].Item1];
            }
            // if(cosineList[i] >= (mostSimilarRate - 0.1))
            // {
            //     distanceRate = dameLevenList[i];
            //     if(distanceRate < lowestDistance)
            //     {
            //         lowestDistance = distanceRate;
            //         mostOptimalWord = list[i];
            //     }
            // }
        }
        Debug.Log("Most optimal (kondisi 4): "+mostOptimalWord);
        return mostOptimalWord;
    }
    
    public static string FindOptimalCosineWord(List<string> list, string mistakesString)
    { //cosine high
        double[] mistakesVector, comparisonVector;
        double similarityRate = 0, mostSimilarRate = 0;
        string mostSimilarWord = string.Empty;

        mistakesVector = CosineSimilarity.StringToVector(mistakesString);
        
        for(int i = 0; i < list.Count; i++)
        {
            comparisonVector = CosineSimilarity.StringToVector(list[i]);
            similarityRate = CosineSimilarity.Similarity(mistakesVector, comparisonVector);

            if(similarityRate > mostSimilarRate)
            {
                mostSimilarRate = similarityRate;
                mostSimilarWord = list[i];
            }
            // Debug.Log(list[i]+": "+similarityRate);
        }
        Debug.Log("Cosine Similar: " + mostSimilarWord + " = "+mostSimilarRate);
        
        return mostSimilarWord;
    }

    public static string FindOptimalLevenWord(List<string> list, string previousString)
    { // distance low
        int distanceRate = 0, lowestDistance = 100;
        string lowestDistanceWord = string.Empty;
        for(int i = 0; i < list.Count; i++)
        {
            distanceRate = DamerauLevenshteinDist.GetDistance(previousString, list[i]);
            if(distanceRate < lowestDistance)
            {
                lowestDistance = distanceRate;
                lowestDistanceWord = list[i];
            }
            // Debug.Log(list[i]+": "+distanceRate);
        }
        Debug.Log("Distance terkecil: "+lowestDistanceWord+" = "+lowestDistance);

        return lowestDistanceWord;
    }
}

class SortTheValue
{
    static void Swap(List<(int, double, int)> arr, int i, int j)
    {
        int tempIndex = arr[i].Item1;
        double tempCS = arr[i].Item2;
        int tempDL = arr[i].Item3;

        arr[i] = arr[j];
        arr[j] = (tempIndex, tempCS, tempDL);
    }
 
    static int Partition(List<(int, double, int)> arr, int low, int high)
    {
        double pivot = arr[high].Item2;
 
        int i = (low - 1);
 
        for (int j = low; j <= high - 1; j++) {
 
            if (arr[j].Item2 > pivot) {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return (i + 1);
    }
 
    public static void QuickSort(List<(int, double, int)> arr, int low, int high)
    {
        if (low < high) {
 
            int pi = Partition(arr, low, high);
 
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }
}