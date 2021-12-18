namespace Leetcode0149;

/// <summary>
/// Runtime: 84 ms, faster than 87.92% of C# online submissions for Max Points on a Line.
/// Memory Usage: 38.6 MB, less than 63.09% of C# online submissions for Max Points on a Line.
/// </summary>
public class Solution
{

    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n == 1) { return 1; }

        int ans = 0;

        for (int i = 0; i < n - 1; i++)
        {
            Dictionary<float, int> slopDict = new Dictionary<float, int>();
            float xi = (float)points[i][0];
            float yi = (float)points[i][1];
            for (int j = i + 1; j < n; j++)
            {
                float xj = (float)points[j][0];
                float yj = (float)points[j][1];

                float slope = (xi == xj) ? int.MaxValue : (yi - yj) / (xi - xj);

                if (slopDict.ContainsKey(slope))
                {
                    slopDict[slope]++;
                }
                else
                {
                    slopDict[slope] = 2;
                }
            }

            ans = Math.Max(ans, slopDict.Values.Max());
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
        int actual = new Solution().MaxPoints(points);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,1],[2,2],[3,3]]", 3); }
    [TestMethod] public void Test2() { TestBase("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]", 4); }
    [TestMethod] public void Test3() { TestBase("[[3,3],[1,4],[1,1],[2,1],[2,2]]", 3); }
    //[TestMethod] public void Test4() { TestBase(); }
}