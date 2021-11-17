using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode0096;

public class Solution
{
    static List<int> dp = new List<int>() { 1, 1,2};
    public int NumTrees(int n)
    {
        if (n <= 2)
        {
            return dp[n];
        }

        while(dp.Count <= n)
        {
            int last = dp.Count;
            int sum = 0;
            for(int i = 0; i < dp.Count; i++)
            {
                sum += dp[i] * dp[dp.Count - i-1];
            }
            dp.Add(sum);
        }

        return dp[n];
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int n, int expected)
    {
        int actual = (new Solution()).NumTrees(n);
        Assert.AreEqual(expected, actual);
    }

    
    [TestMethod] public void Test1() { TestBase(1, 1); }
    [TestMethod] public void Test2() { TestBase(2, 2); }
    [TestMethod] public void Test3() { TestBase(3, 5); }
    [TestMethod] public void Test4() { TestBase(4, 14); }


}

/*
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19



 */