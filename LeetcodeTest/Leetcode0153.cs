namespace Leetcode0153;

public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums[0] < nums[nums.Length - 1])
        {
            return nums[0];
        }

        int lo = 0;
        int hi = nums.Length - 1;
        int mid = (lo + hi) / 2;
        while (lo <= hi)
        {
            if (nums[mid] > nums[mid + 1])
            {
                return nums[mid + 1];
            }
            if (nums[mid] < nums[nums.Length - 1])
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }

            mid = (lo + hi) / 2;
        }

        return nums[mid];
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 3, 4, 5, 1, 2 }, 1)]
    [DataRow(2, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
    [DataRow(3, new int[] { 11, 13, 15, 17 }, 11)]
    [DataRow(4, new int[] { 11 }, 11)]
    [DataRow(5, new int[] { -5, -4, -3, -100, -50 }, -100)]
    [DataRow(6, new int[] { 0 }, 0)]
    [DataRow(7, new int[] { 3, 1, 2 }, 1)]
    [DataTestMethod]
    public void Test(int order, int[] nums, int expected)
    {
        int actual = (new Solution()).FindMin(nums);
        Assert.AreEqual(expected, actual);
    }
}