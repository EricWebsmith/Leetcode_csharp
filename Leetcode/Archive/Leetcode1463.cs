namespace Leetcode1463;


public class Solution
{
    int n;
    int m;
    int[][] grid;
    int[,,] dp;
    public int CherryPickup(int[][] grid)
    {
        this.grid = grid;
        n = grid.Length;
        m = grid[0].Length;
        dp = new int[n, m, m];
        return Dfs(0, 0, m - 1);
    }

    private int Dfs(int row, int j1, int j2)
    {
        if (row >= n || j1 < 0 || j2 < 0 || j1 >= m || j2 >= m) { return 0; }

        if (dp[row, j1, j2] != 0) { return (dp[row, j1, j2] == -1) ? 0 : dp[row, j1, j2]; }

        int result = 0;

        int collected = grid[row][j1];
        if (j1 != j2) { collected += grid[row][j2]; }

        if (row < grid.Length - 1)
        {
            int crnt = 0;

            for (int h = j1 - 1; h <= j1 + 1; h++)
            {
                for (int g = j2 - 1; g <= j2 + 1; g++)
                {
                    crnt = Dfs(row + 1, h, g);
                    if (result < crnt) { result = crnt; }
                }
            }
        }

        dp[row, j1, j2] = collected + result;
        if (dp[row, j1, j2] == 0) { dp[row, j1, j2] = -1; }
        return (dp[row, j1, j2] == -1) ? 0 : dp[row, j1, j2];
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string gridStr, int expected)
    {
        var grid = gridStr.LeetcodeToArray2D();
        var sol = new Solution();
        var result = sol.CherryPickup(grid);
        Assert.AreEqual(expected, result);
    }

    [TestMethod] public void Test1() { TestBase("[[3,1,1],[2,5,1],[1,5,5],[2,1,1]]", 24); }
    [TestMethod] public void Test2() { TestBase("[[1,0,0,0,0,0,1],[2,0,0,0,0,3,0],[2,0,9,0,0,0,0],[0,3,0,5,4,0,0],[1,0,2,3,0,0,6]]", 28); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }
}
