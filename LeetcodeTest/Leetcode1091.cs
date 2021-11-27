namespace Leetcode1091;

public class Solution
{


    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int n = grid.Length;
        if (grid[0][0] == 1) { return -1; }
        if (grid[n - 1][n - 1] == 1) { return -1; }


        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { 0, 0, 1 });
        grid[0][0] = 1;

        int[][] dirs =
        {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { 1, -1 },
            new int[] { 1, 1 },
            new int[] { -1, 0 },
            new int[] { -1, 1 },
            new int[] { -1, -1 }
        };

        while (queue.Count > 0)
        {
            int qCount = queue.Count;
            while (qCount-- > 0)
            {
                int[] point = queue.Dequeue();

                if (point[0] == n - 1 && point[1] == n - 1)
                {
                    return point[2];
                }

                foreach (int[] dir in dirs)
                {
                    int r = point[0] + dir[0];
                    int c = point[1] + dir[1];

                    if (r >= 0 && r < n && c >= 0 && c < n && grid[r][c] == 0)
                    {
                        queue.Enqueue(new int[] { r, c, point[2] + 1 });
                        grid[r][c] = 1;
                    }
                }
            }
        }

        return -1;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[[0,1],[1,0]]", 2)]
    [DataRow(2, "[[0,0,0],[1,1,0],[1,1,0]]", 4)]
    [DataRow(3, "[[1,0,0],[1,1,0],[1,1,0]]", -1)]
    [DataRow(4, "[[0]]", 1)]
    [DataRow(5, "[[1]]", -1)]
    [DataRow(6, "[[0,0,0,0],[0,1,1,1],[0,1,1,0],[0,1,0,0]]", -1)]
    [DataRow(7, "[[0,0,0,0],[0,1,1,1],[0,1,1,1],[0,0,0,0]]", 6)]
    [DataTestMethod]
    public void Test(int order, string gridStr, int expected)
    {
        int[][] grid = Helper.Convert2D(gridStr);
        int actual = (new Solution()).ShortestPathBinaryMatrix(grid);
        Assert.AreEqual(expected, actual);
    }
}