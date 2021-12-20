namespace Leetcode0292;

/// <summary>
/// Runtime: 40 ms, faster than 79.49% of C# online submissions for Nim Game.
/// Memory Usage: 28.6 MB, less than 24.79% of C# online submissions for Nim Game.
/// </summary>
public class Solution
{
    public bool CanWinNim(int n)
    {
        n = n % 7;
        return n != 4;
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