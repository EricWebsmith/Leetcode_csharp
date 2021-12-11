namespace Leetcode5934;

// https://leetcode.com/contest/biweekly-contest-67/problems/find-subsequence-of-length-k-with-the-largest-sum/

public class Solution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        int n = nums.Length;
        List<int> ansIndices = new List<int>();

        for (int round = 0; round < k; round++)
        {
            int currentMax = int.MinValue;
            int currentMaxIndex = -1;
            for(int i = 0; i < n; i++)
            {
                if (ansIndices.Contains(i))
                {
                    continue;
                }

                if(nums[i] > currentMax)
                {
                    currentMax = nums[i];
                    currentMaxIndex = i;
                }
            }
            ansIndices.Add(currentMaxIndex);

        }

        ansIndices.Sort();

        int[] ans = new int[ansIndices.Count];
        for (int i = 0; i < ansIndices.Count; i++)
        {
            ans[i] = nums[ansIndices[i]];
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int k, string expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int[] actual = new Solution().MaxSubsequence(nums, k);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[2,1,3,3]", 2, "[3,3]"); }
    [TestMethod] public void Test2() { TestBase("[-1,-2,3,4]", 3, "[-1,3,4]"); }
    [TestMethod] public void Test3() { TestBase("[3,4,3,3]", 2, "[3,4]"); }
}