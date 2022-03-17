namespace Leetcode1281;


public class Solution
{
    public int SubtractProductAndSum(int n)
    {
        int sum = 0;
        int product = 1;
        while(n > 0)
        {
            int r = n % 10;
            sum += r;
            product *= r;
            n = n / 10;
        }

        return product - sum;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, int expected)
    {
        int actual = new Solution().SubtractProductAndSum(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(1, 0); }
    [TestMethod] public void Test2() { TestBase(2, 0); }
    [TestMethod] public void Test234() { TestBase(234, 15); }
    [TestMethod] public void Test4421() { TestBase(4421, 21); }
    [TestMethod] public void Test10() { TestBase(10, -1); }
    [TestMethod] public void Test100() { TestBase(100, -1); }
    [TestMethod] public void Test1000() { TestBase(1000, -1); }

}

/*
 Runtime: 20 ms, faster than 91.50% of C# online submissions for Subtract the Product and Sum of Digits of an Integer.
Memory Usage: 26.6 MB, less than 15.25% of C# online submissions for Subtract the Product and Sum of Digits of an Integer.
 */