namespace Leetcode0310;

/// <summary>
/// Runtime: 176 ms, faster than 69.34% of C# online submissions for Minimum Height Trees.
/// Memory Usage: 48.6 MB, less than 15.33% of C# online submissions for Minimum Height Trees.
/// </summary>
public class Solution
{
    Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
    int n;

    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        this.n = n;
        if (n == 1) { return new int[] { 0 }; }
        if (n == 2) { return new int[] { 0, 1 }; }
        // step 1, build dict
        map.Clear();

        for (int i = 0; i < n; i++)
        {
            map.Add(i, new HashSet<int>());
        }

        int[] degees = new int[n];
        for (int i = 0; i < edges.Length; i++)
        {
            degees[edges[i][0]]++;
            degees[edges[i][1]]++;
            map[edges[i][0]].Add(edges[i][1]);
            map[edges[i][1]].Add(edges[i][0]);
        }

        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < n; i++)
        {
            if (degees[i] == 1) { queue.Enqueue(i); }
        }

        List<int> result = new List<int>();
        while(queue.Count > 0)
        {
            List<int> list = new List<int> ();
            int qCount = queue.Count;
            for(int i = 0;i < qCount; i++)
            {
                int current = queue.Dequeue();
                list.Add(current);
                foreach(int neighbor in map[current])
                {
                    degees[neighbor]--;
                    if(degees[neighbor] == 1)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            result = list;
        }

        return result;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, string edgesStr, string expected)
    {
        int[][] edges = edgesStr.LeetcodeToArray2D();
        IList<int> actual = new Solution().FindMinHeightTrees(n, edges);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase(4, "[[1,0],[1,2],[1,3]]", "[1]"); }
    [TestMethod] public void Test2() { TestBase(6, "[[3,0],[3,1],[3,2],[3,4],[5,4]]", "[3,4]"); }
    [TestMethod] public void Test3() { TestBase(1, "[]", "[0]"); }
    [TestMethod] public void Test4() { TestBase(2, "[[0,1]]", "[0,1]"); }
}