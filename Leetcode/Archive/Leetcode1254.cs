namespace Leetcode1254;


public class Solution
{
    int[][] grid = null;
    bool[][] visited = null;
    int m = 0;
    int n = 0;

    bool closed = true;
    void Dfs(int r, int c)
    {
        if(r<0 || r>=m || c<0 || c >= n || grid[r][c]==1 || visited[r][c])
        {
            return;
        }

        visited[r][c] = true;
        if (r == 0 || r == m - 1)
        {
            closed = false;
        } 
        else if (c == 0 || c == n - 1)
        {
            closed = false; 
        }

        Dfs(r-1, c);
        Dfs(r, c-1);
        Dfs(r+1, c);
        Dfs(r, c+1);
    }

    public int ClosedIsland(int[][] grid)
    {
        this.grid = grid;
        m = grid.Length;
        n = grid[0].Length;
        visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }

        int ans = 0;
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (grid[r][c] == 1)
                {
                    continue;
                }

                if (visited[r][c])
                {
                    continue;
                }

                closed = true;
                Dfs(r, c);
                if (closed)
                {
                    ans++;
                }
            }
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
        int actual = new Solution().ClosedIsland(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,1,1,1,1,1,1,0],[1,0,0,0,0,1,1,0],[1,0,1,0,1,1,1,0],[1,0,0,0,0,1,0,1],[1,1,1,1,1,1,1,0]]",2); }
    [TestMethod] public void Test2() { TestBase("[[0,0,1,0,0],[0,1,0,1,0],[0,1,1,1,0]]", 1); }
    [TestMethod] public void Test3() { TestBase(@"[[1,1,1,1,1,1,1],
               [1,0,0,0,0,0,1],
               [1,0,1,1,1,0,1],
               [1,0,1,0,1,0,1],
               [1,0,1,1,1,0,1],
               [1,0,0,0,0,0,1],
               [1,1,1,1,1,1,1]]", 2); }
    //[TestMethod] public void Test4() { TestBase(); }

}