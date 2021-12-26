namespace Leetcode5963;


public class Solution
{
    public bool IsSameAfterReversals(int num)
    {
        if(num == 0) { return true; }
        if(num % 10 == 0) { return false; }
        return true;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}