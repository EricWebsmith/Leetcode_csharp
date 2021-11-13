using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0053;

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int maxSub = nums[0];
        int curSum = 0;

        for(int i=0; i<nums.Length; i++)
        {
            if (curSum < 0)
            {
                curSum = 0;
            }
            curSum+=nums[i];
            if(curSum > maxSub)
            {
                maxSub = curSum;
            }
        }
        return maxSub;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxSubArray(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1}, 1); }
    [TestMethod] public void Test3() { TestBase(new int[] { 5, 4, -1, 7, 8 }, 23); }
//    [TestMethod] public void Test4() { TestBase(new int[] { -1, 0, 1, 1, 55 }, 3, 2); }

}

// Runtime: 76 ms, faster than 99.22% of C# online submissions for 3Sum Closest.
// Memory Usage: 41.6 MB, less than 5.18% of C# online submissions for 3Sum Closest.