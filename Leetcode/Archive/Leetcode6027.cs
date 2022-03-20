namespace Leetcode6027;


public class Solution
{
    public int CountHillValley(int[] nums)
    {
        List<int> list = new List<int>();
        list.Add(nums[0]);
        for (int i = 1; i < nums.Length; i++)
        {
            if(nums[i] != list.Last())
            {
                list.Add(nums[i]);
            }
        }

        int ans = 0;
        for(int i=1;i <= list.Count - 2; i++)
        {
            if(list[i] > list[i - 1] && list[i]> list[i + 1])
            {
                ans++;
            }

            if (list[i] < list[i - 1] && list[i] < list[i + 1])
            {
                ans++;
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}