namespace Leetcode2006;

/// <summary>
/// Runtime: 84 ms, faster than 95.20% of C# online submissions for Count Number of Pairs With Absolute Difference K.
/// Memory Usage: 39.5 MB, less than 10.04% of C# online submissions for Count Number of Pairs With Absolute Difference K.
/// </summary>
public class Solution
{
    public int CountKDifference(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<int, int> positions = new Dictionary<int, int>();
        for(int i=0; i<n; i++)
        {
            if (!positions.ContainsKey(nums[i]))
            {
                positions.Add(nums[i], 1);
            }
            else
            {
                positions[nums[i]]++;
            }
        }

        int ans = 0;
        for(int i=0; i < n; i++)
        {
            if (positions.ContainsKey(nums[i]+k))
            {
                ans += positions[nums[i]+k];
            }
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int k, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().CountKDifference(nums, k);
        Assert.AreEqual(expected, actual);
    } 

    [TestMethod] public void Test1() { TestBase("[1,2,2,1]", 1, 4); }
    [TestMethod] public void Test2() { TestBase("[1,3]", 3, 0); }
    [TestMethod] public void Test3() { TestBase("[3,2,1,5,4]", 2, 3); }
}