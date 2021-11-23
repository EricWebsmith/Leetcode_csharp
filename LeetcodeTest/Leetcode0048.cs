namespace Leetcode0048;

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            for (int i = 0; i < right - left; i++)
            {
                int top = left;
                int bottom = right;
                /*
                 for matrix
                1,2,3
                4,5,6
                7,8,9
                 */

                // temp = 1
                int temp = matrix[top][left + i];
                // 1 = 7
                matrix[top][left + i] = matrix[bottom - i][left];
                // 7 = 9
                matrix[bottom - i][left] = matrix[bottom][right - i];
                // 9 = 3
                matrix[bottom][right - i] = matrix[top + i][right];
                // 3 = temp
                matrix[top + i][right] = temp;
                /*
                 temp = 1
                1 = 7
                7 = 9
                9 = 3
                3 = temp
                 */
            }



            left++;
            right--;
        }

    }
}

[TestClass]
public class MyTestClass
{
    [DataRow(1, "[[1,2,3],[4,5,6],[7,8,9]]", "[[7,4,1],[8,5,2],[9,6,3]]")]
    [DataRow(2, "[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]", "[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]")]
    [DataRow(3, "[[1]]", "[[1]]")]
    [DataRow(4, "[[1,2],[3,4]]", "[[3,1],[4,2]]")]
    [DataRow(5,
        "[[2,29,20,26,16,28],[12,27,9,25,13,21],[32,33,32,2,28,14],[13,14,32,27,22,26],[33,1,20,7,21,7],[4,24,1,6,32,34]]",
        "[[4,33,13,32,12,2],[24,1,14,33,27,29],[1,20,32,32,9,20],[6,7,27,2,25,26],[32,21,22,28,13,16],[34,7,26,14,21,28]]"
        )]
    [DataTestMethod]
    public void Test(int order, string matrixStr, string expectedStr)
    {
        int[][] matrix = Helper.Convert2D(matrixStr);
        int[][] expected = Helper.Convert2D(expectedStr);
        Solution solution = new Solution();
        solution.Rotate(matrix);
        Assert.AreEqual(expected.Length, matrix.Length);
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Assert.AreEqual(matrix[i][j], expected[i][j]);
            }
        }
    }
}


/*

[[1,2,3],[4,5,6],[7,8,9]]
[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
[[1]]
[[1,2],[3,4]]
[[2,29,20,26,16,28],[12,27,9,25,13,21],[32,33,32,2,28,14],[13,14,32,27,22,26],[33,1,20,7,21,7],[4,24,1,6,32,34]]

 */