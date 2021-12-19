namespace Leetcode0377;

public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int it = 1; it <= target; it++)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                int remainder = it - nums[i];
                if (remainder >= 0)
                {
                    dp[it] += dp[remainder];
                }
            }

        }

        return dp[target];
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[1,2,3]", 4, 7)]
    [DataRow(2, "[9]", 3, 0)]
    [DataRow(3, "[1000]", 1000, 1)]
    [DataRow(4, "[100]", 1000, 1)]
    [DataRow(5, "[1]", 1, 1)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int target, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int actual = (new Solution()).CombinationSum4(nums, target);
        Assert.AreEqual(expected, actual);
    }
}