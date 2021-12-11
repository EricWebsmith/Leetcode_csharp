namespace Leetcode0878;


/// <summary>
/// Runtime: 28 ms, faster than 87.50% of C# online submissions for Nth Magical Number.
/// Memory Usage: 26.6 MB, less than 87.50% of C# online submissions for Nth Magical Number.
/// </summary>
public class Solution
{
    const int MOD = 1_000_000_007;

    private int gcd(int x, int y)
    {
        if (x == 0) return y;
        return gcd(y % x, x);
    }


    public int NthMagicalNumber(int n, int a, int b)
    {
        // the solution is 
        // https://leetcode.com/problems/nth-magical-number/solution/
        // Approach 1: Mathematical
        int l = a / gcd(a, b) * b;
        int m = l / a + l / b - 1;
        int q = n / m;
        int r = n % m;

        long ans = (long)q * l % MOD;
        if (r == 0)
        {
            return (int)ans;
        }

        int[] heads = new int[] { a, b };
        for (int i = 0; i < r - 1; ++i)
        {
            if (heads[0] <= heads[1])
                heads[0] += a;
            else
                heads[1] += b;
        }

        ans += Math.Min(heads[0], heads[1]);
        return (int)(ans % MOD);
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int a, int b, int expected)
    {
        int actual = new Solution().NthMagicalNumber(n, a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(1, 2, 3, 2); }
    [TestMethod] public void Test2() { TestBase(4, 2, 3, 6); }
    [TestMethod] public void Test3() { TestBase(5, 2, 4, 10); }
    [TestMethod] public void Test4() { TestBase(3, 6, 4, 8); }
    [TestMethod] public void Test5() { TestBase(1000000000, 40000, 40000, 999720007); }
}