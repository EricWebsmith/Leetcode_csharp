namespace Leetcode0300;

/// <summary>
/// This solution is O(n^2)
/// But there is another solution of O(nlogn)
/// neetcode said we will not be asked to achieve O(nlogn)
/// I will trust him.
/// </summary>
public class Solution_n2
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;

        int[] dp = new int[n];
        dp[n - 1] = 1;
        int result = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            int maxRest = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] > nums[i])
                {
                    maxRest = Math.Max(maxRest, dp[j]);
                }
            }
            dp[i] = maxRest + 1;
            result = Math.Max(result, dp[i]);
        }

        return result;
    }
}

/// <summary>
/// Runtime: 80 ms, faster than 98.79% of C# online submissions for Longest Increasing Subsequence.
/// Memory Usage: 38.5 MB, less than 88.53% of C# online submissions for Longest Increasing Subsequence.
/// </summary>
public class Solution
{
    private void BinarySearchLeft(List<int> lis, int num)
    {
        int lo = 0;
        int hi = lis.Count - 1;
        int mid = (lo + hi) / 2;
        while (lo < hi)
        {
            
            if (lis[mid] == num)
            {
                return;
            }
            else if (lis[mid] < num)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
            mid = (lo + hi) / 2;
        }

        lis[mid] = num;
    }

    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        List<int> lis = new List<int>();
        lis.Add(nums[0]);
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > lis.Last())
            {
                lis.Add(nums[i]);
            }
            else
            {
                BinarySearchLeft(lis, nums[i]);
            }
        }

        return lis.Count;
    }
}


[TestClass]
public class SolutionTest
{

    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = (new Solution()).LengthOfLIS(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("10,9,2,5,3,7,101,18", 4); }
    [TestMethod] public void Test2() { TestBase("0,1,0,3,2,3", 4); }
    [TestMethod] public void Test3() { TestBase("7,7,7,7,7,7,7", 1); }
    [TestMethod] public void Test4() { TestBase("7", 1); }
    [TestMethod] public void Test5() { TestBase("1,2,3,4,1,2,5,4,5,3,3,5,6,3,1,2,3,1,2,3,4,5,1,3", 6); }
    [TestMethod] public void Test_Performance() { TestBase("[10000,1]", 1); }
    [TestMethod] public void Test_Performance2() { TestBase("[1...100000]", 100000); }
}