namespace Leetcode1905;


public class Solution
{
    int[][] grid1 = null;
    int[][] grid2 = null;
    int m = 0;
    int n = 0;
    bool[][] visited = null;

    bool isSubIsland = true;
    void Dfs(int r, int c)
    {
        if (r < 0 || r >= m || c < 0 || c >= n || grid2[r][c] == 0 || visited[r][c])
        {
            return;
        }

        visited[r][c] = true;
        if (grid1[r][c] == 0)
        {
            isSubIsland = false;
        }

        Dfs(r - 1, c);
        Dfs(r, c - 1);
        Dfs(r + 1, c);
        Dfs(r, c + 1);
    }

    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        this.grid1 = grid1;
        this.grid2 = grid2;
        m = grid1.Length;
        n = grid1[0].Length;
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
                if (grid2[r][c] == 0)
                {
                    continue;
                }

                if (visited[r][c])
                {
                    continue;
                }

                isSubIsland = true;
                Dfs(r, c);
                if (isSubIsland)
                {
                    ans ++;
                }
            }
        }
        return ans;

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string grid1Str, string grid2Str, int expected)
    {
        int[][] grid1 = grid1Str.LeetcodeToArray2D();
        int[][] grid2 = grid2Str.LeetcodeToArray2D();
        int actual = new Solution().CountSubIslands(grid1, grid2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(
        "[[1,1,1,0,0],[0,1,1,1,1],[0,0,0,0,0],[1,0,0,0,0],[1,1,0,1,1]]",
        "[[1,1,1,0,0],[0,0,1,1,1],[0,1,0,0,0],[1,0,1,1,0],[0,1,0,1,0]]",3); }
    [TestMethod] public void Test2() { TestBase(
        "[[1,0,1,0,1],[1,1,1,1,1],[0,0,0,0,0],[1,1,1,1,1],[1,0,1,0,1]]",
        "[[0,0,0,0,0],[1,1,1,1,1],[0,1,0,1,0],[0,1,0,1,0],[1,0,0,0,1]]", 2); }
    [TestMethod] public void Test3() { TestBase(
        "[[1,0,1,0,1],[1,1,1,1,1],[0,0,0,0,0],[1,1,1,1,1],[1,0,1,0,1]]",
        "[[0,0,0,0,0],[1,1,1,1,1],[0,0,0,0,0],[0,1,0,1,0],[1,0,0,0,1]]", 5); }
}

/*
Runtime: 474 ms, faster than 79.05% of C# online submissions for Count Sub Islands.
Memory Usage: 53 MB, less than 77.14% of C# online submissions for Count Sub Islands. 
 */