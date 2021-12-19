namespace Leetcode0059;

public class Solution
{
    const int EAST = 0;
    const int SOUTH = 1;
    const int WEST = 2;
    const int NORTH = 3;

    public int[][] GenerateMatrix(int n)
    {
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        int x = 0;
        int y = 0;

        int direction = EAST;
        int index = 1;
        matrix[y][x] = 1;
        while (index < n * n)
        {
            if (direction == EAST)
            {

                if (x + 1 < n && matrix[y][x + 1] == 0)
                {
                    x++;
                    index++;
                    matrix[y][x] = index;

                }
                else
                {
                    direction = SOUTH;
                }
            }
            else if (direction == SOUTH)
            {
                if (y + 1 < n && matrix[y + 1][x] == 0)
                {
                    y++;
                    index++;
                    matrix[y][x] = index;
                }
                else
                {
                    direction = WEST;
                }
            }
            else if (direction == WEST)
            {
                if (x - 1 >= 0 && matrix[y][x - 1] == 0)
                {
                    x--;
                    index++;
                    matrix[y][x] = index;
                }
                else
                {
                    direction = NORTH;
                }
            }
            else if (direction == NORTH)
            {
                if (y - 1 >= 0 && matrix[y - 1][x] == 0)
                {
                    y--;
                    index++;
                    matrix[y][x] = index;
                }
                else
                {
                    direction = EAST;
                }
            }
        }

        return matrix;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void Test3()
    {
        Solution solution = new Solution();
        int[][] expected = new int[][]
        {
            new int[]{ 1,2,3 },
            new int[]{ 8,9,4 },
            new int[]{ 7,6,5 }
        };

        int[][] actual = solution.GenerateMatrix(3);
        foreach (int[] line in actual)
        {
            Console.WriteLine($"-------------{3}-----------");
            string sline = string.Join(",", line.Select(x => x.ToString()));
            Console.WriteLine(line);
        }

        Assert.AreEqual(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        }
    }

    [TestMethod]
    public void Test()
    {
        Solution solution = new Solution();

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine($"-------------{i}-----------");
            int[][] actual = solution.GenerateMatrix(i);
            foreach (int[] line in actual)
            {

                string sline = string.Empty;
                for (int j = 0; j < line.Length; j++)
                {
                    sline += line[j].ToString("000") + ",";
                }

                Console.WriteLine(sline);
            }
        }

    }
}