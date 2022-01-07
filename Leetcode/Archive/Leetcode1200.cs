namespace Leetcode1200;

/// <summary>
/// Runtime: 176 ms, faster than 100.00% of C# online submissions for Minimum Absolute Difference.
/// Memory Usage: 50.1 MB, less than 38.67% of C# online submissions for Minimum Absolute Difference.
/// </summary>
public class Solution
{

    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        int n=arr.Length;
        Array.Sort(arr);
        int minDistance = int.MaxValue;
        List<int> starts = new List<int>();
        for (int i = 1; i<n; i++)
        {
            int distance = Math.Abs(arr[i] - arr[i - 1]);
            if(distance == minDistance)
            {
                starts.Add(i);
            }
            else if(distance < minDistance)
            {
                minDistance = distance;
                starts.Clear();
                starts.Add(i);
            }    
        }

        IList<IList<int>> result =  new List<IList<int>>();
        for (int i = 0; i < starts.Count; i++)
        {
            int first = arr[starts[i]-1];
            int second = arr[starts[i]];
            if(first > second)
            {
                int tmp = first;
                first = second;
                second = tmp;
            }
            result.Add(new int[] { first, second });
        }
        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string arrStr, string expected)
    {
        int[] arr = arrStr.LeetcodeToArray();
        string actual = new Solution().MinimumAbsDifference(arr).ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[4,2,1,3]", "[[1,2],[2,3],[3,4]]"); }
    [TestMethod] public void Test2() { TestBase("[1,3,6,10,15]", "[[1,3]]"); }
    [TestMethod] public void Test3() { TestBase("[3,8,-10,23,19,-4,-14,27]", "[[-14,-10],[19,23],[23,27]]"); }
    [TestMethod] public void Test4() { TestBase("[1,2]","[[1,2]]"); }
}