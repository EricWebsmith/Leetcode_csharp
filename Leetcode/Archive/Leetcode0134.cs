namespace Leetcode0134;

/// <summary>
/// Runtime: 227 ms, faster than 42.20% of C# online submissions for Gas Station.
/// Memory Usage: 43.1 MB, less than 99.54% of C# online submissions for Gas Station.
/// </summary>
public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;
        int[] changes = new int[n];
        for (int i = 0; i < n; i++)
        {
            changes[i] = gas[i] - cost[i];
        }

        if(changes.Sum()<0)
        {
            return -1;
        }

        int total=0;
        int start = 0;
        for(int i = 0; i < n; ++i)
        {
            total += changes[i];
            if (total < 0)
            {
                total = 0;
                start = i+1;
            }
        }

        return start;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string gasStr, string costStr, int expected)
    {
        int[] gas = gasStr.LeetcodeToArray();
        int[] cost = costStr.LeetcodeToArray();
        int actual = new Solution().CanCompleteCircuit(gas, cost);
        Assert.AreEqual(actual, expected);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,4,5]", "[3,4,5,1,2]", 3); }
    [TestMethod] public void Test2() { TestBase("[2,3,4]", "[3,4,3]", -1); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}