namespace Leetcode0258;

/// <summary>
/// Runtime: 28 ms, faster than 91.57% of C# online submissions for Add Digits.
/// Memory Usage: 26.8 MB, less than 46.39% of C# online submissions for Add Digits.
/// </summary>
public class Solution
{
    public int AddDigits(int num)
    {
        if (num < 10)
        {
            return num;
        }

        int newNum = 0;
        while(num >= 10)
        {
            newNum += num % 10;
            num /= 10;
        }
        newNum += num;

        return AddDigits(newNum);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int num, int expected)
    {
        int actual = new Solution().AddDigits(num);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(38, 2); }
    [TestMethod] public void Test2() { TestBase(0, 0); }
    [TestMethod] public void Test3() { TestBase(1, 1); }
    [TestMethod] public void Test4() { TestBase(15, 6); }
}