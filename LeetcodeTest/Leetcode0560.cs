namespace Leetcode0560;

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        int[] sums = new int[nums.Length];
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(0, 1);

        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sums[i] = nums[i];
            if (i > 0)
            {
                sums[i] += sums[i - 1];
            }

            int remainder = sums[i] - k;
            if (dict.ContainsKey(remainder))
            {
                count += dict[remainder];
            }

            if (dict.ContainsKey(sums[i]))
            {
                dict[sums[i]]++;
            }
            else
            {
                dict.Add(sums[i], 1);
            }
        }

        return count;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,1,1]", 2, 2)]
    [DataRow(2, "[1,2,3]", 3, 2)]
    [DataRow(3, "[3,4,7,2,-3,1,4,2]", 7, 4)]
    [DataRow(4, "[3]", 3, 1)]
    [DataRow(5, "[-3,3,7,-7,7]", 7, 5)]
    [DataRow(6, "[3]", 7, 0)]
    [DataRow(7, "[0,0]", 0, 3)]
    [DataTestMethod]
    public void Test(int order, string numsStr, int k, int expected)
    {
        int[] nums = Helper.Convert1D(numsStr);
        int actual = new Solution().SubarraySum(nums, k);
        Assert.AreEqual(expected, actual);
    }
}