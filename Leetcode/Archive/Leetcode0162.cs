namespace Leetcode0162;

public class Solution
{
    public int FindPeakElement0(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        if (nums[0] > nums[1])
        {
            return 0;
        }

        if (nums[nums.Length - 1] > nums[nums.Length - 2])
        {
            return nums.Length - 1;
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1])
            {
                return i;
            }
        }
        return -1;
    }

    public int FindPeakElement(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] < nums[mid + 1])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 1, 2, 3, 1 }, new int[] { 2 })]
    [DataRow(2, new int[] { 1, 2, 1, 3, 5, 6, 4 }, new int[] { 1, 5 })]
    [DataRow(3, new int[] { 1 }, new int[] { 0 })]
    [DataRow(4, new int[] { 2, 1 }, new int[] { 0 })]
    [DataRow(5, new int[] { 3, 4, 3, 2, 1 }, new int[] { 1 })]
    [DataTestMethod]
    public void Test(int order, int[] nums, int[] expected)
    {
        int actual = (new Solution()).FindPeakElement(nums);
        Assert.IsTrue(expected.Contains(actual));
    }
}