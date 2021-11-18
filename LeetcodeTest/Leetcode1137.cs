namespace Leetcode1137;

public class Solution
{
    public int Tribonacci(int n)
    {
        if (n == 0) return 0;

        if (n <= 2)
        {
            return 1;
        }
        int a = 0;
        int b = 1;
        int c = 1;
        int d = -1;

        for (int i = 3; i <= n; i++)
        {
            d = a + b +c;
            
            a = b;
            b = c;
            c = d;
        }
        return c;
    }
}

[TestClass]
public class TestClass
{
    private void TestBase(int n, int expected)
    {
        Solution solution = new Solution();
        var actual = solution.Tribonacci(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(4, 4); }
    [TestMethod] public void Test2() { TestBase(25, 1389537); }
    
}

