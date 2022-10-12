using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosineSimilarity 
{
    public static double[] StringToVector(string word)
    {
        double[] vector = new double[26];
        
        for(int i = 0; i < word.Length; i++)
            vector[word[i] - 'a']++;
        
        return vector;
    }
    
    public static double Similarity(double[] docVector1, double[] docVector2)
    {
        double dotProduct = 0.0;
        double magnitude1 = 0.0;
        double magnitude2 = 0.0;
        double cosineSimilarity = 0.0;

        for(int i = 0; i < docVector1.Length; i++)
        {
            dotProduct += docVector1[i] * docVector2[i];
            magnitude1 += System.Math.Pow(docVector1[i], 2);
            magnitude2 += System.Math.Pow(docVector2[i], 2);
        }

        magnitude1 = System.Math.Sqrt(magnitude1);
        magnitude2 = System.Math.Sqrt(magnitude2);

        if(magnitude1 != 0.0 || magnitude2 != 0.0)
        {
            cosineSimilarity = dotProduct / (magnitude1 * magnitude2);
        }
        else
        {
            return 0.0;
        }
        
        return cosineSimilarity;
    }
}
