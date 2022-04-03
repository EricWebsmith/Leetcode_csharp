namespace Leetcode1466;


public class Solution
{
    public int MinReorder(int n, int[][] connections)
    {
        Dictionary<int, List<int>> originDict = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> destinationDict = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++)
        {
            originDict.Add(i, new List<int>());
            destinationDict.Add(i,new List<int>());
        }

        foreach(int[] connection in connections)
        {
            originDict[connection[1]].Add(connection[0]);
            destinationDict[connection[0]].Add(connection[1]);
        }

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        bool[] visited = new bool[n];
        int qCount = q.Count;
        int changeCount  = 0;
        while(qCount > 0)
        {
            while (qCount > 0)
            {
                int current = q.Dequeue();

                foreach(int destination in destinationDict[current])
                {
                    if (!visited[destination])
                    {
                        q.Enqueue(destination);
                        changeCount++;
                    }
                }

                foreach(int origin in originDict[current])
                {
                    q.Enqueue(origin);
                }

                visited[current] = true;
                qCount--;
            }

            qCount = q.Count;
        }

        return changeCount;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 508 ms, faster than 58.33% of C# online submissions for Reorder Routes to Make All Paths Lead to the City Zero.
Memory Usage: 77.1 MB, less than 13.09% of C# online submissions for Reorder Routes to Make All Paths Lead to the City Zero. 
 */