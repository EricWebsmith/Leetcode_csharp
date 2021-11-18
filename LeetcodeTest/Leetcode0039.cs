using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0039;


public class Solution
{
    IList<IList<int>> results = new List<IList<int>>();
    int[] candidates;
    private void CombinationSum(List<int> arr, int target)
    {
        if (target == 0)
        {
            results.Add(arr.ToList());
        }
        else if (target < 0)
        {
            return;
        }


        for (int j = 0; j < candidates.Length; j++)
        {
            if (arr.Count > 0 && candidates[j] < arr.Last())
            {
                continue;
            }

            arr.Add(candidates[j]);
            int newTarget = target - candidates[j];
            CombinationSum(arr, newTarget);
            arr.RemoveAt(arr.Count - 1);
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        this.candidates = candidates;
        CombinationSum(new List<int>(), target);
        return results;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 2, 3, 6, 7 }, 7, 2)]
    [DataRow(2, new int[] { 2, 3, 5 }, 8, 3)]
    [DataRow(3, new int[] { 2 }, 1, 0)]
    [DataRow(4, new int[] { 1 }, 1, 1)]
    [DataRow(5, new int[] { 7, 6, 3, 2 }, 7, 2)]
    [DataTestMethod]
    public void Test00(int testNo, int[] candidates, int target, int expected)
    {
        IList<IList<int>> actual = (new Solution()).CombinationSum(candidates, target);
        Assert.AreEqual(expected, actual.Count);
    }
}