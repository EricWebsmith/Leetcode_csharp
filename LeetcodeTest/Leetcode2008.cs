using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Leetcode2008;

// looks terrible compared to the same python code.
public class Solution
{
    int[] dp;
    int n;
    int[][] rides;

    private int Dynamic(int index)
    {
        if (dp[index] != -1)
        {
            return dp[index];
        }

        if (index == rides.Length)
        {
            return 0;
        }

        int notPick = Dynamic(index + 1);

        int nextIndex = rides.Length;
        for (int i = index; i < rides.Length; i++)
        {
            if (rides[i][0] >= rides[index][1])
            {
                nextIndex = i;
                break;
            }
        }
        int pick = rides[index][1] - rides[index][0] + rides[index][2] + Dynamic(nextIndex);

        dp[index] = Math.Max(notPick, pick);

        return dp[index];
    }

    public long MaxTaxiEarnings(int n, int[][] rides)
    {
        dp = new int[n + 1];

        for(int i = 0; i < dp.Length; i++)
        {
            dp[i] = -1;
        }

        this.n = n;
        // this.rides = rides;

        var list = rides.ToList();
        list.Sort((a, b) => a[0].CompareTo(b[0]));
        this.rides = list.ToArray();

        return Dynamic(0);
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int n, int[][] rides, int expected)
    {

        Solution solution = new Solution();
        long actual = solution.MaxTaxiEarnings(n, rides);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        int[][] rides = new int[][]
        {
            new int[]{2,5,4},
            new int[]{1,5,1}
        };
        TestBase(7, rides, 7);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] rides = new int[][]
        {
            new int[]{1,6,1},
            new int[]{3,10,2},
            new int[]{10,12,3},
            new int[]{11,12,2},
            new int[]{12,15,2},
            new int[]{13,18,1}
        };
        TestBase(20, rides, 20);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] rides = new int[][]
        {
            new int[]{1,5,1},
            new int[]{2,5,4}
        };
        TestBase(7, rides, 7);
    }
}