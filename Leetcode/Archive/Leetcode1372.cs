namespace Leetcode1372;


public class Solution
{
    int[] manager = null;
    int[] informTime = null;
    int[] dp = null;

    private int Find(int i)
    {
        if (dp[i] > -1)
        {
            return dp[i];
        }

        if(manager[i] == -1)
        {
            dp[i] = 0;
            return 0;
        }
        dp[i] = informTime [manager[i]] +  Find(manager[i]);
        return dp[i];
    }

    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
        this.manager = manager;
        this.informTime = informTime;
        dp = new int[n];
        Array.Fill(dp, -1);
        for(int i = 0; i < n; i++)
        {
            Find(i);
        }

        return dp.Max();
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int headID, string managerStr, string informTimeStr, int expected)
    {
        int[] manager = managerStr.LeetcodeToArray();
        int[] informTime = informTimeStr.LeetcodeToArray();
        int actual = new Solution().NumOfMinutes(n, headID, manager, informTime);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(6, 2 , "[2,2,-1,2,2,2]", "[0,0,1,0,0,0]", 1); }
    [TestMethod] public void Test2() { TestBase(1, 0, "[-1]", "[0]", 0); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 389 ms, faster than 82.72% of C# online submissions for Time Needed to Inform All Employees.
Memory Usage: 46.8 MB, less than 96.30% of C# online submissions for Time Needed to Inform All Employees. 
 */