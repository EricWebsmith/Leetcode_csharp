using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0463;

public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int perimeter = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    perimeter = (i == 0 || grid[i - 1][j] == 0) ? perimeter + 1 : perimeter;
                    perimeter = (i == grid.Length-1 || grid[i +1][j] == 0) ? perimeter + 1 : perimeter;
                    perimeter = (j == 0 || grid[i][j-1] == 0) ? perimeter + 1 : perimeter;
                    perimeter = (j == grid[0].Length-1 || grid[i][j + 1] == 0) ? perimeter + 1 : perimeter;
                }
            }
        }
        return perimeter;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] grid, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.IslandPerimeter(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        int[][] grid = new int[][]
        {
          new int[] {0, 1, 0, 0},
          new int[] {1, 1, 1, 0},
          new int[] {0, 1, 0, 0},
          new int[] {1, 1, 0, 0}
        };

        TestBase(grid, 16);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] grid = new int[][]
        {
          new int[] {1},
        };
        TestBase(grid, 4);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] grid = new int[][]
        {
          new int[] {1, 0},
        };
        TestBase(grid, 4);
    }

    [TestMethod]
    public void Test4()
    {
        int[][] grid = new int[][]
        {
          new int[] {0, 1},
        };
        TestBase(grid, 4);
    }

    [TestMethod]
    public void Test5()
    {
        int[][] grid = new int[][]
        {
          new int[] {1, 1},
        };
        TestBase(grid, 6);
    }

    [TestMethod]
    public void Test6()
    {
        int[][] grid = new int[][]
        {
          new int[] {1, 1},
          new int[] {1, 1}
        };
        TestBase(grid, 8);
    }
}
