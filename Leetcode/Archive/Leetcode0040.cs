namespace Leetcode0040;

/// <summary>
/// Runtime: 124 ms, faster than 84.07% of C# online submissions for Combination Sum II.
// Memory Usage: 41.6 MB, less than 38.46% of C# online submissions for Combination Sum II.
/// </summary>
public class Solution
{
    IList<IList<int>> results = new List<IList<int>>();
    List<int> current = new List<int>();
    int[] candidates;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        this.candidates = candidates;
        Recurse(-1, target);
        return results;
    }

    private void Recurse(int lastIndex, int target)
    {
        if (target == 0)
        {
            results.Add(current.ToArray());
            return;
        }

        if (target < 0)
        {
            return;
        }

        for (int i = lastIndex + 1; i < candidates.Length; i++)
        {
            if (i == lastIndex + 1 || candidates[i] != candidates[i - 1])
            {
                current.Add(candidates[i]);
                Recurse(i, target - candidates[i]);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[10,1,2,7,6,1,5]", 8, 4)]
    [DataRow(2, "[2,5,2,1,2]", 5, 2)]
    [DataRow(3, "[2]", 2, 1)]
    [DataRow(4, "[2]", 3, 0)]
    [DataTestMethod]
    public void Test(int order, string candidatesStr, int target, int expected)
    {
        int[] candicates = Helper.Convert1D(candidatesStr);
        var actual = new Solution().CombinationSum2(candicates, target);
        Helper.Print2D(actual);
        Assert.AreEqual(expected, actual.Count);
    }
}