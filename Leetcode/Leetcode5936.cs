namespace Leetcode5936;

// https://leetcode.com/contest/biweekly-contest-67/problems/detonate-the-maximum-bombs/
// now 2101

public class Solution
{
    public int MaximumDetonation(int[][] bombs)
    {
        int n = bombs.Length;
        if (n == 1) { return 1; }


        int[][] graph = new int[n][];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {

            int[] bombI = bombs[i];
            for (int j = i + 1; j < n; j++)
            {
                if (i == j)
                {
                    graph[i][j] = 1;
                    continue;
                }
                int[] bombJ = bombs[j];
                long x = bombI[0] - bombJ[0];
                long y = bombI[1] - bombJ[1];
                long distance2 = x * x + y * y;
                if (distance2 <= bombI[2] * bombI[2])
                {
                    graph[i][j] = 1;
                }

                if (distance2 <= bombJ[2] * bombJ[2])
                {
                    graph[j][i] = 1;
                }
            }
        }

        int maxCount = 0;
        for (int i = 0; i < n; i++)
        {
            //bfs
            int count = 0;
            bool[] visited = new bool[n];
            // first bomb of chain 
            visited[i] = true;
            Queue<int> q = new Queue<int>();
            q.Enqueue(i);
            while (q.Count > 0)
            {
                int index = q.Dequeue();
                count++;
                for (int j = 0; j < n; j++)
                {
                    if (visited[j])
                    {
                        continue;
                    }

                    if (graph[index][j] == 1)
                    {

                        q.Enqueue(j);
                        visited[j] = true;
                    }
                }
            }

            if (count == n)
            {
                return count;
            }

            maxCount = Math.Max(maxCount, count);
        }


        return maxCount;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string bombsStr, int expected)
    {
        int[][] bombs = bombsStr.LeetcodeToArray2D();
        int actual = new Solution().MaximumDetonation(bombs);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[2,1,3],[6,1,4]]", 2); }
    [TestMethod] public void Test2() { TestBase("[[1,1,5],[10,10,5]]", 1); }
    [TestMethod] public void Test3() { TestBase("[[1,2,3],[2,3,1],[3,4,2],[4,5,3],[5,6,4]]", 5); }
    [TestMethod] public void Test4() { TestBase("[[6,1,4],[2,1,3]]", 2); }
    [TestMethod] public void Test5() { TestBase("[[10,10,5],[1,1,5]]", 1); }
    [TestMethod] public void Test6() { TestBase("[[4,5,3],[5,6,4],[1,2,3],[2,3,1],[3,4,2]]", 5); }
    [TestMethod] public void Test7() { TestBase("[[85024,58997,3532],[65196,42043,9739],[85872,75029,3117],[73014,91183,7092],[29098,40864,7624],[11469,13607,4315],[98722,69681,9656],[75140,42250,421],[92580,44040,4779],[58474,78273,1047],[27683,4203,6186],[10714,24238,6243],[60138,81791,3496],[16227,92418,5622],[60496,64917,2463],[59241,62074,885],[11961,163,5815],[37757,43214,3402],[21094,98519,1678],[49368,22385,1431],[6343,53798,159],[80129,9282,5139],[69565,32036,6827],[59372,64978,6575],[44948,71199,7095],[46390,91701,1667],[37144,98691,8128],[13558,81505,4653],[41234,48161,9304],[14852,3206,5369]]", 3); }

}