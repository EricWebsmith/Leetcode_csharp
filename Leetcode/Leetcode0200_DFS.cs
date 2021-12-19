namespace Leetcode0200Dfs;

public class Solution
{


    private void Dfs(char[][] grid, int x, int y)
    {
        if (x < 0 || x >= grid[0].Length || y < 0 || y >= grid.Length)
        {
            return;
        }

        if (grid[y][x] == '0')
        {
            return;
        }

        grid[y][x] = '0';

        Dfs(grid, x - 1, y);
        Dfs(grid, x + 1, y);
        Dfs(grid, x, y - 1);
        Dfs(grid, x, y + 1);
    }

    public int NumIslands(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int result = 0;
        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (grid[y][x] == '1')
                {
                    Dfs(grid, x, y);
                    result++;
                }
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void Test1()
    {
        char[][] grid = {
            new char[] { '1', '1', '1', '1', '0'},
            new char[] { '1', '1', '0', '1', '0'},
            new char[] { '1', '1', '0', '0', '0'},
            new char[] { '0', '0', '0', '0', '0'}

        };

        int actual = (new Solution()).NumIslands(grid);
        Assert.AreEqual(actual, 1);
    }

    [TestMethod]
    public void Test2()
    {
        char[][] grid = {
            new char[] { '1', '1', '0', '0', '0'},
            new char[] { '1', '1', '0', '0', '0'},
            new char[] { '0', '0', '1', '0', '0'},
            new char[] { '0', '0', '0', '1', '1'}

        };

        int actual = (new Solution()).NumIslands(grid);
        Assert.AreEqual(actual, 3);
    }

    [TestMethod]
    public void Test3()
    {
        char[][] grid = {
            new char[] { '0', '1', '0', '0', '0'},
            new char[] { '1', '1', '0', '0', '0'},
            new char[] { '0', '0', '1', '0', '0'},
            new char[] { '0', '0', '0', '1', '1'}

        };

        int actual = (new Solution()).NumIslands(grid);
        Assert.AreEqual(actual, 3);
    }

    [TestMethod]
    public void Test4()
    {
        char[][] grid = {
            new char[] { '1', '1'}
        };

        int actual = (new Solution()).NumIslands(grid);
        Assert.AreEqual(actual, 1);
    }

    [TestMethod]
    public void Test5()
    {
        char[][] grid = {
            new char[] { '1'},
            new char[] { '1'}
        };

        int actual = (new Solution()).NumIslands(grid);
        Assert.AreEqual(actual, 1);
    }
}