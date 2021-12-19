namespace Leetcode0416;

/// <summary>
/// Runtime: 124 ms, faster than 64.44% of C# online submissions for Partition Equal Subset Sum.
/// Memory Usage: 43.3 MB, less than 39.09% of C# online submissions for Partition Equal Subset Sum.
/// </summary>
public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int n = nums.Length;
        int sum = nums.Sum();
        
        if(sum % 2 == 1)
        {
            return false;
        }

        int half = sum / 2;
        HashSet<int> sums = new HashSet<int>();
        sums.Add(0);
        sums.Add(nums[0]);
        for(int i = 1; i < n; i++)
        {
            List<int> temList = new List<int>();
            foreach(int v in sums)
            {
                int newSum = v + nums[i];
                if(newSum == half)
                {
                    return true;
                }
                temList.Add(newSum);
            }

            foreach(int v in temList)
            {
                sums.Add(v);
            }
        }

        return false;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, bool expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        bool actual = new Solution().CanPartition(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,5,11,5]", true); }
    [TestMethod] public void Test2() { TestBase("[1,2,3,5]", false); }
    [TestMethod] public void Test3() { TestBase("[1,2,5]", false); }
    [TestMethod] public void Test4() { TestBase("[14,9,8,4,3,2]", true); }
}