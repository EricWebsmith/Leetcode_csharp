namespace Leetcode1009;

/// <summary>
/// Runtime: 28 ms, faster than 85.48% of C# online submissions for Complement of Base 10 Integer.
/// Memory Usage: 26.8 MB, less than 35.48% of C# online submissions for Complement of Base 10 Integer.
/// </summary>
public class Solution
{
    public int BitwiseComplement(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        int ans = 0;
        int mask = 1;
        while (n > 0)
        {
            if (n % 2 == 0)
            {
                ans |= mask;
            }
            mask <<= 1;
            n >>= 1;
        }
        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int expected)
    {
        int actual = new Solution().BitwiseComplement(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(5, 2); }
    [TestMethod] public void Test2() { TestBase(7, 0); }
    [TestMethod] public void Test3() { TestBase(10, 5); }
    [TestMethod] public void Test4() { TestBase(1, 0); }
}