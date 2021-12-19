namespace Leetcode0540;

public class Solution
{
    public int SingleNonDuplicate(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }
        if (nums[0] != nums[1])
        {
            return nums[0];
        }
        if (nums[nums.Length - 1] != nums[nums.Length - 2])
        {
            return nums[nums.Length - 1];
        }

        int lo = 0;
        int hi = nums.Length - 1;
        int mid = 0;
        while (lo <= hi)
        {
            mid = (lo + hi) / 2;
            bool even = mid % 2 == 0;
            if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
            {
                return nums[mid];
            }

            if (even && nums[mid] == nums[mid - 1])
            {
                hi = mid - 2;
            }
            else if (even && nums[mid] == nums[mid + 1])
            {
                lo = mid + 2;
            }
            else if (!even && nums[mid] == nums[mid - 1])
            {
                lo = mid + 1;
            }
            else if (!even && nums[mid] == nums[mid + 1])
            {
                hi = mid - 1;
            }
        }

        return nums[mid];
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2)]
    [DataRow(2, new int[] { 3, 3, 7, 7, 10, 11, 11 }, 10)]
    [DataRow(3, new int[] { 1, 2, 2, 3, 3, 7, 7, 11, 11 }, 1)]
    [DataRow(4, new int[] { 3 }, 3)]
    [DataRow(5, new int[] { 3, 3, 7, 7, 10, 11, 11, 12, 12 }, 10)]
    [DataRow(6, new int[] { 7, 7, 10, 11, 11 }, 10)]
    [DataTestMethod]
    public void Test(int order, int[] nums, int expected)
    {
        int actual = (new Solution()).SingleNonDuplicate(nums);
        Assert.AreEqual(expected, actual);
    }
}
