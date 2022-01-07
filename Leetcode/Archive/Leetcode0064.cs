namespace Leetcode0064;

public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        for (int i = 1; i < m; i++)
        {
            grid[i][0] += grid[i - 1][0];
        }

        for (int j = 1; j < n; j++)
        {
            grid[0][j] += grid[0][j - 1];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        }

        return grid[m - 1][n - 1];

    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[[1,3,1],[1,5,1],[4,2,1]]", 7)]
    [DataRow(2, "[[1,2,3],[4,5,6]]", 12)]
    [DataRow(3, "[[1,200,3],[4,200,6]]", 210)]
    [DataRow(4, "[[9,1,4,8]]", 22)]
    [DataTestMethod]
    public void Test(int order, string matrix, int expected)
    {
        int[][] grid = Helper.Convert2D(matrix);
        int actual = (new Solution()).MinPathSum(grid);
        Assert.AreEqual(expected, actual);
    }
}