namespace Leetcode1020;



public class Solution
{
    int[][] grid = null;
    bool[][] visited = null;
    int m = 0;
    int n = 0;

    bool closed = true;
    int area = 0;
    void Dfs(int r, int c)
    {
        if(r<0 || r>=m || c<0 || c >= n || grid[r][c]==0 || visited[r][c])
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

        area++;

        Dfs(r-1, c);
        Dfs(r, c-1);
        Dfs(r+1, c);
        Dfs(r, c+1);
    }

    void Reset()
    {
        closed = true;
        area = 0;
    }

    public int NumEnclaves(int[][] grid)
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
                if (grid[r][c] == 0)
                {
                    continue;
                }

                if (visited[r][c])
                {
                    continue;
                }

                Reset();
                Dfs(r, c);
                if (closed)
                {
                    ans+=area;
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
        int actual = new Solution().NumEnclaves(grid);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[0,0,0,0],[1,0,1,0],[0,1,1,0],[0,0,0,0]]", 3); }
    [TestMethod] public void Test2() { TestBase("[[0,1,1,0],[0,0,1,0],[0,0,1,0],[0,0,0,0]]", 0); }
    [TestMethod] public void Test3() { TestBase(@"[[1,1,1,1,1,1,1],
               [1,0,0,0,0,0,1],
               [1,0,1,1,1,0,1],
               [1,0,1,0,1,0,1],
               [1,0,1,1,1,0,1],
               [1,0,0,0,0,0,1],
               [1,1,1,1,1,1,1]]", 8); }
    //[TestMethod] public void Test4() { TestBase(); }

}