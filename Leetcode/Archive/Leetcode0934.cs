namespace Leetcode0934;


public class Solution
{
    int n = 0;
    Queue<int[]> queue = new Queue<int[]>();
    int[][] directions = new int[4][]
    {
            new int[]{-1, 0},
            new int[]{0, -1},
            new int[]{1, 0},
            new int[]{0, 1},
    };

    public void dfs(int i, int j, int[][] grid)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[i].Length || grid[i][j] != 1)
        {
            return;
        }

        grid[i][j] = 2;
        queue.Enqueue(new int[] { i, j });
        foreach (int[] direction in directions)
        {
            dfs(i + direction[0], j+ direction[1], grid);
        }
    }

    public int ShortestBridge(int[][] grid)
    {
        n = grid.Length;
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (grid[r][c] == 1)
                {
                    dfs(r, c, grid);
                    r = n;
                    break;
                }
            }
        }

        int ans = 0;
        while (queue.Count > 0)
        {
            int queueCount = queue.Count;
            for (int i = 0; i < queueCount; i++)
            {
                int[] element = queue.Dequeue();
                int r = element[0];
                int c = element[1];

                foreach (int[] direction in directions)
                {
                    int newR = r + direction[0];
                    int newC = c + direction[1];
                    if(newR<0 || newR==n || newC<0 || newC == n)
                    {
                        continue;
                    }

                    if (grid[newR][newC] == 0)
                    {
                        grid[newR][newC] = 2;
                        queue.Enqueue(new int[] { newR, newC });
                    }
                    else if (grid[newR][newC] == 1)
                    {
                        return ans;
                    }
                }
            }
            ans++;
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string gridStr, int expected)
    {
        int[][] grid = gridStr.LeetcodeToArray2D();
        int actual = new Solution().ShortestBridge(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[0,1],[1,0]]", 1); }
    [TestMethod] public void Test2() { TestBase("[[0,1,0],[0,0,0],[0,0,1]]", 2); }
    [TestMethod] public void Test3() { TestBase("[[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]", 1); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
 Runtime: 143 ms, faster than 87.60% of C# online submissions for Shortest Bridge.
Memory Usage: 39.4 MB, less than 93.39% of C# online submissions for Shortest Bridge.
 */