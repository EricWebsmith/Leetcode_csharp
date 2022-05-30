﻿namespace Leetcode1129;


public class Solution
{
    const bool RED = false;
    const bool BLUE = true;

    Dictionary<int, List<int>> redEdgeDict = new Dictionary<int, List<int>>();
    Dictionary<int, List<int>> blueEdgeDict = new Dictionary<int, List<int>>();
    bool[] redVisiting = null;
    bool[] blueVisiting = null;

    List<int> path = new List<int>();

    int[] ans = null;
 
    private void Dfs(bool color)
    {
        //alternating
        Dictionary<int, List<int>> edgeDict = color == BLUE ? blueEdgeDict: redEdgeDict;
        bool[] visiting = color == BLUE ? blueVisiting: redVisiting ;

        int last = path.Last();
        ans[last] = Math.Min(ans[last], path.Count - 1);
        //blueVisiting.Print1D();
        //redVisiting.Print1D();
        //path.Print1D();

        if (visiting[last] == true)
        {
            return;
        }
        visiting[last] = true;
        //List<int> candidates = edgeDict[last];
        foreach (int next in edgeDict[last])
        {
            path.Add(next);
            Dfs(!color);
            path.RemoveAt(path.Count - 1);
        }
        visiting[last] =false;
    }

    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        for (int i = 0; i < n; i++)
        {
            redEdgeDict[i] = new List<int>();
            blueEdgeDict[i] = new List<int>();
        }

        foreach (int[] edge in redEdges)
        {
            redEdgeDict[edge[0]].Add(edge[1]);
        }

        foreach (int[] edge in blueEdges)
        {
            blueEdgeDict[edge[0]].Add(edge[1]);
        }

        ans = new int[n];
        redVisiting = new bool[n];
        blueVisiting = new bool[n];
        Array.Fill(ans, int.MaxValue);

