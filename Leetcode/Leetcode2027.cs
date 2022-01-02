namespace Leetcode2027;

/// <summary>
/// Runtime: 64 ms, faster than 87.23% of C# online submissions for Minimum Moves to Convert String.
/// Memory Usage: 35.8 MB, less than 40.43% of C# online submissions for Minimum Moves to Convert String.
/// </summary>
public class Solution
{
    public int MinimumMoves(string s)
    {
        int n = s.Length;

        int count = 0;
        for(int i = 0; i < n; i++)
        {
            if(s[i] == 'X')
            {
                count++;
                i += 2;
            }
        }

        return count;


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