using System.Collections.Generic;

namespace Leetcode0119;

public class Solution
{
    public IList<int> GetRow(int numRows)
    {
        IList<int> currentLayer = new List<int>();
        if (numRows == 0)
        {
            return new List<int>() { 1 };
        }
        IList<int> previousLayer = new List<int>() { 1 };
        for (int i = 1; i < numRows + 1; i++)
        {
            currentLayer = new List<int>();
            currentLayer.Add(1);
            for (int j = 0; j < previousLayer.Count - 1; j++)
            {
                currentLayer.Add(previousLayer[j] + previousLayer[j + 1]);
            }
            currentLayer.Add(1);

            previousLayer = currentLayer;
        }

        return previousLayer;
    }
}