        path.Add(0);
        Dfs(RED);
        Dfs(BLUE);
        for (int i = 0; i < n; ++i)
        {
            if (ans[i] == int.MaxValue)
            {
                ans[i] = -1;
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, string redEdgesStr, string blueEdgesStr, string expected)
    {
        int[][] redEdges = redEdgesStr.LeetcodeToArray2D();
        int[][] blueEdges = blueEdgesStr.LeetcodeToArray2D();
        string actual = new Solution().ShortestAlternatingPaths(n, redEdges, blueEdges).ToLeetcode();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(3, "[[0,1],[1,2]]", "[]", "[0,1,-1]"); }
    [TestMethod] public void Test2() { TestBase(3, "[[0,1]]", "[[2,1]]", "[0,1,-1]"); }
    string test3redEdges = "[[21,64],[74,59],[29,42],[74,22],[12,7],[4,1],[72,57],[51,62],[55,39],[2,98],[20,47],[4,34],[71,47],[65,67],[5,24],[88,29],[83,57],[11,69],[84,24],[10,19],[93,47],[31,34],[49,65],[19,6],[32,60],[58,77],[59,11],[49,19],[94,6],[71,66],[45,38],[63,18],[75,90],[9,1],[14,35],[75,6],[59,80],[61,38],[2,14],[64,82],[14,25],[78,72],[82,78],[49,2],[28,33],[51,56],[42,18],[78,4],[49,7],[7,46],[93,9],[2,23],[73,75],[69,32],[12,6],[69,76],[91,44],[17,70],[98,98],[20,87],[95,91],[9,88],[77,47],[71,80],[10,2],[23,51],[67,81],[33,12],[2,66],[65,68],[88,94],[73,23],[36,18],[76,98],[77,0],[96,3],[22,30],[54,94],[3,42],[14,70],[80,30],[81,80],[61,74],[58,58],[43,22],[10,84],[18,13],[71,20],[10,61],[72,48],[79,65],[31,88],[66,76],[73,30],[45,6],[21,79],[8,95],[40,22],[34,1],[25,43]]";
    string test3blueEdges = "[[34,45],[78,57],[98,17],[8,14],[78,65],[69,14],[91,1],[38,22],[91,89],[84,37],[76,3],[76,75],[45,46],[75,52],[68,34],[84,45],[67,77],[41,70],[18,99],[41,28],[18,16],[65,20],[12,61],[22,50],[28,1],[26,3],[73,49],[85,0],[53,78],[58,53],[21,27],[14,21],[66,40],[65,33],[85,2],[95,90],[65,52],[92,58],[48,48],[10,97],[90,85],[74,22],[79,79],[80,10],[14,82],[82,51],[74,86],[60,57],[60,48],[13,91],[61,19],[10,21],[85,5],[57,74],[20,1],[24,18],[4,55],[67,63],[5,25],[93,29],[25,18],[77,10],[93,26],[98,53],[77,55],[9,1],[68,11],[23,2],[38,77],[7,63],[73,93],[38,89],[42,28],[33,27],[49,38],[60,64],[79,35],[11,15],[47,27],[52,3],[7,36],[27,13],[19,50],[96,3],[26,21],[68,19],[97,3],[76,54],[47,58],[47,80],[55,63],[21,41],[93,43],[83,87],[60,26],[42,8],[88,23],[73,23],[83,6],[64,97],[88,16],[10,33],[74,21],[90,13],[0,5],[16,67],[46,20],[43,50],[31,91],[4,30],[7,97],[1,13],[94,15],[98,45],[58,62],[39,82],[38,56],[5,31],[16,19],[24,49],[46,71],[29,36],[64,49],[31,78],[12,11],[9,69],[58,55],[71,26],[31,48],[5,79],[19,71],[11,10],[99,37],[34,26],[45,78],[92,26],[80,63],[60,95],[43,48],[41,48],[39,7],[26,12],[73,74],[39,62],[8,6],[95,95],[58,44],[73,15],[42,91],[39,15],[77,73],[72,39],[63,67],[64,71],[49,1],[30,83],[31,24],[3,96],[35,48],[88,97],[82,30],[35,2],[82,76],[24,11],[7,53],[39,31],[36,87],[23,20],[66,50],[13,45],[41,75],[67,10],[81,52],[76,25],[5,12],[74,78],[66,21],[7,27],[81,35],[7,10],[75,24],[69,13],[72,70],[89,24],[39,41],[14,5],[34,11],[32,41],[72,87],[55,25],[92,46],[45,74],[53,84],[8,60],[49,79],[30,31],[5,83],[52,14],[18,88],[60,82],[70,41],[77,22],[66,6],[5,0],[8,13],[45,51],[69,32],[47,37],[87,59],[46,57],[91,21],[19,14],[50,12],[18,45],[37,42],[2,45],[8,1],[79,94],[61,68],[19,44],[97,8],[25,67],[3,22],[39,40],[75,56],[93,28],[95,24],[12,32],[27,14],[84,38],[51,17],[21,12],[45,58],[80,20],[43,8],[73,20],[5,4],[70,43],[61,33],[99,73],[34,17],[55,49],[32,75],[43,93],[42,82],[13,3],[81,17],[53,46],[48,12],[6,49],[46,73],[22,13],[67,73],[16,39],[29,41],[47,31],[89,97],[77,23],[91,58],[14,8],[20,14],[88,35],[41,8],[41,0],[48,14],[15,23],[48,56],[4,69],[61,6],[76,41],[10,70],[98,93],[86,39],[93,44],[83,45],[71,50],[52,17],[53,76],[92,61],[20,56],[70,26],[67,44],[15,11],[15,6],[15,30],[62,68],[2,29],[40,93],[48,47],[33,36],[47,23],[33,76],[94,18],[64,20],[70,55],[47,49],[8,3],[72,0],[27,27],[80,81],[94,80],[12,43],[12,97],[67,26],[82,59],[58,24],[71,74],[27,66],[6,4],[69,33],[17,49],[37,29],[46,58],[75,8],[0,40],[1,32],[33,7],[80,24],[43,55],[76,32],[89,60],[50,69],[64,64],[34,21],[3,42],[51,61],[7,88],[38,18],[56,61],[15,89],[62,88],[73,37],[74,48],[15,22],[13,53]]";
    [TestMethod] public void Test3() { TestBase(100, test3redEdges, test3blueEdges, ""); }
    [TestMethod] public void Test4() { TestBase(3, "[[0,1],[2,0]]", "[[1,2]]", "[0,1,2]"); }
    [TestMethod] public void Test5() { TestBase(3, "[[0,1],[2,1]]", "[[1,2]]", "[0,1,2]"); }
    [TestMethod] public void Test6() { TestBase(3, "[[0,1],[1,2],[2,0]]", "[[0,1],[1,2],[2,0]]", "[0,1,2]"); }
    [TestMethod] public void Test7() { TestBase(4, "[[0,1],[2,3]]", "[1,2],[3,0]]", "[0,1,2,3]"); }

}