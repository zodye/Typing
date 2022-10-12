using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordListReader
{
    public static string[] ReadWordFile(TextAsset wordFiles)
    {
        string[] dataLines = wordFiles.text.Split('\n');
        
        for(int i = 0; i < dataLines.Length; i++)
        {
            dataLines[i] = dataLines[i].Replace("\r","").Replace("\n","");
        }
        
        return dataLines;
    }
}
