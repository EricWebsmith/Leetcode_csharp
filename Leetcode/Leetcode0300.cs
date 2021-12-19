namespace Leetcode0300;

/// <summary>
/// This solution is O(n^2)
/// But there is another solution of O(nlogn)
/// neetcode said we will not be asked to achieve O(nlogn)
/// I will trust him.
/// </summary>
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;

        int[] dp = new int[n];
        dp[n - 1] = 1;
        int result = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            int maxRest = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] > nums[i])
                {
                    maxRest = Math.Max(maxRest, dp[j]);
                }
            }
            dp[i] = maxRest + 1;
            result = Math.Max(result, dp[i]);
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "10,9,2,5,3,7,101,18", 4)]
    [DataRow(2, "0,1,0,3,2,3", 4)]
    [DataRow(3, "7,7,7,7,7,7,7", 1)]
    [DataRow(4, "7", 1)]
    [DataRow(5, "1,2,3,4,1,2,5,4,5,3,3,5,6,3,1,2,3,1,2,3,4,5,1,3", 6)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int actual = (new Solution()).LengthOfLIS(nums);
        Assert.AreEqual(expected, actual);
    }
}