namespace Leetcode0673;


public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        int n = nums.Length;
        int[] lisArr = new int[n];
        int[] counts = new int[n];
        Array.Fill(lisArr, 1);
        Array.Fill(counts, 1);
        int maxLis = 1;
        for(int i = n-2; i >=0 ; i--)
        {

            for(int j = i + 1; j < n; j++)
            {
                if(nums[j] > nums[i])
                {
                    int tmp = lisArr[j]+1;
                    if(tmp == lisArr[i])
                    {
                        counts[i]+=counts[j];
                    }
                    else if(tmp > lisArr[i])
                    {
                        lisArr[i] = tmp;
                        counts[i] = counts[j];
                    }
                }
            }

            maxLis = Math.Max(maxLis, lisArr[i]);
        }

        int ans = 0;
        for(int i = 0; i < n; i++)
        {
            if(lisArr[i] == maxLis)
            {
                ans+=counts[i];
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().FindNumberOfLIS(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,3,5,4,7]", 2); }
    [TestMethod] public void Test2() { TestBase("[2,2,2,2,2]", 5); }
    [TestMethod] public void Test3() { TestBase("[10,9,2,5,3,7,101,18]", 4); }
    [TestMethod] public void Test4() { TestBase("[0,1,0,3,2,3]", 1); }
    [TestMethod] public void Test5() { TestBase("[2,5,3,7,101]", 2); }
}