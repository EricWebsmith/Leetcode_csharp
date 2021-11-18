namespace Leetcode0118;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if(numRows == 0)
        {
            return result;
        }
        List<int> previousLayer = new List<int>() { 1 };
        result.Add(previousLayer);
        for (int i = 1; i < numRows; i++)
        {
            List<int> currentLayer = new List<int>();
            currentLayer.Add(1);
            for (int j = 0; j < previousLayer.Count - 1; j++)
            {
                currentLayer.Add(previousLayer[j] + previousLayer[j+1]);
            }
            currentLayer.Add(1);
            result.Add(currentLayer);

            previousLayer = currentLayer;
        }

        return result;
    }
}