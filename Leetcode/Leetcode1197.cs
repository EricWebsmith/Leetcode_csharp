namespace Leetcode01197;

public class Solution
{
    int?[,] dp = new int?[301, 301];

    public int MinKnightMoves(int x, int y)
    {
        dp[0, 0] = 0;
        dp[1,1] = 2;
        dp[1, 0] = 3;
        return MinKnightMovesInner(x, y);
    }

    private int MinKnightMovesInner(int x, int y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        if(x < y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        if (dp[x,y] != null)
        {
            return dp[x, y].Value;
        }

        int ans = 1 + Math.Min(MinKnightMovesInner(x - 2, y - 1), MinKnightMovesInner(x - 1, y - 2));
        dp[x, y] = ans;
        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(int x, int y, int expected)
    {
        int actual = new Solution().MinKnightMoves(x, y);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, 1, 1); }
    [TestMethod] public void Test2() { TestBase(5, 5, 4); }
    [TestMethod] public void Test3() { TestBase(-5, -5, 4); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 34 ms, faster than 97.89% of C# online submissions for Minimum Knight Moves.
Memory Usage: 29.3 MB, less than 93.68% of C# online submissions for Minimum Knight Moves.
 */