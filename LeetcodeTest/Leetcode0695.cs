namespace Leetcode0695;

public class Solution
{
    int[][] grid;
    int area = 0;
    int maxArea = 0;

    private void Visit(int r, int c)
    {
        grid[r][c] = 0;
        area++;
        if (r + 1 < grid.Length && grid[r + 1][c] == 1)
        {
            Visit(r + 1, c);
        }

        if (r - 1 >= 0 && grid[r - 1][c] == 1)
        {
            Visit(r - 1, c);
        }

        if (c + 1 < grid[0].Length && grid[r][c + 1] == 1)
        {
            Visit(r, c + 1);
        }

        if (c - 1 >= 0 && grid[r][c - 1] == 1)
        {
            Visit(r, c - 1);
        }
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        this.grid = grid;

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 1)
                {
                    Visit(r, c);
                    maxArea = Math.Max(maxArea, area);
                    area = 0;
                }
            }

        }


        return this.maxArea;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] grid, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxAreaOfIsland(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        int[][] grid = new int[][]
        {
          new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
          new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
          new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
          new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
          new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
          new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
          new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
          new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0},
        };

        TestBase(grid, 6);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] image = new int[][]
        {
          new int[] {0,0,0,0,0,0,0,0}
        };

        TestBase(image, 0);
    }

}
