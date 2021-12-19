namespace Leetcode0797;

public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        int n = graph.Length;
        List<IList<int>> result = new List<IList<int>>();
        Queue<List<int>> q = new Queue<List<int>>();
        q.Enqueue(new List<int>() { 0 });
        while (q.Count > 0)
        {
            List<int> path = q.Dequeue();
            int last = path.Last();
            if (last == n - 1)
            {
                result.Add(path);
            }
            else
            {
                int[] nextPosiions = graph[last];
                foreach(int nextPosition in nextPosiions)
                {
                    if(!path.Contains(nextPosition))
                    {
                        List<int> newList = path.ToList();
                        newList.Add(nextPosition);
                        q.Enqueue(newList);
                    }
                }
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[[1,2],[3],[3],[]]", "[[0,1,3],[0,2,3]]")]
    [DataRow(2, "[[1,2],[3],[3],[]]", "[[0,1,3],[0,2,3]]")]
    [DataRow(3, "[[1],[]]", "[[0,1]]")]
    [DataRow(4, "[[1,2,3],[2],[3],[]]", "[[0,1,2,3],[0,2,3],[0,3]]")]
    [DataRow(5, "[[1,3],[2],[3],[]]", "[[0,1,2,3],[0,3]]")]
    [DataTestMethod]
    public void Test(int order, string graphStr, string expectedStr)
    {
        int[][] grpah = Helper.Convert2D(graphStr);
        int[][] expected = Helper.Convert2D(expectedStr);
        IList<IList<int>> actual = (new Solution()).AllPathsSourceTarget(grpah);
        Assert.AreEqual(expected.Length, actual.Count);
        
        //for(int i=0; i<actual.Count; i++)
        //{
        //    Assert.AreEqual(expected[i].Length, actual[i].Count);
        //    for(int j =0; j<actual[i].Count; j++)
        //    {
        //        Assert.AreEqual(expected[i][j], actual[i][j]);
        //    }
        //}
    }
}