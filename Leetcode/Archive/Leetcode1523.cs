namespace Leetcode1523;


public class Solution
{
    public int CountOdds(int low, int high)
    {
        return ((low & 1) + (high & 1) == 0) ? (high - low) / 2 : ((high - low)/2 + 1);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int low, int high, int expected)
    {
        int actual = new Solution().CountOdds(low, high);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(3, 7, 3); }
    [TestMethod] public void Test2() { TestBase(8, 10, 1); }
    [TestMethod] public void Test3() { TestBase(0, 1000000000, 500000000); }
    [TestMethod] public void Test4() { TestBase(8, 8, 0); }
    [TestMethod] public void Test5() { TestBase(0, 0, 0); }
    [TestMethod] public void Test6() { TestBase(1000000000, 1000000000, 0); }

}

/*
Runtime: 24 ms, faster than 85.69% of C# online submissions for Count Odd Numbers in an Interval Range.
Memory Usage: 26.9 MB, less than 5.02% of C# online submissions for Count Odd Numbers in an Interval Range.
*/