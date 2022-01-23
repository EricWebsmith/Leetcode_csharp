namespace Leetcode5973;


public class Solution
{
    int[][] grid;


    private int Compare(int[] pos1, int[] pos2)
    {
        if(grid[pos1[0]][pos1[1]] == grid[pos2[0]][pos2[1]])
        {
            if(pos1[0] == pos2[0])
            {
                return pos1[1].CompareTo(pos2[1]);
            }
            return pos1[0].CompareTo(pos2[0]);
        }

        return grid[pos1[0]][pos1[1]].CompareTo(grid[pos2[0]][pos2[1]]);
    }

    public IList<IList<int>> HighestRankedKItems(int[][] grid, int[] pricing, int[] start, int k)
    {
        this.grid = grid;
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] visited = new bool[m,n];

        IList<IList<int>>  ans= new List<IList<int>>();
        // BFS
        int price = grid[start[0]][start[1]];

        visited[start[0],start[1]] = true;


        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(start);
        int qCount = q.Count;
        while(qCount > 0)
        {
            List<int[]> candidates = new List<int[]>();
            for(int time=0; time<qCount; time++)
            {
                int[] pos = q.Dequeue();
                int r = pos[0];
                int c = pos[1];
                price = grid[r][c];
                if (price>=pricing[0] && price <= pricing[1])
                {
                    candidates.Add(pos);
                }

                if (r - 1 >= 0 && !visited[r - 1, c] && grid[r - 1][c] != 0)
                {
                    q.Enqueue(new int[] { r - 1, c });
                    visited[r - 1, c] = true;
                }
                if (r + 1 < m && !visited[r + 1, c] && grid[r + 1][c] != 0)
                {
                    q.Enqueue(new int[] { r + 1, c });
                    visited[r + 1, c] = true;
                }

                if (c - 1 >= 0 && !visited[r, c - 1] && grid[r][c - 1] != 0)
                {
                    q.Enqueue(new int[] { r, c - 1 });
                    visited[r, c - 1] = true;
                }

                if (c + 1 < n && !visited[r, c + 1] && grid[r][c + 1] != 0)
                {
                    q.Enqueue(new int[] { r, c + 1 });
                    visited[r, c + 1] = true;
                }
            }

            candidates.Sort(Compare);

            foreach(int[] pos in candidates)
            {
                ans.Add(pos);
                if(ans.Count == k)
                {
                    return ans;
                }
            }

            qCount = q.Count;
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string gridStr, string pricingStr, string startStr, int k, int expected)
    {
        int[][] grid = gridStr.LeetcodeToArray2D();
        int[] pricing = pricingStr.LeetcodeToArray();
        int[] start = startStr.LeetcodeToArray();
        IList<IList<int>> actual = new Solution().HighestRankedKItems(grid, pricing, start, k);
        actual.Print2D();
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase("[[1,2,0,1],[1,3,0,1],[0,2,5,1]]", "[2,5]", "[0,0]",3, 3); }
    [TestMethod] public void Test2() { TestBase("[[1,2,0,1],[1,3,3,1],[0,2,5,1]]", "[2,3]", "[2,3]", 2, 2); }
    [TestMethod] public void Test3() { TestBase("[[1,1,1],[0,0,1],[2,3,4]]", "[2,3]", "[0,0]",3, 2); }
    //[TestMethod] public void Test4() { TestBase(); }

}