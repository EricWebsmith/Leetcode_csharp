namespace Leetcode0209;

/// <summary>
/// Runtime: 80 ms, faster than 97.94% of C# online submissions for Minimum Size Subarray Sum.
/// Memory Usage: 39.3 MB, less than 11.93% of C# online submissions for Minimum Size Subarray Sum.
/// </summary>
public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int n = nums.Length;
        int p1 = 0;
        int p2 = 0;
        int sum = nums[0];
        int ans = int.MaxValue;
        while (p1 <= p2 && p2 < n)
        {
            if (p2 < p1)
            {
                p2++;
                sum += nums[p2];
            }

            if (sum >= target)
            {
                ans = Math.Min(ans, p2 - p1 + 1);
                sum -= nums[p1];
                p1++;
                if (p1 >= n) { break; }
            }
            else
            {
                p2++;
                if (p2 >= n) { break; }
                sum += nums[p2];
            }
        }

        if(ans == int.MaxValue)
        {
            return 0;
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, 7, "[2,3,1,2,4,3]", 2)]
    [DataRow(2, 4, "[1,4,4]", 1)]
    [DataRow(3, 11, "[1,1,1,1,1,1,1,1]", 0)]
    [DataRow(4, 1, "[1,1,1,1]", 1)]
    [DataRow(5, 7, "[2,4,3]", 2)]
    [DataRow(6, 7, "[2,4,3,2]", 2)]
    [DataRow(7, 7, "[4,3]", 2)]
    [DataTestMethod]
    public void Test(int order, int target, string numsStr, int expected)
    {
        int[] nums = numsStr.Convert1D();
        int actual = new Solution().MinSubArrayLen(target, nums);
        Assert.AreEqual(expected, actual);
    }
}