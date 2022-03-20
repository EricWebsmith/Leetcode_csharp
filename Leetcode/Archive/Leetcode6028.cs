namespace Leetcode6028;


public class Solution
{
    public int CountCollisions(string directions)
    {
        int n = directions.Length;
        var list = directions.ToList();
        int ans = 0;
        // L

        for (int i = 1; i < n; i++)
        {
            if(list[i] =='L' && list[i-1] != 'L')
            {
                list[i] = 'S';
                ans++;
            }
        }

        for(int i = n-2;i >= 0; i--)
        {
            if(list[i] == 'R' && list[i+1] != 'R')
            {
                list[i] = 'S';
                ans++;
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string directions, int expected)
    {
        int actual = new Solution().CountCollisions(directions);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("RLRSLL", 5); }
    [TestMethod] public void Test2() { TestBase("LLRR", 0); }
    [TestMethod] public void Test3() { TestBase("RRLL", 4); }
    [TestMethod] public void Test4() { TestBase("L", 0); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}