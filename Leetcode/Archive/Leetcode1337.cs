namespace Leetcode1337;


public class Solution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        return mat.Select((row, index) => new {Soldiers= row.Sum(), RowIndex= index })
            .OrderBy(row => row.Soldiers)
            .ThenBy(row => row.RowIndex)
            .Select(row => row.RowIndex)
            .Take(k)
            .ToArray();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 144 ms, faster than 97.60% of C# online submissions for The K Weakest Rows in a Matrix.
Memory Usage: 45.2 MB, less than 10.18% of C# online submissions for The K Weakest Rows in a Matrix. 
 */