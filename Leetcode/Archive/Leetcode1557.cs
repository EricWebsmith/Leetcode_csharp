namespace Leetcode1557;

/// <summary>
/// Runtime: 428 ms, faster than 97.75% of C# online submissions for Minimum Number of Vertices to Reach All Nodes.
/// Memory Usage: 61.5 MB, less than 41.57% of C# online submissions for Minimum Number of Vertices to Reach All Nodes.
/// </summary>
public class Solution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        int[] destinations = new int[n];
        for (int i = 0; i < edges.Count; i++)
        {

            destinations[edges[i][1]] = 1;
        }

        IList<int> result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if(destinations[i] == 0)
            {
                result.Add(i);
            }
        }

        return result;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}