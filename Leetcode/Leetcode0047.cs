namespace Leetcode0047;

public class Solution
{
    IList<IList<int>> result = new List<IList<int>>();

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);
        List<int> taken = new List<int>();
        List<int> rest = nums.ToList();
        Permute(taken, rest);
        return result;
    }

    private void Permute(List<int> taken, List<int> rest)
    {
        if (rest.Count == 0)
        {
            result.Add(taken);
        }

        List<int> options = new List<int>();

        for (int i = 0; i < rest.Count; i++)
        {
            // skip identical items.
            if (i - 1 >= 0 && rest[i] == rest[i - 1])
            {
                continue;
            }

            options.Add(i);
        }

        foreach(int option in options)
        {
            List<int> newTaken = taken.ToList();
            List<int> newRest = rest.ToList();
            newTaken.Add(newRest[option]);
            newRest.RemoveAt(option);
            Permute(newTaken, newRest);
        }
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[1,1,2]", 3)]
    [DataRow(1, "[1,2,3]", 6)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        var actual = new Solution().PermuteUnique(nums);
        Helper.Print2D(actual);
        Assert.AreEqual(expected, actual.Count);
    }
}