using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode0036;

public class Solution
{
    

    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char> charSet = new HashSet<char>();
        HashSet<char> rowCharSet = new HashSet<char>();
        HashSet<char> colCharSet = new HashSet<char>();

        
        for (int i = 0; i < 9; i++)
        {
            rowCharSet.Clear();
            colCharSet.Clear();
            for (int j = 0; j < 9; j++)
            {
                // horizontal
                if (board[i][j] != '.')
                {
                    if (rowCharSet.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        rowCharSet.Add(board[i][j]);
                    }
                }
                // vertical
                if (board[j][i] != '.')
                {
                    if (colCharSet.Contains(board[j][i]))
                    {
                        return false;
                    }
                    else
                    {
                        colCharSet.Add(board[j][i]);
                    }
                }

            }
        }

        // 3 by 3
        for (int i = 0; i < board.Length; i=i+3)
        {

            for (int j = 0; j < board[0].Length; j=j+3)
            {
                charSet.Clear();
                for(int a=i; a < i + 3; a++)
                {
                    for(int b=j; b < j + 3; b++)
                    {
                        if (board[a][b] == '.')
                        {
                            continue;
                        }

                        if (charSet.Contains(board[a][b]))
                        {
                            return false;
                        }
                        else
                        {
                            charSet.Add(board[a][b]);
                        }
                    }
                }
            }
        }

        return true;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(char[][] board, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.IsValidSudoku(board);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        char[][] board = new char[][]
        {
            new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        TestBase(board, true);
    }
    [TestMethod]
    public void Test2()
    {
        char[][] board = new char[][]
        {
            new char[]{'8', '3', '.', '.', '7', '.', '.', '.', '.' },
            new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        TestBase(board, false);
    }

    [TestMethod]
    public void Test3()
    {
        char[][] board = new char[][]
        {
            new char[]{'.', '.', '5', '.', '.', '.', '.', '.', '6'},
            new char[]{'.', '.', '.', '.', '1', '4', '.', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new char[]{'.', '.', '.', '.', '.', '9', '2', '.', '.'},
            new char[]{'5', '.', '.', '.', '.', '2', '.', '.', '.'},
            new char[]{'.', '.', '.', '.', '.', '.', '.', '3', '.'},
            new char[]{'.', '.', '.', '5', '4', '.', '.', '.', '.'},
            new char[]{'3', '.', '.', '.', '.', '.', '4', '2', '.'},
            new char[]{'.', '.', '.', '2', '7', '.', '6', '.', '.'}
        };

        TestBase(board, true);
    }


}
