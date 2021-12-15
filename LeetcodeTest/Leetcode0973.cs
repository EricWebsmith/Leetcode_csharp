namespace Leetcode0973;

/// <summary>
/// Runtime: 284 ms, faster than 64.28% of C# online submissions for K Closest Points to Origin.
/// Memory Usage: 49.9 MB, less than 91.80% of C# online submissions for K Closest Points to Origin.
/// </summary>
public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        int n = points.Length;
        Dictionary<int, int> distances = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            int x = points[i][0];
            int y = points[i][1];
            distances[i] = x * x + y * y;
        }

        var query = (from distance in distances orderby distance.Value select distance)
            .Take(k).ToList();
        int[][] result = new int[k][];
        for(int i = 0; i < k; i++)
        {
            result[i] = points[query[i].Key];
        }

        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string pointsStr, int k, string expected)
    {
        int[][] points = pointsStr.LeetcodeToArray2D();
        int[][] actual = new Solution().KClosest(points, k);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[[1,3],[-2,2]]", 1, "[[-2,2]]"); }
    [TestMethod] public void Test2() { TestBase("[[3,3],[5,-1],[-2,4]]", 2, "[[3,3],[-2,4]]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}