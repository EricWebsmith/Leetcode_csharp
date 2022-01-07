namespace Leetcode0130;

public class Solution
{
    int m;
    int n;
    char[][] board;

    int[][] dirs = new int[][]
    {
        new int[] { 1, 0 },
        new int[] { -1, 0 },
        new int[] { 0, 1 },
        new int[] { 0, -1 }
    };

    private void Dfs(int r, int c)
    {
        if (r < 0 || r >= m || c < 0 || c >= n)
        {
            return;
        }

        if(board[r][c] != 'O')
        {
            return;
        }
        board[r][c] = 'T';
        Dfs(r-1, c);
        Dfs(r+1, c);
        Dfs(r, c-1);
        Dfs(r, c+1);
    }

    public void Solve(char[][] board)
    {
        this.board = board;
        m = board.Length;
        n = board[0].Length;

        // 1. (DFS) Capture unsurrounded regions ( O -> T)
        foreach (int c in new int[] { 0, n - 1 })
        {
            for (int r = 0; r < m; r++)
            {
                if (board[r][c] == 'O') { Dfs(r, c); }
            }
        }

        foreach (int r in new int[] { 0, m - 1 })
        {
            for (int c = 1; c < n-1; c++)
            {
                if (board[r][c] == 'O') { Dfs(r, c); }
            }
        }

        //Console.WriteLine("-------------------------");
        //Helper.Print2D(board);

        // 2. Capture surrounded regions (O -> X)
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; (c < n); c++)
            {
                if (board[r][c] == 'O') { board[r][c] = 'X'; }
            }
        }
        //Console.WriteLine("-------------------------");
        //Helper.Print2D(board);

        // 3. Uncapture unsurrounded regions (T -> O)
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; (c < n); c++)
            {
                if (board[r][c] == 'T') { board[r][c] = 'O'; }
            }
        }
        //Console.WriteLine("-------------------------");
        //Helper.Print2D(board);
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(char[][] board, char[][] expected)
    {
        Solution solution = new Solution();
        solution.Solve(board);
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                Assert.AreEqual(expected[r][c], board[r][c]);
            }
        }
    }

    [TestMethod]
    public void Test1()
    {
        char[][] board = new char[][]
        {
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'O', 'O', 'X'},
            new char[]{'X', 'X', 'O', 'X'},
            new char[]{'X', 'O', 'X', 'X'},
        };

        char[][] expected = new char[][]
        {
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'O', 'X', 'X'},
        };

        TestBase(board, expected);
    }

    [TestMethod]
    public void Test2()
    {
        char[][] board = new char[][]
        {
            new char[]{'X'},
        };

        char[][] expected = new char[][]
        {
            new char[]{'X'},
        };

        TestBase(board, expected);
    }

    [TestMethod]
    public void Test3()
    {
        char[][] board = new char[][]
        {
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'O', 'O', 'X'},
            new char[]{'X', 'X', 'O', 'X'},
            new char[]{'X', 'O', 'O', 'X'},
        };

        char[][] expected = new char[][]
        {
            new char[]{'X', 'X', 'X', 'X'},
            new char[]{'X', 'O', 'O', 'X'},
            new char[]{'X', 'X', 'O', 'X'},
            new char[]{'X', 'O', 'O', 'X'},
        };

        TestBase(board, expected);
    }
}