namespace Leetcode0074;

public class Solution
{
    private bool SearchArray(int[] arr, int target)
    {
        int mid = arr.Length / 2;
        int lo = 0;
        int hi = arr.Length - 1;
        while(lo <= hi)
        {
            if(arr[mid] == target)
            {
                return true;
            }

            if(arr[mid] > target)
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }

            mid = (lo + hi) / 2;
        }
        return false;
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int mid = rows / 2;
        int lo = 0;
        int hi = rows - 1;

        while(lo <= hi)
        {
            if (target >= matrix[mid][0] && target <= matrix[mid][cols - 1])
            {
                return SearchArray(matrix[mid], target);
            }

            if(target < matrix[mid][0])
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }

            mid= (lo + hi) / 2;
        }
        return false;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] matrix, int target, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.SearchMatrix(matrix, target);
        Assert.AreEqual(expected, actual);
        
    }

    [TestMethod] 
    public void Test1() {
        int[][] matrix = new int[][] {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10,11,16,20 },
            new int[] { 23,30,34,60 }
        };
        TestBase(matrix,13, false); 
    }

    [TestMethod]
    public void Test2()
    {
        int[][] matrix = new int[][] {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10,11,16,20 },
            new int[] { 23,30,34,60 }
        };
        TestBase(matrix, 11, true);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] matrix = new int[][] {
            new int[] { 1 }
        };
        TestBase(matrix, 1, true);
    }

}
