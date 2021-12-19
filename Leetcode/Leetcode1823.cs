namespace Leetcode1823;

/// <summary>
/// Runtime: 32 ms, faster than 82.79% of C# online submissions for Find the Winner of the Circular Game.
/// Memory Usage: 27.3 MB, less than 49.18% of C# online submissions for Find the Winner of the Circular Game.
///
/// This is a :
/// Josephus Problem
/// </summary>
public class Solution
{
    public int FindTheWinner(int n, int k)
    {
        if (n == 1) { return 1; }
        if (k == 1) { return n; }

        List<int> circle = new List<int>();

        for (int i = 0; i < n; i++) { circle.Add(i + 1); }

        int current = 0;
        for (int i = n; i > 1; i--)
        {
            current = (current + k - 1) % i;
            circle.RemoveAt(current);
        }

        return circle[0];
    }
}

/// <summary>
/// Time complexity is the same.
/// Execution time is also 32ms.
/// 
/// </summary>
public class Solution2
{
    public int FindTheWinner(int n, int k)
    {
        int p = 0;
        for (int i = 2; i <= n; i++)
            p = (p + k) % i;
        return p + 1;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, 5, 2, 3)]
    [DataRow(1, 6, 5, 1)]
    [DataRow(1, 1, 1, 1)]
    [DataRow(1, 3, 1, 3)]
    [DataTestMethod]
    public void Test(int order, int n, int k, int expected)
    {
        int actual = new Solution().FindTheWinner(n, k);
        Assert.AreEqual(expected, actual);
    }
}
