namespace Leetcode0417;


public class Solution
{
    int m = 0;
    int n = 0;
    int[][] heights = null;

    private void Dfs(int r, int c, int height, bool[][] visited)
    {
        if(r<0 || r==m || c<0 || c==n || visited[r][c])
        {
            return;
        }

        if(height > heights[r][c])
        {
            return;
        }

        visited[r][c] = true;

        Dfs(r-1, c, heights[r][c], visited);
        Dfs(r, c-1, heights[r][c], visited);
        Dfs(r+1, c, heights[r][c], visited);
        Dfs(r, c+1, heights[r][c], visited);
    }

    private bool[][] GetReach(int rowBoarder, int colBoarder)
    {
        bool[][]  visited = new bool[m][];
        for (int r = 0; r < m; r++)
        {
            visited[r] = new bool[n];
        }

        // visits
        for (int r = 0; r < m; r++)
        {
            Dfs(r, colBoarder, -1, visited);
        }

        for (int c = 0; c < n; c++)
        {
            Dfs(rowBoarder, c, -1,visited);
        }
        return visited;
    }

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        this.heights = heights;
        m = heights.Length;
        n = heights[0].Length;
        //pacific
        // init
        bool[][] pacificReachable = GetReach(0, 0);
        bool[][] atlanticReachable = GetReach(m - 1, n - 1);

        List<IList<int>> ans = new List<IList<int>>();
        for(int r = 0; r < m;r++)
        {
            for(int c = 0; c < n; c++)
            {
                if(pacificReachable[r][c] && atlanticReachable[r][c])
                {
                    ans.Add(new int[] { r,c});
                }
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string heightsStr, string expectedStr)
    {
        int[][] heights = heightsStr.LeetcodeToArray2D();
        IList<IList<int>> actual = new Solution().PacificAtlantic(heights);
        int[][] expected = expectedStr.LeetcodeToArray2D();
        Assert.AreEqual(expected.Length, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase(
        "[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]",
        "[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]"
        ); }
    [TestMethod] public void Test2() { TestBase(
        "[[2,1],[1,2]]",
        " [[0,0],[0,1],[1,0],[1,1]]"); }
    [TestMethod] public void Test3() { TestBase(
        "[[1,1],[1,1],[1,1]]",
        "[[0,0],[0,1],[1,0],[1,1],[2,0],[2,1]]"
        ); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 172 ms, faster than 97.15% of C# online submissions for Pacific Atlantic Water Flow.
Memory Usage: 47.5 MB, less than 18.52% of C# online submissions for Pacific Atlantic Water Flow.
 */