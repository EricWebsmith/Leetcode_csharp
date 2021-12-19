namespace Leetcode0279;

public class Solution
{
    public int NumSquares(int n)
    {
        int[] dp;
        List<int> squares = new List<int>();
        dp = new int[n + 1];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = 10000;
        }

        int sqrt = 1;
        int square = 1;
        squares.Clear();
        squares.Add(0);
        while (square <= n)
        {
            dp[square] = 1;
            squares.Add(square);
            sqrt++;
            square = sqrt * sqrt;
        }


        if (dp[n] == 1) { return 1; }

        // build dp
        for (int i = 1; i < n; i++)
        {
            for (sqrt = 1; sqrt < squares.Count; sqrt++)
            {
                if (i + squares[sqrt] > n)
                {
                    break;
                }
                dp[i + squares[sqrt]] = Math.Min(dp[i + squares[sqrt]], dp[i] + 1);
            }
        }


        return dp[n];
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int n, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.NumSquares(n);
        Assert.AreEqual(expected, actual);
    }

    
    [TestMethod] public void Test1() { TestBase(12, 3); }
    [TestMethod] public void Test2() { TestBase(13, 2); }
    [TestMethod] public void Test3() { TestBase(100, 1); }
    [TestMethod] public void Test4() { TestBase(90, 2); }
    [TestMethod] public void Test5() { TestBase(10000, 1); }
    [TestMethod] public void Test6() { TestBase(9999, 4); }
    [TestMethod] public void Test7() { TestBase(1, 1); }


}
