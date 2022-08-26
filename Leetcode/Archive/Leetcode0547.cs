namespace Leetcode0547;

public class Solution
{
    int[][] isConnected;
    int n = 0;
    bool[] isVisited;

    private void Dfs(int i)
    {
        for (int j = 0; j < n; j++)
        {
            if (isVisited[j])
            {
                continue;
            }

            if (isConnected[i][j] == 1)
            {
                isVisited[j] = true;
                Dfs(j);
            }
        }
    }

    public int FindCircleNum(int[][] isConnected)
    {
        this.isConnected = isConnected;
        n = isConnected.Length;
        isVisited = new bool[n];

        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (isVisited[i])
            {
                continue;
            }
            Dfs(i);
            result++;
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "[[1,1,0],[1,1,0],[0,0,1]]", 2)]
    [DataRow(2, "[[1,0,0],[0,1,0],[0,0,1]]", 3)]
    [DataRow(3, "[[1]]", 1)]
    [DataRow(4, "[[0]]", 1)]
    [DataTestMethod]
    public void Test(int testId, string isConnectedStr, int expected)
    {
        int[][] isConnected = ArrayHelper.LeetcodeToArray2D(isConnectedStr);
        int actual = (new Solution()).FindCircleNum(isConnected);
        Assert.AreEqual(expected, actual);
    }
}

/*
Runtime: 114 ms, faster than 91.52% of C# online submissions for Number of Provinces.
Memory Usage: 44.9 MB, less than 7.07% of C# online submissions for Number of Provinces. 
 */