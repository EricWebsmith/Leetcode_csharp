namespace Leetcode1162;


public class Solution
{
    public int MaxDistance(int[][] grid)
    {
        int n = grid.Length;
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                grid[r][c] = grid[r][c] == 1 ? 0 : n * 2;
            }
        }

        //top, left to bottom, right
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (grid[r][c] == 0)
                {
                    continue;
                }

                if (r > 0)
                {
                    grid[r][c] = Math.Min(grid[r][c], grid[r - 1][c] + 1);
                }

                if (c > 0)
                {
                    grid[r][c] = Math.Min(grid[r][c], grid[r][c - 1] + 1);
                }
            }
        }

        //bottom, right to top, left 
        int ans = 0;
        for (int r = n - 1; r >= 0; r--)
        {
            for (int c = n - 1; c >= 0; c--)
            {
                if (grid[r][c] == 0)
                {
                    continue;
                }

                if (r < n - 1)
                {
                    grid[r][c] = Math.Min(grid[r][c], grid[r + 1][c] + 1);
                }

                if (c < n - 1)
                {
                    grid[r][c] = Math.Min(grid[r][c], grid[r][c + 1] + 1);
                }

                ans = Math.Max(ans, grid[r][c]);
            }
        }

        //grid.Print2D();

        return (ans == 0 || ans == n * 2) ? -1 : ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string gridStr, int expected)
    {
        int[][] grid = gridStr.LeetcodeToArray2D();
        int actual = new Solution().MaxDistance(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,0,1],[0,0,0],[1,0,1]]", 2); }
    [TestMethod] public void Test2() { TestBase("[[1,0,0],[0,0,0],[0,0,0]]", 4); }
    [TestMethod] public void Test3() { TestBase("[[1,1,1,1,1],[1,1,1,1,1],[1,1,1,1,1],[1,1,1,1,1],[1,1,1,1,1]]", -1); }
    [TestMethod] public void Test4() { TestBase("[[0,0,0],[0,0,0],[0,0,0]]", -1); }
    [TestMethod] public void Test5() { TestBase("[[0,0,1,1,1],[0,1,1,0,0],[0,0,1,1,0],[1,0,0,0,0],[1,1,0,0,1]]", 2); }

}

/*
 Runtime: 172 ms, faster than 78.43% of C# online submissions for As Far from Land as Possible.
Memory Usage: 39.7 MB, less than 92.16% of C# online submissions for As Far from Land as Possible.
 */