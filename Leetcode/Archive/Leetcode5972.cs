namespace Leetcode5972;


public class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        int n = differences.Length+1;
        long[] origin = new long[n];
        origin[0] = 0;
        for (int i = 1; i < n; i++)
        {
            origin[i] = origin[i-1]+differences[i-1];
        }

        long originSpan = origin.Max() - origin.Min();
        long ans = upper - lower - originSpan + 1;
        ans = Math.Max(0, ans);
        return (int)ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string differencesStr, int lower, int upper, int expected)
    {
        int[] differences = differencesStr.LeetcodeToArray();
        int actual = new Solution().NumberOfArrays(differences, lower, upper);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,-3,4]", 1, 6, 2); }
    [TestMethod] public void Test2() { TestBase("[3,-4,5,1,-2]", -4, 5, 4); }
    [TestMethod] public void Test3() { TestBase("[4,-7,2]", 3, 6, 0); }
    [TestMethod] public void Test4() { TestBase("[1]", 3, 6, 3); }
    [TestMethod] public void Test5() { TestBase("[2]", 3, 6, 2); }
    [TestMethod] public void Test6() { TestBase("[2]", 3, 3, 0); }
    [TestMethod] public void Test7() { TestBase("[3]", 3, 6, 1); }
    //[TestMethod] public void Test4() { TestBase(); }

    [TestMethod] public void Test8()
    {
        Console.WriteLine(int.MaxValue);
        Console.WriteLine(int.MinValue);
        Console.WriteLine(1234567890*1);
    }
}