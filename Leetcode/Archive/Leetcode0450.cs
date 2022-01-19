namespace Leetcode0452;


/// <summary>
/// Runtime: 400 ms, faster than 98.18% of C# online submissions for Minimum Number of Arrows to Burst Balloons.
/// Memory Usage: 51.3 MB, less than 85.45% of C# online submissions for Minimum Number of Arrows to Burst Balloons.
/// </summary>
public class Solution
{
    private int Compare(int[] pointA, int[] pointB)
    {
        return pointA[1].CompareTo(pointB[1]);
    }

    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, Compare);
        int right = points[0][1];
        int ans = 1;
        for(int i = 0; i < points.Length; i++)
        {
            if(points[i][0] > right)
            {
                right = points[i][1];
                ans++;
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string pointsStr, int expected)
    {
        int[][] points = pointsStr.LeetcodeToArray2D();
        int actual = new Solution().FindMinArrowShots(points);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[10,16],[2,8],[1,6],[7,12]]", 2); }
    [TestMethod] public void Test2() { TestBase("[[1,2],[3,4],[5,6],[7,8]]", 4); }
    [TestMethod] public void Test3() { TestBase("[[1,2],[2,3],[3,4],[4,5]]", 2); }
    [TestMethod] public void Test4() { TestBase("[[1,2],[4,5],[1,5]]", 2); }

}