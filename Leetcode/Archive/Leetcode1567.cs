namespace Leetcode1567;

public class Solution
{

    private int GetMaxLenNoZero(int[] nums, int start, int end)
    {
        if(start == end)
        {
            return 1;
        }
        int firstNegative = -1;
        int lastNegative = -1;
        int countNegative = 0;
        for(int i = start; i <= end; i++)
        {
            if(nums[i] < 0)
            {
                countNegative++;
                if(firstNegative == -1)
                {
                    firstNegative = i;
                }
                lastNegative = i;
            }
        }

        if(countNegative % 2 == 0)
        {
            return end - start + 1;
        }

        return Math.Max(end- firstNegative, lastNegative-start);
    }

    public int GetMaxLen(int[] nums)
    {
        if (nums.Length == 1) 
        {
            if (nums[0]>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        int maxLength = 0;
        int start = 0;
        int end = nums.Length - 1;
        for(int i=1;i< nums.Length; i++)
        {
            // find end
            if (nums[i] == 0 && nums[i-1]!=0)
            {
                //maxValue = Math.Max(0, maxValue);
                end = i - 1;
                if(end>= start)
                {
                    int curMaxLen = GetMaxLenNoZero(nums, start, end);
                    maxLength = Math.Max(maxLength, curMaxLen);
                }
                
                start = i + 1;
            }

            if(nums[i] !=0 && nums[i - 1] == 0)
            {
                start = i;
            }
        }

        if(nums[nums.Length-1] != 0)
        {
            int curMaxLen = GetMaxLenNoZero(nums, start, nums.Length - 1);
            maxLength = Math.Max(maxLength, curMaxLen);
        }


        return maxLength;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.GetMaxLen(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(new int[] { 1, -2, -3, 4 }, 4); }
    [TestMethod] public void Test02() { TestBase(new int[] { 0, 1, -2, -3, -4 }, 3); }
    [TestMethod] public void Test03() { TestBase(new int[] { -1, -2, -3, 0, 1 }, 2); }
    [TestMethod] public void Test04() { TestBase(new int[] { -1, 2 }, 1); }
    [TestMethod] public void Test05() { TestBase(new int[] { 1, 2, 3, 5, -6, 4, 0, 10 }, 4); }
    [TestMethod] public void Test06() { TestBase(new int[] { 4, -2, 3, 2 }, 2); }
    [TestMethod] public void Test07() { TestBase(new int[] { 4, -2, 0, 2, -2, 3, 2 }, 2); }
    [TestMethod] public void Test08() { TestBase(new int[] { 2, -2, 3, 2 }, 2); }
    [TestMethod] public void Test09() { TestBase(new int[] { 2, -5, -2, -4, 3 }, 3); }
    [TestMethod] public void Test10() { TestBase(new int[] { 2, -5, -4, 3 }, 4); }
    [TestMethod] public void Test11() { TestBase(new int[] { 4, -2, 3, 2, -2, 3, 3, -2, 1 }, 7); }
    [TestMethod] public void Test12() { TestBase(new int[] { -2, 0, -1 }, 1); }
    [TestMethod] public void Test13() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test14() { TestBase(new int[] { -1 }, 0); }
    [TestMethod] public void Test15_TwoNegative() { TestBase(new int[] { -1, -1 }, 2); }


}
