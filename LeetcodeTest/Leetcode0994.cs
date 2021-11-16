using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leetcode0994;

public class Solution
{
    [DebuggerDisplay("{x}, {y}")]
    private struct Position
    {
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x;
        public int y;
    }

    public int OrangesRotting(int[][] grid)
    {
        const int FRESH = 1;
        const int ROTTEN = 2;
        int m = grid.Length;
        int n = grid[0].Length;
        int freshOranges = 0;
        Queue<Position> positions = new Queue<Position>();

        // first find all rotten oranges
        // count oranges
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == FRESH)
                {
                    freshOranges++;
                }
                else if (grid[y][x] == ROTTEN)
                {
                    positions.Enqueue(new Position(x, y));
                }
            }
        }

        // if there is no fresh orange initally.
        if (freshOranges == 0)
        {
            return 0;
        }

        // if there is no rotten orange initially.
        if (positions.Count == 0)
        {
            return -1;
        }



        // oranges are rotten every minute.
        // until no adjacent oranges can be found.
        int minites = -1;
        while (positions.Count > 0)
        {
            List<Position> newPositions = new List<Position>();
            int size = positions.Count;
            for (int i = 0; i < size; i++)
            {
                Position p = positions.Dequeue();

                // east
                if (p.x + 1 < n && grid[p.y][p.x + 1] == FRESH)
                {
                    grid[p.y][p.x + 1] = ROTTEN;
                    freshOranges--;
                    positions.Enqueue(new Position(p.x + 1, p.y));
                }

                // south
                if (p.y + 1 < m && grid[p.y + 1][p.x] == FRESH)
                {
                    grid[p.y + 1][p.x] = ROTTEN;
                    freshOranges--;
                    positions.Enqueue(new Position(p.x, p.y + 1));
                }

                // west
                if (p.x - 1 >= 0 && grid[p.y][p.x - 1] == FRESH)
                {
                    grid[p.y][p.x - 1] = ROTTEN;
                    freshOranges--;
                    positions.Enqueue(new Position(p.x - 1, p.y));
                }

                // north
                if (p.y - 1 >= 0 && grid[p.y - 1][p.x] == FRESH)
                {
                    grid[p.y - 1][p.x] = ROTTEN;
                    freshOranges--;
                    positions.Enqueue(new Position(p.x, p.y - 1));
                }
            }
            minites++;
        }

        if (freshOranges > 0)
        {
            return -1;
        }

        return minites;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] grid, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.OrangesRotting(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1_Connected()
    {
        int[][] grid = new int[][]
        {
            new int[] {2, 1, 1},
            new int[] {1, 1, 0},
            new int[] {0, 1, 1}
        };

        TestBase(grid, 4);
    }

    [TestMethod]
    public void Test2_NotConnected()
    {
        int[][] grid = new int[][]
        {
            new int[] {2, 1, 0},
            new int[] {1, 1, 0},
            new int[] {1, 0, 1}
        };

        TestBase(grid, -1);
    }


    [TestMethod]
    public void Test3_NoRottenOrange()
    {
        int[][] grid = new int[][]
        {
            new int[] {1, 1, 0},
            new int[] {1, 1, 0},
            new int[] {1, 0, 1}
        };

        TestBase(grid, -1);
    }

    [TestMethod]
    public void Test4_NoFreshOrange()
    {
        int[][] grid = new int[][]
        {
            new int[] {2,0}
        };

        TestBase(grid, 0);
    }

    [TestMethod]
    public void Test5_NoOrange()
    {
        int[][] grid = new int[][]
        {
            new int[] {0, 0}
        };

        TestBase(grid, 0);
    }

    [TestMethod]
    public void Test6_Connected()
    {
        int[][] grid = new int[][]
        {
            new int[] {2, 1},
            new int[] {1, 1}
        };

        TestBase(grid, 2);
    }

    [TestMethod]
    public void Test7_Connected_z()
    {
        int[][] grid = new int[][]
        {
            new int[] {2, 1, 1, 1},
            new int[] {0, 0, 0, 1},
            new int[] {1, 1, 1, 1},
            new int[] {1, 0, 0, 0},
            new int[] {1, 1, 1, 1}
        };

        TestBase(grid, 13);
    }

    [TestMethod]
    public void Test7_Connected_8()
    {
        int[][] grid = new int[][]
        {
            new int[] {2, 1, 1},
            new int[] {1, 0, 1},
            new int[] {1, 1, 1},
            new int[] {1, 0, 1},
            new int[] {1, 1, 1}
        };

        TestBase(grid, 6);
    }

    [TestMethod]
    public void Test8_Connected()
    {
        int[][] grid = new int[][]
        {
            new int[] {1, 2}
        };

        TestBase(grid, 1);
    }


    [TestMethod]
    public void Test9_Connected()
    {
        int[][] grid = new int[][]
        {
            new int[] { 0, 2, 2, 2, 1, 1 },
            new int[] {1,2,2,0,0,2 },
            new int[]{1,2,1,0,0,2 },
            new int[]{0,1,1,1,1,0 }
        };

        TestBase(grid, 4);
    }

}
