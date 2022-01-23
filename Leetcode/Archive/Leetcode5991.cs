namespace Leetcode5991;


public class Solution
{

    public int[] RearrangeArray(int[] nums)
    {
        int n = nums.Length;
        int positive = 0;
        int negative = 0;
        int[] ans = new int[n];
        
        for(int time = 0; time < n/2; time++)
        {
            while (nums[positive] < 0)
            {
                positive++;
            }
            ans[time*2] = nums[positive];
            positive++;

            while (nums[ negative] >0)
            {
                negative++;
            }
            ans[time*2+1] = nums[negative];
            negative++;

        }

        return ans;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, string expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int[] actual = new Solution().RearrangeArray(nums);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[3,1,-2,-5,2,-4]", "[3,-2,1,-5,2,-4]"); }
    [TestMethod] public void Test2() { TestBase("[-1,1]", "[1,-1]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}