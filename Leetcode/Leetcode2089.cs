namespace Leetcode2089;

/// <summary>
/// Runtime: 120 ms, faster than 85.71% of C# online submissions for Find Target Indices After Sorting Array.
/// Memory Usage: 41.8 MB, less than 16.07% of C# online submissions for Find Target Indices After Sorting Array.
/// </summary>
public class Solution
{
    public IList<int> TargetIndices(int[] nums, int target)
    {

        int n = nums.Length;
        int minCount = 0;
        int maxCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > target)
            {
                maxCount++;
            }
            else if(nums[i] < target)
            {
                minCount++;
            }
        }

        IList<int> result = new List<int>();
        for (int i = minCount; i < n- maxCount; i++)
        {
            result.Add(i);
        }
        return result;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int target, int min, int max)
    {
        int[] nums = numsStr.LeetcodeToArray();
        IList<int> list = new Solution().TargetIndices(nums, target);
        if (max == -1)
        {
            Assert.AreEqual(0, list.Count);
        }
        else
        {
            Assert.AreEqual(min, list.Min());
            Assert.AreEqual(max, list.Max());
        }
    }

    [TestMethod] public void Test1() { TestBase("[1,2,5,2,3]", 2, 1, 2); }
    [TestMethod] public void Test2() { TestBase("[1,2,5,2,3]", 3, 3, 3); }
    [TestMethod] public void Test3() { TestBase("[1,2,5,2,3]", 5, 4, 4); }
    [TestMethod] public void Test4() { TestBase("[1,2,5,2,3]", 4, -1, -1); }
    [TestMethod] public void Test5() { TestBase("[1]", 1, 0, 0); }
    [TestMethod] public void Test6() { TestBase("[2]", 1, -1, -1); }
}