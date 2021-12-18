namespace Leetcode0072;


public class Solution
{
    private int Min(params int[] values)
    {
        int min = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            min = Math.Min(min, values[i]);
        }
        return min;
    }

    public int MinDistance(string word1, string word2)
    {
        int n1 = word1.Length;
        int n2 = word2.Length;
        int[][] matrix = new int[n1 + 1][];
        for (int i = 0; i <= n1; i++)
        {
            matrix[i] = new int[n2 + 1];
            matrix[i][0] = i;
        }

        for (int j = 0; j < n2 + 1; j++)
        {
            matrix[0][j] = j;
        }

        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (word1[i] == word2[j])
                {
                    matrix[i + 1][j + 1] = matrix[i][j];
                }
                else
                {
                    matrix[i + 1][j + 1] = Min(matrix[i][j], matrix[i + 1][j], matrix[i][j + 1]) + 1;
                }
            }
        }

        return matrix[n1][n2];
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string word1, string word2, int expected)
    {
        int actual = new Solution().MinDistance(word1, word2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("horse", "ros", 3); }
    [TestMethod] public void Test2() { TestBase("intention", "execution", 5); }
    [TestMethod] public void Test3() { TestBase("good", "bad", 3); }
    [TestMethod] public void Test4() { TestBase("look", "book", 1); }
    [TestMethod] public void Test5() { TestBase("", "book", 4); }
    [TestMethod] public void Test6() { TestBase("", "", 0); }
}