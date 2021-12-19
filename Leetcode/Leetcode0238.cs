namespace Leetcode0238;

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] prefixes = new int[n];
        prefixes[0] = nums[0];
        for (int i = 1; i < n-1; i++)
        {
            prefixes[i] = prefixes[i-1] * nums[i];
        }

        int[] postfixes = new int[n];
        postfixes[n-1] = nums[n-1];
        for(int i = n - 2; i > 0; i--)
        {
            postfixes[i] = postfixes[i+1] * nums[i];
        }

        int[] results = new int[n];
        results[0] = postfixes[1];
        results[n-1] = prefixes[n-2];
        for(int i=1;i<n-1;i++)
        {
            results[i] = prefixes[i-1] * postfixes[i+1];
        }

        return results;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "1,2,3,4", "24,12,8,6")]
    [DataRow(2, "-1,1,0,-3,3", "0,0,9,0,0")]
    [DataRow(3, "4,3,2,1", "6,8,12,24")]
    [DataRow(4, "-3,-3,0,1,1", "0,0,9,0,0")]
    [DataRow(5, "0,0,0,0,0", "0,0,0,0,0")]
    [DataRow(6, "0,0", "0,0")]
    [DataRow(7, "-1,1", "1,-1")]
    [DataRow(8, "-100000,100000", "100000,-100000")]
    [DataTestMethod]
    public void Test(int order, string numsStr, string expectedStr)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int[] expected = Helper.Convert1D(expectedStr);
        int[] actual = (new Solution()).ProductExceptSelf(nums);
        Assert.AreEqual(expected.Length, actual.Length);
        for(int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }
}