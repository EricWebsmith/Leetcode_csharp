namespace Leetcode1015;

/// <summary>
/// Runtime: 20 ms, faster than 100.00% of C# online submissions for Smallest Integer Divisible by K.
/// Memory Usage: 26.9 MB, less than 66.67% of C# online submissions for Smallest Integer Divisible by K.
/// </summary>
public class Solution
{
    public int SmallestRepunitDivByK(int k)
    {
        if (k % 2 == 0 || k % 5 == 0)
        {
            return -1;
        }

        int reminder = 0;
        for(int n = 1; n <= k; n++)
        {
            reminder = (reminder * 10 + 1) % k;
            if(reminder == 0)
            {
                return n;
            }
        }

        return -1;
    }
}

[TestClass]
public class SolutionTests
{
    [TestMethod]
    public void TestAll()
    {
        for (int i = 1; i < 100000; i += 1000)
        {
            int actual = new Solution().SmallestRepunitDivByK(i);
        }
    }

    private void TestBase(int k, int expected)
    {
        int actual = new Solution().SmallestRepunitDivByK(k);
        Assert.AreEqual(expected, actual);
    }



    [TestMethod] public void Test1() { TestBase(1, 1); }
    [TestMethod] public void Test2() { TestBase(2, -1); }
    [TestMethod] public void Test3() { TestBase(3, 3); }
    [TestMethod] public void Test4() { TestBase(17, 16); }
    [TestMethod] public void Test5() { TestBase(23, 22); }
}