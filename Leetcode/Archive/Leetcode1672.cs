﻿namespace Leetcode1672;


public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(x => x.Sum()).Max();
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