namespace Leetcode0476;

/// <summary>
/// Runtime: 28 ms, faster than 82.14% of C# online submissions for Number Complement.
/// Memory Usage: 26.8 MB, less than 50.00% of C# online submissions for Number Complement.
/// </summary>
public class Solution
{
    public int FindComplement(int num)
    {
        int mask = 0;
        int cur = num;
        while(cur > 0)
        {
            mask = (mask << 1) + 1;
            cur >>= 1;
        }
        return mask ^ num;
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