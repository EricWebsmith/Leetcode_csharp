namespace Leetcode1029;


public class Solution
{
    public int TwoCitySchedCost(int[][] costs)
    {
        int n = costs.Length / 2;
        int[][] sortedCostts = costs.OrderBy(c=>c[0]-c[1]).ToArray();
        int ans = 0;
        for(int i = 0; i < n; i++)
        {
            ans+=sortedCostts[i][0];
        }

        for (int i = n; i < 2* n; i++)
        {
            ans += sortedCostts[i][1];
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string costsStr, int expected)
    {
        int[][] costs = costsStr.LeetcodeToArray2D();
        int actual = new Solution().TwoCitySchedCost(costs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[10,20],[30,200],[400,50],[30,20]]", 110); }
    [TestMethod] public void Test2() { TestBase("[[259,770],[448,54],[926,667],[184,139],[840,118],[577,469]]", 1859); }
    [TestMethod] public void Test3() { TestBase("[[515,563],[451,713],[537,709],[343,819],[855,779],[457,60],[650,359],[631,42]]", 3086); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
Runtime: 104 ms, faster than 70.31% of C# online submissions for Two City Scheduling.
Memory Usage: 38.1 MB, less than 25.00% of C# online submissions for Two City Scheduling. 
 */