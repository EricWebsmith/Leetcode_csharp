using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Leetcode0167;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int lo = 0;
        int hi = numbers.Length - 1;
        while (lo <= hi)
        {
            if (numbers[lo] + numbers[hi] == target)
            {
                return new int[] { lo + 1, hi + 1 };
            }
            else if (numbers[lo] + numbers[hi] > target)
            {
                hi--;
            }
            else
            {
                lo++;
            }
        }
        return new int[] { 1 };
    }
}

[TestClass]
public class Leetcode0167
{
    [TestMethod]
    public void Test1()
    {
        Solution solution = new Solution();
        var result = solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
    }

    [TestMethod]
    public void Test2()
    {
        Solution solution = new Solution();
        var result = solution.TwoSum(new int[] { 2, 3, 4 }, 6);

        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(3, result[1]);
    }

    [TestMethod]
    public void Test3()
    {
        Solution solution = new Solution();
        var result = solution.TwoSum(new int[] { -1, 0 }, -1);

        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
    }
}

