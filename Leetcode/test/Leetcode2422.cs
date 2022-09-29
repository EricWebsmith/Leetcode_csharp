namespace Leetcode2422;

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        int leftSum = nums[left];
        int rightSum = nums[right];

        int operations = 0;
        while (left < right)
        {
            if (leftSum<rightSum)
            {
                left++;
                leftSum += nums[left];
                operations++;
            } else if (rightSum < leftSum)
            {
                right--;
                rightSum += nums[right];
                operations++;
            }
            else
            {
                left++;
                leftSum += nums[left];
                right--;
                rightSum += nums[right];
            }
        }

        return operations;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().MinimumOperations(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[4,3,2,1,2,3,1]", 2); }
    [TestMethod] public void Test2() { TestBase("[1,2,3,4]", 3); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 400 ms, faster than 100.00% of C# online submissions for Merge Operations to Turn Array Into a Palindrome.
Memory Usage: 49.7 MB, less than 100.00% of C# online submissions for Merge Operations to Turn Array Into a Palindrome.
 */