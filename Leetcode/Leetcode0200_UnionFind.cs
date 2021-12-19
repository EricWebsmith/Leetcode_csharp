namespace Leetcode0200;

public class Solution
{
    private int Find(int[] unionFind, int index)
    {
        int p = unionFind[index];
        while (p != unionFind[p])
        {
            p = unionFind[p];
        }
        return p;
    }

    private void Union(int[] unionFind, int index1, int index2)
    {
        if (unionFind[index2] == -1)
        {
            unionFind[index2] = unionFind[index1];
            return;
        }

        int p1 = Find(unionFind, index1);
        int p2 = Find(unionFind, index2);
        unionFind[p2] = p1;
    }

    public int NumIslands(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[] unionFind = new int[grid.Length * grid[0].Length];
        Array.Fill(unionFind, -1);

        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (grid[y][x] == '0')
                {
                    continue;
                }

                int unionFindIndex = y * n + x;
                if (unionFind[unionFindIndex] == -1)
                {
                    unionFind[unionFindIndex] = unionFindIndex;
                }
                if (y + 1 < m && grid[y + 1][x] == '1')
                {
                    Union(unionFind, unionFindIndex, unionFindIndex + n);
                }
                if (x + 1 < n && grid[y][x + 1] == '1')
                {
                    Union(unionFind, unionFindIndex, unionFindIndex + 1);
                }
            }
        }

        int result = 0;
        for (int index = 0; index < unionFind.Length; index++)
        {
            if (unionFind[index] == index)
            {
                result++;
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