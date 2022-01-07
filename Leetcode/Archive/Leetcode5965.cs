namespace Leetcode5965;


public class Solution
{
    public long[] GetDistances(int[] arr)
    {
        int n = arr.Length;
        Dictionary<int, List<int>> positionMap = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            if (!positionMap.ContainsKey(arr[i]))
            {
                positionMap[arr[i]] = new List<int>();
            }

            positionMap[arr[i]].Add(i);
        }

        long[] ans = new long[n];
        foreach(List<int> list in positionMap.Values)
        {
            long[] preSums = new long[list.Count + 1];
            for(int i = 0; i < list.Count; i++)
            {
                preSums[i + 1] = preSums[i] + list[i];
            }

            for(int i = 0; i < list.Count; i++)
            {
                long v = list[i];
                // pre
                ans[v] = v * (i+1) - preSums[i+1];
                // post
                ans[v] += preSums[list.Count] - preSums[i] - v * (list.Count - i);
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string arrStr, string expected)
    {
        int[] arr = arrStr.LeetcodeToArray();
        long[] actual = new Solution().GetDistances(arr);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[2,1,3,1,2,3,3]", "[4,2,7,2,4,4,5]"); }
    [TestMethod] public void Test2() { TestBase("[10,5,10,10]", "[5,0,3,4]"); }
    [TestMethod] public void Test3() { TestBase("[1,2,3,4]", "[0,0,0,0]"); }
    [TestMethod] public void Test4() { TestBase("[1]","[0]"); }
}