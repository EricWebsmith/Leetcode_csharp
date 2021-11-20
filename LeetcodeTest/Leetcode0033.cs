namespace Leetcode0033;

public class Solution
{
    private int FindMid(int[] nums)
    {
        int lo = 0;
        int hi = nums.Length - 1;
        int mid = 0;
        while (lo <= hi)
        {
            
            if (nums[mid] > nums[mid + 1])
            {
                return mid;
            }
            else if(nums[mid]<nums[0])
            {
                hi = mid;
            }
            else if (nums[mid] > nums[0])
            {
                lo = mid;
            }
            mid = (lo + hi) >> 1;
        }

        return mid;
    }

    private int FindTarget(int[] nums, int lo, int hi, int target)
    {
        while (lo <= hi)
        {
            int mid = (lo + hi) >> 1;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                lo = mid+1;
            }
            else if (nums[mid] > target)
            {
                hi = mid-1;
            }
        }

        return -1;
    }

    public int Search(int[] nums, int target)
    {
        if(target < nums[0] && target > nums[nums.Length - 1])
        {
            return -1;
        }

        // not rotated.
        if (nums[0] <= nums[nums.Length - 1])
        {
            return FindTarget(nums, 0, nums.Length - 1, target);
        }

        int mid = FindMid(nums);
        if(target >= nums[0])
        {
            return FindTarget(nums, 0, mid, target);
        }

        if(target <= nums[nums.Length - 1])
        {
            return FindTarget(nums, mid+1, nums.Length-1, target);
        }

        return -1;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [DataRow(2, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [DataRow(3, new int[] { 1 }, 0, -1)]
    [DataRow(4, new int[] { 0, 1, 2, 4, 5, 6, 7}, 0, 0)]
    [DataRow(5, new int[] { -7, -6, -5, -3, -1 }, 0, -1)]
    [DataRow(6, new int[] { -7, -6, -5, -3, -1 }, -5, 2)]
    [DataRow(7, new int[] { -3, -1, -7, -6, -5 }, -5, 4)]
    [DataTestMethod]
    public void Test(int order, int[] nums, int target, int expected)
    {
        int actual = (new Solution()).Search(nums, target);
        Assert.AreEqual(expected, actual);
    }


}