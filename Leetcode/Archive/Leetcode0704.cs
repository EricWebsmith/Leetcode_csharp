namespace Leetcode0704;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int mid = nums.Length / 2;
        int lo = 0;
        int hi = nums.Length - 1;
        while (lo <= hi)
        {
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                lo = mid + 1;
                mid = (lo + hi) / 2;
            }
            else // nums[mid) > target
            {
                hi = mid - 1;
                mid = (lo + hi) / 2;
            }
        }
        return -1;
    }
}


[TestClass]
public class Leetcode0704
{
    [TestMethod]
    public void TestMethod1()
    {
        int[] nums = { -1, 0, 3, 5, 9, 12 };
        Solution solution = new Solution();
        var result = solution.Search(nums, 9);
        Assert.AreEqual(4, result);

    }

    [TestMethod]
    public void TestMethod2()
    {
        int[] nums = { -1, 0, 3, 5, 9, 12 };
        Solution solution = new Solution();
        var result = solution.Search(nums, 2);
        Assert.AreEqual(-1, result);

    }

    [TestMethod]
    public void TestMethod3()
    {
        int[] nums = { 5 };
        Solution solution = new Solution();
        var result = solution.Search(nums, 5);
        Assert.AreEqual(0, result);

    }
}
