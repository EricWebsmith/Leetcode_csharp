namespace Leetcode0509;

public class Solution
{
    public int Fib(int n)
    {
        if (n == 0) return 0;

        if (n <= 2)
        {
            return 1;
        }
        int a = 1;
        int b = 1;
        int c = 0;

        for (int i = 2; i < n; i++)
        {
            c = a + b;
            
            a = b;
            b = c;
        }
        return c;
    }
}

[TestClass]
public class Leetcode0509
{
    private void TestBase(int n, int expected)
    {
        Solution solution = new Solution();
        var actual = solution.Fib(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, 1); }
    [TestMethod] public void Test2() { TestBase(3, 2); }
    [TestMethod] public void Test3() { TestBase(4, 3); }
}

