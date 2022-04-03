namespace Leetcode0847;


public class Solution
{
    public int ShortestPathLength(int[][] graph)
    {
        int n = graph.Length;
        if (n == 1)
        {
            return 0;
        }

        int finalState = (1 << n) - 1;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for(int i = 0; i < n; i++)
        {
            queue.Enqueue((i , 1<<i));
        }

        int[,] visited = new int[n, finalState+1];
        int shortestPath = 0;

        while(queue.Count > 0)
        {
            int qCount = queue.Count;
            shortestPath++;

            while (qCount > 0)
            {
                var (index, mask) = queue.Dequeue();
                

                foreach (int next in graph[index])
                {
                    int newMask = mask | (1 << next);
                    if(visited[next, newMask] == 1)
                    {
                        continue;
                    }

                    if(newMask == finalState)
                    {
                        return shortestPath;
                    }

                    visited[next, newMask] = 1;
                    queue.Enqueue((next, newMask));
                }

                qCount--;
            }
        }

        return -1;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string graphStr, int expected)
    {
        int[][] graph = graphStr.LeetcodeToArray2D();
        int actual = new Solution().ShortestPathLength(graph);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test3() { TestBase("[[1,2],[0],[0]]", 2); }
    [TestMethod] public void Test1() { TestBase("[[1,2,3],[0],[0],[0]]", 4); }
    [TestMethod] public void Test2() { TestBase("[[1],[0,2,4],[1,3,4],[2],[1,2]]", 4); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}


/*
Runtime: 107 ms, faster than 75.97% of C# online submissions for Shortest Path Visiting All Nodes.
Memory Usage: 39.6 MB, less than 80.92% of C# online submissions for Shortest Path Visiting All Nodes.
 */