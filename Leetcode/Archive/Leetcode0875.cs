namespace Leetcode0875;

/// <summary>
/// Runtime: 124 ms, faster than 59.15% of C# online submissions for Koko Eating Bananas.
/// Memory Usage: 43.2 MB, less than 56.10% of C# online submissions for Koko Eating Bananas.
/// </summary>
public class Solution
{
    int[] piles;
    int n;

    private int EatTime(int k)
    {
        int t = 0;
        for(int i = 0; i < n; i++)
        {
            t+=piles[i] / k;
            if(piles[i] % k > 0)
            {
                t++;
            }
        }

        return t;
    }

    public int MinEatingSpeed(int[] piles, int h)
    {
        this.piles = piles;
        n = piles.Length;
        int lo = 1;
        int hi = piles.Max();
        while(lo <= hi)
        {
            int m = lo + (hi - lo)/2;
            int t = EatTime(m);
            if(t > h)
            {
                lo = m+1;
            }
            else
            {
                hi = m-1;
            }
        }

        return lo;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string pilesStr, int h, int expected)
    {
        int[] piles = pilesStr.LeetcodeToArray();
        int actual = new Solution().MinEatingSpeed(piles, h);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,6,7,11]", 8, 4); }
    [TestMethod] public void Test2() { TestBase("[30,11,23,4,20]", 5, 30); }
    [TestMethod] public void Test3() { TestBase("[30,11,23,4,20]", 6, 23); }
    [TestMethod] public void Test4() { TestBase("[312884470]",312884469,2); }
    [TestMethod] public void Test5() { TestBase("[1,1,1,999999999]", 10, 142857143); }
    [TestMethod] public void Test6() { TestBase("[1,1,1,99]", 10, 15); }
}