namespace Leetcode1094;


public class Solution {
    public bool CarPooling(int[][] trips, int capacity) 
    {
        int [] dp = new int[1001];
        foreach(int[] trip in trips)
        {
            for(int i = trip[1]; i < trip[2]; i++)
            {
                dp[i] += trip[0];
                if(dp[i] > capacity) return false;
            }
        }
        return true;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string tripsStr, int capacity, bool expected)
    {
        int[][] trips = tripsStr.LeetcodeToArray2D();
        bool actual = new Solution().CarPooling(trips, capacity);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[2,1,5],[3,3,7]]", 4, false); }
    [TestMethod] public void Test2() { TestBase("[[2,1,5],[3,3,7]]", 5, true); }
    [TestMethod] public void Test3() { TestBase("[[2,1,5],[3,3,7]]", 6, true); }
    [TestMethod] public void Test4() { TestBase("[[2,1,5],[3,3,7]]", 2, false); }
    [TestMethod] public void Test5() { TestBase("[[2,1,5],[3,5,7]]", 3, true); }

}