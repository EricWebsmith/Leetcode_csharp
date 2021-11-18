namespace Leetcode0035;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums.Last() < target)
        {
            return nums.Length;
        }
        int mid = nums.Length / 2;
        int lo = 0;
        int hi = nums.Length - 1;
        while (lo <= hi)
        {
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target && mid + 1 <= nums.Length - 1 && target < nums[mid + 1])
            {
                return mid + 1;
            }
            else if (nums[mid] < target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }

            mid = (lo + hi) / 2;
        }

        return mid;
    }
}

[TestClass]
public class Leetcode035
{
    private void TestBase(int[] nums, int target, int expected)
    {
        Solution solution = new Solution();
        int result = solution.SearchInsert(nums, target);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test1()
    {
        TestBase(new int[] { 1, 3, 5, 6 }, 5, 2);
    }

    [TestMethod]
    public void Test2()
    {
        TestBase(new int[] { 1, 3, 5, 6 }, 2, 1);
    }

    [TestMethod]
    public void Test3()
    {
        int[] nums = { 1, 3, 5, 6 };
        Solution solution = new Solution();
        int result = solution.SearchInsert(nums, 7);
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test4()
    {
        int[] nums = { 1, 3, 5, 6 };
        Solution solution = new Solution();
        int result = solution.SearchInsert(nums, 0);
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Test5()
    {
        int[] nums = { 1 };
        Solution solution = new Solution();
        int result = solution.SearchInsert(nums, 0);
        Assert.AreEqual(0, result);
    }
}

