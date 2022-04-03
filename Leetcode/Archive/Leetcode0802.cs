namespace Leetcode0802;


public class Solution
{
    int n = 0;
    int[][] graph = null;
    List<State> states = new List<State>();

    enum State
    {
        Unknown,
        Visiting,
        Safe,
        Unsafe
    }

    State Dfs(int cur)
    {
        if (states[cur] == State.Visiting)
        {
            return State.Unsafe;
        }

        if (states[cur] != State.Unknown)
        {
            return states[cur];
        }

        states[cur] = State.Visiting;
        foreach (int next in graph[cur])
        {
            if ( Dfs(next) == State.Unsafe)
            {
                states[cur] = State.Unsafe;
                return State.Unsafe;
            }
        }

        states[cur] = State.Safe;
        return State.Safe;
    }

    public IList<int> EventualSafeNodes(int[][] graph)
    {
        this.graph = graph;
        n = graph.Length;
        states = Enumerable.Repeat(State.Unknown, n).ToList();
        List<int> ans = new List<int>();
        for (int i=0;i<n;i++){
            if (Dfs(i) == State.Safe)
            {
                ans.Add(i);
            }
        }
        ans.Sort();
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string graphStr, string expected)
    {
        int[][] graph = graphStr.LeetcodeToArray2D();
        string actual = new Solution().EventualSafeNodes(graph).ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,2],[2,3],[5],[0],[5],[],[]]", "[2,4,5,6]"); }
    [TestMethod] public void Test2() { TestBase("[[1,2,3,4],[1,2],[3,4],[0,4],[]]", "[4]"); }
    [TestMethod] public void Test3() { TestBase("[[1,2],[2],[]", "[0,1,2]"); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 300 ms, faster than 87.88% of C# online submissions for Find Eventual Safe States.
Memory Usage: 50.4 MB, less than 98.48% of C# online submissions for Find Eventual Safe States.
 */