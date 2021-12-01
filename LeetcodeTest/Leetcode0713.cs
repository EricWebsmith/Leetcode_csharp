namespace Leetcode0713;

/// <summary>
/// Runtime: 180 ms, faster than 98.64% of C# online submissions for Subarray Product Less Than K.
/// Memory Usage: 44.5 MB, less than 15.45% of C# online submissions for Subarray Product Less Than K.
/// </summary>
public class Solution
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k == 0) { return 0; }

        int n = nums.Length;
        int p2 = 0;
        int product = nums[0];

        int ans = 0;

        for (int p1 = 0; p1 < n; p1++)
        {
            if (p1 > 0)
            {
                product = product / nums[p1 - 1];
            }

            while (product < k && p2 < n - 1)
            {
                p2++;
                product *= nums[p2];
            }
            if (product < k && p2 == n - 1)
            {
                p2 = n;
            }
            ans += Math.Max((p2 - p1), 0);
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[10,5,2,6]", 100, 8)]
    [DataRow(2, "[1,2,3]", 0, 0)]
    [DataRow(3, "[1,2,3]", 3, 3)]
    [DataRow(4, "[1,2,3,4]", 4, 4)]
    [DataRow(5, "[1,2,3,4,5]", 5, 5)]
    [DataRow(6, "[1,2,3,4]", 2, 1)]
    [DataRow(7, "[1,2,3,4]", 8, 7)]
    [DataRow(8, "[1,2,3,4]", 9, 7)]
    [DataRow(9, "[1,1,1]", 1, 0)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int k, int expected)
    {
        int[] nums = numsStr.Convert1D();
        int actual = new Solution().NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, actual);
    }
}