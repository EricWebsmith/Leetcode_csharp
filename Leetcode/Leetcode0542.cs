namespace Leetcode0542;

public class Solution
{
    [DebuggerDisplay("{x} {y}")]
    private struct Position
    {
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x;
        public int y;
    }

    public int[][] UpdateMatrix(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int visits = 0;

        int[][] result = new int[mat.Length][];
        for (int i = 0; i < mat.Length; i++)
        {
            result[i] = new int[mat[i].Length];
            Array.Fill(result[i], -1);
        }

        List<Position> positions = new List<Position>();

        // first find all zeros
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    result[i][j] = 0;
                    visits++;
                    positions.Add(new Position(i, j));
                }
            }
        }

        int current = 1;

        while (visits < m * n)
        {
            List<Position> newPositions = new List<Position>();
            foreach (Position p in positions)
            {
                // east
                if (p.x + 1 < m && result[p.x + 1][p.y] == -1)
                {
                    result[p.x + 1][p.y] = current;
                    visits++;
                    newPositions.Add(new Position(p.x + 1, p.y));
                }

                // south
                if (p.y + 1 < n && result[p.x][p.y + 1] == -1)
                {
                    result[p.x][p.y + 1] = current;
                    visits++;
                    newPositions.Add(new Position(p.x, p.y + 1));
                }

                // west
                if (p.x - 1 >= 0 && result[p.x - 1][p.y] == -1)
                {
                    result[p.x - 1][p.y] = current;
                    visits++;
                    newPositions.Add(new Position(p.x - 1, p.y));
                }

                // north
                if (p.y - 1 >= 0 && result[p.x][p.y - 1] == -1)
                {
                    result[p.x][p.y - 1] = current;
                    visits++;
                    newPositions.Add(new Position(p.x, p.y - 1));
                }
            }

            positions = newPositions;
            current++;
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] mat, int[][] expected)
    {
        Solution solution = new Solution();
        int[][] actual = solution.UpdateMatrix(mat);
        for (int i = 0; i < actual.Length; i++)
        {
            for (int j = 0; j < actual[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] mat = new int[][]
        {
            new int[] {0, 0, 0},
            new int[] {0, 1, 0},
            new int[] {0, 0, 0}
        };

        int[][] expected = new int[][]
        {
            new int[] {0, 0, 0},
            new int[] {0, 1, 0},
            new int[] {0, 0, 0 }
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] mat = new int[][]
        {
            new int[] {0, 0, 0},
            new int[] {0, 1, 0},
            new int[] {1, 1, 1}
        };

        int[][] expected = new int[][]
        {
            new int[] {0, 0, 0},
            new int[] {0, 1, 0},
            new int[] {1, 2, 1 }
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] mat = new int[][]
        {
            new int[] {1, 1, 1},
            new int[] {1, 0, 1},
            new int[] {1, 1, 1}
        };

        int[][] expected = new int[][]
        {
            new int[] {2, 1,2 },
            new int[] {1, 0, 1},
            new int[] {2, 1, 2 }
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test4()
    {
        int[][] mat = new int[][]
        {
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 0, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1}
        };

        int[][] expected = new int[][]
        {
            new int[] {4, 3, 2, 3, 4},
            new int[] {3, 2, 1, 2, 3},
            new int[] {2, 1, 0, 1, 2},
            new int[] {3, 2, 1, 2, 3},
            new int[] {4, 3, 2, 3, 4}
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test5()
    {
        int[][] mat = new int[][]
        {
            new int[] {0, 1, 1, 1, 0},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {0, 1, 1, 1, 0}
        };

        int[][] expected = new int[][]
        {
            new int[] {0, 1, 2, 1, 0},
            new int[] {1, 2, 3, 2, 1},
            new int[] {2, 3, 4, 3, 2},
            new int[] {1, 2, 3, 2, 1},
            new int[] {0, 1, 2, 1, 0}
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test6()
    {
        int[][] mat = new int[][]
        {
            new int[] {0, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 0, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1}
        };

        int[][] expected = new int[][]
        {
            new int[] {0, 1, 2, 3, 4},
            new int[] {1, 2, 1, 2, 3},
            new int[] {2, 1, 0, 1, 2},
            new int[] {3, 2, 1, 2, 3},
            new int[] {4, 3, 2, 3, 4}
        };
        TestBase(mat, expected);
    }

    [TestMethod]
    public void Test7()
    {
        int[][] mat = new int[][]
        {
            new int[] {0}
        };

        int[][] expected = new int[][]
        {
            new int[] {0}
        };
        TestBase(mat, expected);
    }
}
