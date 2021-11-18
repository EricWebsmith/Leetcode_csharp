namespace Leetcode0733;

public class Solution
{
    int[][] image;
    bool[][] visited;

    private void Visit(int r, int c)
    {
        visited[r][c] = true;
        if (r + 1 < image.Length && !visited[r+1][c] && image[r + 1][c] == image[r][c])
        {
            Visit(r + 1, c);
        }

        if (r - 1 >= 0 && !visited[r - 1][c] && image[r - 1][c] == image[r][c])
        {
            Visit(r - 1, c);
        }

        if (c + 1 < image[0].Length && !visited[r ][c+1] && image[r][c + 1] == image[r][c])
        {
            Visit(r, c + 1);
        }

        if (c - 1 >= 0 && !visited[r ][c-1] && image[r][c - 1] == image[r][c])
        {
            Visit(r, c - 1);
        }

        
    }

    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        this.image = image;
        visited = new bool[image.Length][];
        for (int i = 0; i < image.Length; i++)
        {
            visited[i] = new bool[image[i].Length];
        }

        Visit(sr, sc);
        for (int i = 0; i < image.Length; i++)
        {
            for (int j = 0; j < image[i].Length; j++)
            {
                if (visited[i][j])
                {
                    image[i][j] = newColor;
                }
            }
        }

        return image;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] image, int sr, int sc, int newColor, int[][] expected)
    {
        Solution solution = new Solution();
        int[][] actual = solution.FloodFill(image, sr, sc, newColor);
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
        int[][] image = new int[][]
        {
          new int[] {1, 1, 1},
          new int[] {1, 1, 0},
          new int[] {1, 0, 1},
        };

        int[][] expected = new int[][]
        {
          new int[] {2, 2, 2},
          new int[] {2, 2, 0},
          new int[] {2, 0, 1},
        };
        TestBase(image, 1, 1, 2, expected);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] image = new int[][]
        {
          new int[] {0, 0, 0},
          new int[] {0, 0, 0}
        };

        int[][] expected = new int[][]
        {
          new int[] {2, 2, 2},
          new int[] {2, 2, 2}
        };
        TestBase(image, 0, 0, 2, expected);
    }

}
