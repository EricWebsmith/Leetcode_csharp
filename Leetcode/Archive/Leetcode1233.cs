namespace Leetcode1233;

/// <summary>
/// Runtime: 104 ms, faster than 65.52% of C# online submissions for Check If It Is a Straight Line.
/// Memory Usage: 40.6 MB, less than 55.17% of C# online submissions for Check If It Is a Straight Line.
/// </summary>
public class Solution
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        // y = ax + b
        int n = coordinates.Length;
        if(n == 2) { return true; }
        int x1 = coordinates[0][0];
        int y1 = coordinates[0][1];
        int x2 = coordinates[1][0];
        int y2 = coordinates[1][1];
        int deltaX = x2 - x1;
        int deltaY = y2 - y1;
        
        if(deltaX == 0)
        {
            for(int i = 2; i < n; i++)
            {
                if(coordinates[i][0] != x1)
                {
                    return false;
                }
            }
            return true;
        }

        if (deltaY == 0)
        {
            for (int i = 2; i < n; i++)
            {
                if (coordinates[i][1] != y1)
                {
                    return false;
                }
            }
            return true;
        }

        for(int i = 2; i < n; i++)
        {
            int newDeltaX = coordinates[i][0] - x1;
            int newDeltaY = coordinates[i][1] - y1;
            if(newDeltaX * deltaY != newDeltaY * deltaX)
            {
                return false;
            }
        }

        return true;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string coordinatesStr, bool expected)
    {
        int[][] coordinates = coordinatesStr.LeetcodeToArray2D();
        bool actual =  new Solution().CheckStraightLine(coordinates);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]", true); }
    [TestMethod] public void Test2() { TestBase("[[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]", false); }
    [TestMethod] public void Test3() { TestBase("[[1,1],[2,2]]", true); }
    [TestMethod] public void Test4() { TestBase("[[1,1],[2,2],[2,1]]", false); }

}