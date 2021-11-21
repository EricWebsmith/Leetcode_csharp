namespace Leetcode1971;

public class Solution_DFS
{
    public bool ValidPath(int n, int[][] edges, int start, int end)
    {
        if(start == end) { return true; }

        List<List<int>> paths = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            paths.Add(new List<int>());
        }

        foreach (int[] edge in edges)
        {
            paths[edge[0]].Add(edge[1]);
            paths[edge[1]].Add(edge[0]);
        }

        HashSet<int> visited = new HashSet<int>();

        Queue<int> q = new Queue<int>();
        q.Enqueue(start);

        while (q.Count > 0)
        {
            int v = q.Dequeue();
            List<int> neighbors = paths[v];
            foreach (int neighbor in neighbors)
            {
                if (neighbor == end)
                {
                    return true;
                }

                if (!visited.Contains(neighbor))
                {
                    q.Enqueue(neighbor);
                }
            }

            visited.Add(v);
        }

        return false;
    }
}

/// <summary>
/// Union Find
/// </summary>
public class Solution
{
    int[] root;
    // Option3: Union Find
    public bool ValidPath(int n, int[][] edges, int start, int end)
    {
        root = new int[n];
        for (int i = 0; i < n; i++)
        {
            root[i] = i;
        }

        foreach (var edge in edges)
        {
            Union(edge[0], edge[1]);
        }

        return IsConnected(start, end);
    }

    private void Union(int x, int y)
    {
        x = Find(x);
        y = Find(y);

        if (x != y)
            root[y] = x;
    }

    private int Find(int x)
    {
        if (root[x] == x)
            return root[x];
        else
            return root[x] = Find(root[x]);
    }

    private bool IsConnected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int n, int[][] edges, int start, int end, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.ValidPath(n, edges, start, end);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        int[][] edges = new int[][]
        {
            new int[]{0,1},
            new int[]{1,2},
            new int[]{2,0}
        };

        TestBase(3, edges, 0, 2, true);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] edges = new int[][]
        {
            new int[]{0,1},
            new int[]{0, 2},
            new int[]{3, 5},
            new int[]{5, 4},
            new int[]{4, 3}
        };

        TestBase(6, edges, 0, 5, false);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] edges = new int[][]{};

        TestBase(1, edges, 0, 0, true);
    }
}
