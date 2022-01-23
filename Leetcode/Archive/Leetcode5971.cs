namespace Leetcode5971;


public class Solution
{
    public int MinimumCost(int[] cost)
    {
        Array.Sort(cost);

        Array.Reverse(cost);

        int ans = 0;
        for(int i = 0; i < cost.Length; i++)
        {
            if(i%3 != 2)
            {
                ans += cost[i];
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