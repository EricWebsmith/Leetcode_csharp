namespace Leetcode1491;

public class Solution
{
    public double Average(int[] salary)
    {
        return (double)(salary.Sum() - salary.Max() - salary.Min()) / (salary.Length - 2);
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string salaryStr, double expected)
    {
        int[] salary = salaryStr.LeetcodeToArray();
        double actual = new Solution().Average(salary);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[4000,3000,1000,2000]", 2500); }
    [TestMethod] public void Test2() { TestBase("[1000,2000,3000]", 2000); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
 Runtime: 76 ms, faster than 93.41% of C# online submissions for Average Salary Excluding the Minimum and Maximum Salary.
Memory Usage: 38.4 MB, less than 9.51% of C# online submissions for Average Salary Excluding the Minimum and Maximum Salary.
 */