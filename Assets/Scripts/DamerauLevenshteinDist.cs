using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamerauLevenshteinDist
{
    public static int GetDistance (string original, string modified)
	{
		if (original == modified)
			return 0;

		int len_ori = original.Length;
		int len_mod = modified.Length;
		if (len_ori == 0 || len_mod == 0)
			return len_ori == 0 ? len_mod : len_ori;

		int[,] matrix = new int[len_ori + 1, len_mod + 1];

		for (int i = 1; i <= len_ori; i++) {
			matrix[i, 0] = i;
			for (int j = 1; j <= len_mod; j++) {
				int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
				if (i == 1)
					matrix[0, j] = j;

				int[] values = {
					matrix[i - 1, j] + 1,
					matrix[i, j - 1] + 1,
					matrix[i - 1, j - 1] + cost
				};
				matrix[i,j] = Mathf.Min(values);
				if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
					matrix[i,j] = Mathf.Min(matrix[i,j], matrix[i - 2, j - 2] + cost);
			}
		}
		
		return matrix[len_ori, len_mod];
	}
}
