namespace Leetcode1558;


public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        int n = arr.Length;
        int[] acc = new int[arr.Length];
        acc[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            acc[i] = acc[i - 1] + arr[i];
        }

        int ans = 0;

        for (int i = -1; i < n; i++)
        {
            for (int j = i+1; j < n; j += 2)
            {
                if (i == -1)
                {
                    ans += acc[j];
                }
                else
                {
                    ans += acc[j] - acc[i];
                }
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string arrStr, int expected)
    {
        int[] arr = arrStr.LeetcodeToArray();
        int actual = new Solution().SumOddLengthSubarrays(arr);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,4,2,5,3]", 58); }
    [TestMethod] public void Test2() { TestBase("[1,2]", 3); }
    [TestMethod] public void Test3() { TestBase("[10,11,12]", 66); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4]", 25); }

}

/*
 Runtime: 103 ms, faster than 65.37% of C# online submissions for Sum of All Odd Length Subarrays.
Memory Usage: 37 MB, less than 49.27% of C# online submissions for Sum of All Odd Length Subarrays.
 */