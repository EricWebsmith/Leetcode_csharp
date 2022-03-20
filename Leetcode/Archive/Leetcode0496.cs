namespace Leetcode0496;


public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int n1= nums1.Length;
        int n2 = nums2.Length;
        int[] maxList = new int[n2];
        Dictionary<int, int> nums2Dict = new Dictionary<int, int>();
        for (int i = n2-1; i >=0 ; i--)
        {
            nums2Dict[nums2[i]] = i;
        }

        int[] dp = new int[n2];
        Array.Fill(dp, -1);
        dp[n2 - 1] = -1;
        for (int i = n2 - 2; i >= 0; i--)
        {
            if(nums2[i+1] > nums2[i])
            {
                dp[i] = i+1;
            }
            else
            {
                int next = dp[i+1];
                while(next != -1)
                {
                    if(nums2[next] > nums2[i])
                    {
                        dp[i] = next;
                        break;
                    }
                    next = dp[next];
                }
            }
        }

        dp.Print1D();

        
        int[] ans = new int[n1];
        Array.Fill(ans, -1);
        for (int i = 0; i < n1; i++)
        {
            int i2 = nums2Dict[nums1[i]];
            int position = dp[i2];
            if(position > -1)
            {
                ans[i] = nums2[dp[i2]];
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string nums1Str, string nums2Str, string expected)
    {
        int[] nums1 = nums1Str.LeetcodeToArray();
        int[] nums2 = nums2Str.LeetcodeToArray();
        string actual = new Solution().NextGreaterElement(nums1, nums2).ToLeetcode();
        Assert.AreEqual(expected, actual);  
    }

    [TestMethod] public void Test1() { TestBase("[4,1,2]", "[1,3,4,2]", "[-1,3,-1]"); }
    [TestMethod] public void Test2() { TestBase("[2,4]", "[1,2,3,4]", "[3,-1]"); }
    [TestMethod] public void Test3() { TestBase("[4,1,2]", "[1,3,4,2,5]", "[5,3,5]"); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
 Runtime: 152 ms, faster than 80.91% of C# online submissions for Next Greater Element I.
Memory Usage: 43.5 MB, less than 12.65% of C# online submissions for Next Greater Element I.
 */