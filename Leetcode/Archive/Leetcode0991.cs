namespace Leetcode0991;


public class Solution
{
    public int BrokenCalc(int startValue, int target)
    {
        if (startValue >= target)
        {
            return startValue - target;
        }

        if (target % 2 == 0)
        {
            return 1 + BrokenCalc(startValue, target / 2);
        }

        return 1 + BrokenCalc(startValue, target + 1);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int startValue, int target, int expected)
    {
        int actual = new Solution().BrokenCalc(startValue, target);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, 3, 2); }
    [TestMethod] public void Test2() { TestBase(5, 8, 2); }
    [TestMethod] public void Test3() { TestBase(3, 10, 3); }
    [TestMethod] public void Test4() { TestBase(1, 1000000000, 39); }
    [TestMethod] public void Test5() { TestBase(1024, 1, 1023); }

}