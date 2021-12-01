namespace Leetcode0334;

/// <summary>
/// Runtime: 172 ms, faster than 96.83% of C# online submissions for Increasing Triplet Subsequence.
/// Memory Usage: 54.8 MB, less than 5.16% of C# online submissions for Increasing Triplet Subsequence.
/// </summary>
public class Solution
{
    public bool IncreasingTriplet(int[] nums)
    {
        int n = nums.Length;
        int[] minArr = new int[n];
        minArr[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            minArr[i] = Math.Min(minArr[i - 1], nums[i]);
        }

        //minArr.Print1D();

        int[] maxArr = new int[n];
        maxArr[n-1] = nums[n-1];
        for(int i = n-2;i >= 0; i--)
        {
            maxArr[i] = Math.Max(maxArr[i + 1], nums[i]);
        }

        //maxArr.Print1D();

        for(int i = 1; i < n - 1; i++)
        {
            if(nums[i] > minArr[i-1] && nums[i] < maxArr[i + 1])
            {
                return true;
            }
        }

        return false;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,4,5]", true)]
    [DataRow(2, "[5,4,3,2,1]", false)]
    [DataRow(3, "[2,1,5,0,4,6]", true)]
    [DataRow(4, "[2]", false)]
    [DataRow(5, "[2,1]", false)]
    [DataRow(6, "[1,2]", false)]
    [DataRow(7, "[1,2,3]", true)]
    [DataRow(8, "[1,2,2]", false)]
    [DataRow(9, "[2,1,5,0,4,6]", true)]
    [DataRow(10, "[2,1,5,0,4,6]", true)]
    [DataRow(11, "[2,1,5,0,4,6]", true)]
    [DataTestMethod]
    public void Test(int order, string numsStr, bool expected)
    {
        int[] nums = numsStr.Convert1D();
        bool actual = new Solution().IncreasingTriplet(nums);
        Assert.AreEqual(expected, actual);
    }
}