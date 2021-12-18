namespace Leetcode0201;


public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int result = left;
        for (int i = left + 1; i <= right && i > 0; i++)
        {
            result = result & i;
            if (result == 0)
            {
                return 0;
            }
        }

        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int left, int right, int expected)
    {
        int actual = new Solution().RangeBitwiseAnd(left, right);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(5, 7, 4); }
    [TestMethod] public void Test2() { TestBase(0, 0, 0); }
    [TestMethod] public void Test3() { TestBase(1, 2147483647, 0); }
    [TestMethod] public void Test4() { TestBase(2, 4, 0); }
    [TestMethod] public void Test5() { TestBase(2147483646, 2147483647, 2147483646); }
}