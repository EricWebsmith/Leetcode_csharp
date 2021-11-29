namespace Leetcode0079;

public class Solution
{
    int m = 0;
    int n = 0;
    string word = string.Empty;
    bool found = false;
    char[][] board;
    int[][] visited;

    public bool Exist(char[][] board, string word)
    {
        m = board.Length;
        n = board[0].Length;
        this.word = word;
        this.board = board;
        visited = new int[m][];
        for(int r = 0; r < m; r++)
        {
            visited[r] = new int[n];
            Array.Fill(visited[r], -1);
        }

        List<int[]> startPositions = new List<int[]>();
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (board[r][c] == word[0])
                {
                    startPositions.Add(new int[] { r, c });
                }
            }
        }

        foreach (int[] startPosition in startPositions)
        {
            Recurse(startPosition[0], startPosition[1], 0);
            if (found) { return true; }
        }

        return false;
    }

    private bool Recurse(int r, int c, int index)
    {
        
        if (r < 0 || r >= m) { return false; }
        if (c < 0 || c >= n) { return false; }
        if (visited[r][c]>-1) { return false; }
        if (board[r][c] != word[index]) { return false; }
        if (index == word.Length - 1) 
        { found = true;
            visited[r][c] = index;
            Helper.Print2D(visited);
            return true; 
        }

        visited[r][c] = index;



        //Helper.Print2D(visited);

        bool result = Recurse(r, c + 1, index + 1) ||
            Recurse(r, c - 1, index + 1) ||
            Recurse(r + 1, c, index + 1) ||
            Recurse(r - 1, c, index + 1);
        visited[r][c] = -1;
        return result;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(char[][] board, string word, bool expected)
    {
        bool actual = new Solution().Exist(board, word);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        char[][] board = new char[][]
        {
            new char[]{'A','B','C','E'},
            new char[]{ 'S', 'F', 'C', 'S' },
            new char[]{ 'A', 'D', 'E', 'E' }
        };

        TestBase(board, "ABCCED", true);
    }


    [TestMethod]
    public void Test2()
    {
        char[][] board = new char[][]
        {
            new char[]{'A','B','C','E'},
            new char[]{ 'S','F','C','S' },
            new char[]{ 'A', 'D', 'E', 'E' }
        };

        TestBase(board, "SEE", true);
    }

    [TestMethod]
    public void Test3()
    {
        char[][] board = new char[][]
        {
            new char[]{'A','B','C','E'},
            new char[]{'S','F','C','S' },
            new char[]{ 'A', 'D', 'E', 'E' }
        };

        TestBase(board, "ABCB", false);
    }

    [TestMethod]
    public void Test4()
    {
        char[][] board = new char[][]
        {
            new char[]{'A' }
        };

        TestBase(board, "ABCB", false);
    }

    [TestMethod]
    public void Test5()
    {
        char[][] board = new char[][]
        {
            new char[]{'A','B','C','E'},
            new char[]{'S','F','E','S' },
            new char[]{ 'A', 'D', 'E', 'E' }
        };

        TestBase(board, "ABCESEEEFS", true);
    }

}