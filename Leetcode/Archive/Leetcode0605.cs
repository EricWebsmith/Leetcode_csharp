namespace Leetcode0605;

/// <summary>
/// Runtime: 108 ms, faster than 95.44% of C# online submissions for Can Place Flowers.
/// Memory Usage: 42.8 MB, less than 41.06% of C# online submissions for Can Place Flowers.
/// </summary>
public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if(n == 0) { return true; }
        int len = flowerbed.Length;

        for (int i = 0; i < len; i++)
        {
            if (flowerbed[i] == 0
                && (i == 0 || flowerbed[i - 1] == 0)
                && (i == len - 1 || flowerbed[i + 1] == 0))
            {
                flowerbed[i] = 1;
                n--;
                if (n == 0)
                {
                    return true;
                }
            }
        }

        return n == 0;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string flowerbedStr, int n, bool expected)
    {
        int[] flowerbed = flowerbedStr.LeetcodeToArray();
        bool actual = new Solution().CanPlaceFlowers(flowerbed, n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,0,0,0,1]", 1, true); }
    [TestMethod] public void Test2() { TestBase("[1,0,0,0,1]", 2, false); }
    [TestMethod] public void Test3() { TestBase("[0,0,1]", 1, true); }
    [TestMethod] public void Test4() { TestBase("[0]", 1, true); }
    [TestMethod] public void Test5() { TestBase("[0]", 2, false); }
    [TestMethod] public void Test6() { TestBase("[1]", 1, false); }
}