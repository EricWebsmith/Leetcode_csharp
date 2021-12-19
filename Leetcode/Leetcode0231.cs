namespace Leetcode0231;

public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        if (n <= 0) { return false; }
        if (n == 1) { return true; }

        return (n & (n - 1)) == 0;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int n, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.IsPowerOfTwo(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(1, true); }
    [TestMethod] public void Test2() { TestBase(16, true); }
    [TestMethod] public void Test3() { TestBase(3, false); }
    [TestMethod] public void Test4() { TestBase(4, true); }
    [TestMethod] public void Test5() { TestBase(5, false); }
    [TestMethod] public void Test6() { TestBase(0, false); }
    [TestMethod] public void Test7() { TestBase(-1, false); }
    [TestMethod] public void Test8() { TestBase(-2, false); }
    [TestMethod] public void Test9() { TestBase(-5, false); }


}
