using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0070;

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) { return 1; }
        if(n == 2) { return 2; }
        int a = 1;
        int b = 2;
        int c = 0;
        for(int i = 3; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int n, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.ClimbStairs(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2,2); }
    [TestMethod] public void Test2() { TestBase(3,3); }
    [TestMethod] public void Test3() { TestBase(1,1); }
    [TestMethod] public void Test4() { TestBase(4,5); }


}
