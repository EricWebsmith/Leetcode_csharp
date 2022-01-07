namespace Leetcode0217;


public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if(set.Contains(nums[i]))
            {
                return true;
            }
            set.Add(nums[i]);
        }

        return false;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, bool expected)
    {
        Solution solution = new Solution();
        var actual = solution.ContainsDuplicate(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3, 1 }, true); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 2, 3, 4 }, false); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true); }
}


// Runtime: 96 ms, faster than 99.69% of C# online submissions for Contains Duplicate.
// Memory Usage: 45.8 MB, less than 18.67% of C# online submissions for Contains Duplicate.