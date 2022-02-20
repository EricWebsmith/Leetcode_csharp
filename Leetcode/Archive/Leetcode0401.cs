namespace Leetcode0401;

class Combinator 
{
    int[] candidates;
    int limit;
    Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
    

    public Combinator(int[] candidates, int limit)
    {
        this.candidates = candidates;
        this.limit = limit;
    }

    public Dictionary<int, List<int>> GetCombinations()
    {
        Dfs(-1, 0, 0);
        return dict;
    }

    private void Dfs(int index, int hourBits, int result)
    {
        if (index == candidates.Length - 1)
        {
            if (result < limit)
            {
                if (!dict.ContainsKey(hourBits))
                {
                    dict[hourBits] = new List<int>();
                }
                dict[hourBits].Add(result);
            }
            return;
        }
        Dfs(index + 1, hourBits + 1, result + candidates[index + 1]);
        Dfs(index + 1, hourBits, result);
    }
}

/// <summary>
/// Runtime: 120 ms, faster than 82.69% of C# online submissions for Binary Watch.
/// Memory Usage: 43.9 MB, less than 5.77% of C# online submissions for Binary Watch.
/// </summary>
public class Solution
{
    List<string> ans = new List<string>();

    private void ToHourMiniteString(List<int> hours, List<int> minites)
    {
        foreach (int hour in hours)
        {
            foreach (int minite in minites)
            {
                ans.Add($"{hour}:{minite:D2}");
            }
        }
    }

    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        if (turnedOn >= 9) { return new List<string>(); }
        int[] hourLeds = new int[] { 1, 2, 4, 8 };
        int[] miniteLeds = new int[] { 1, 2, 4, 8, 16, 32 };
        Dictionary<int, List<int>> hourDict = new Combinator(hourLeds, 12).GetCombinations();
        Dictionary<int, List<int>> miniteDict = new Combinator(miniteLeds, 60).GetCombinations();

        for (int hourBits = 0; hourBits <= Math.Min(3, turnedOn); hourBits++)
        {
            int miniteBits = turnedOn - hourBits;
            if (miniteDict.ContainsKey(miniteBits))
            {
                List<int> hours = hourDict[hourBits];
                List<int> minites = miniteDict[miniteBits];
                ToHourMiniteString(hours, minites);
            }
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void TestBase()
    {
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"---------------{i}----------------");
            IList<string> actual = new Solution().ReadBinaryWatch(i);
            actual.Print1D();
        }
    }
}