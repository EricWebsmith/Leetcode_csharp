namespace Leetcode0268;

/// <summary>
/// Runtime: 100 ms, faster than 83.32% of C# online submissions for Missing Number.
/// Memory Usage: 41.5 MB, less than 73.18% of C# online submissions for Missing Number.
/// </summary>
public class Solution
{
    public int MissingNumber(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        if (n == 1) { return 1 - nums[0]; }
        if (n > nums[n - 1]) { return n; }

        int lo = 0;
        int hi = n - 1;
        int mid = lo + (hi - lo) / 2;
        while (lo < hi)
        {
            if (mid == nums[mid])
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
            mid = lo + (hi - lo) / 2;
        }
        return mid ;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().MissingNumber(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,0,1]", 2); }
    [TestMethod] public void Test2() { TestBase("[0,1]", 2); }
    [TestMethod] public void Test3() { TestBase("[9,6,4,2,3,5,7,0,1]", 8); }
    [TestMethod] public void Test4() { TestBase("[0]", 1); }
    [TestMethod] public void Test5() { TestBase("[1]", 0); }
    [TestMethod] public void Test6() { TestBase("[1...100]", 0); }
    [TestMethod] public void Test7() { TestBase("[0...99]", 100); }
    [TestMethod] public void Test8() { TestBase("[0,1,2,3,4,5,7,8,9,10]", 6); }
    [TestMethod] public void Test9() { TestBase("[0,1,2,3,4,5,6,8,9,10]", 7); }
}