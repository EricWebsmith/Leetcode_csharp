namespace Leetcode0433;


public class Solution
{
    private bool Connect(string a, string b)
    {
        int different = 0;
        for(int i=0; i < 8; i++)
        {
            if (a[i] != b[i])
            {
                different++;
            }
        }
        return different<=1;
    }

    public int MinMutation(string start, string end, string[] bank)
    {
        List<string> list = new List<string>(bank);
        list.Insert(0, start);
        int n = list.Count;
        int target = -1;
        for(int i = 0; i < n; i++)
        {
            if(end == list[i])
            {
                target = i;
                break;
            }
        }

        if(target == -1) { return -1; }


        
        bool[,] graph = new bool[n, n];
        for (int i = 0; i < n; i++)
        {
            for(int j = i+1; j < n; j++)
            {
                graph[i, j] = Connect(list[i], list[j]);
                graph[j, i] = graph[i, j];
            }
        }

        bool[] visited = new bool[n];
        //visited[0] = true;

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        int mutations = 0;
        while(q.Count > 0)
        {
            int qCount = q.Count;
            for(int i = 0;i < qCount; i++)
            {
                int cur = q.Dequeue();
                if(cur == target)
                {
                    return mutations;
                }

                if (visited[cur])
                {
                    continue;
                }

                visited[cur] = true;

                for(int next = 0; next < n; next++)
                {
                    if (graph[cur, next])
                    {
                        q.Enqueue(next);
                    }
                }
            }
            mutations++;
        }
        return -1;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string start, string end, string bankStr, int expected)
    {
        string[] bank = bankStr.LeetcodeToStringArray();
        int actual = new Solution().MinMutation(start, end, bank);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("AACCGGTT", "AACCGGTA", "[AACCGGTA]", 1); }
    [TestMethod] public void Test2() { TestBase( "AACCGGTT","AAACGGTA","[AACCGGTA,AACCGCTA,AAACGGTA]", 2); }
    [TestMethod] public void Test3() { TestBase("AAAAACCC", "AACCCCCC", "[AAAACCCC,AAACCCCC,AACCCCCC]", 3); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 93 ms, faster than 75.68% of C# online submissions for Minimum Genetic Mutation.
Memory Usage: 37 MB, less than 60.81% of C# online submissions for Minimum Genetic Mutation. 
 */