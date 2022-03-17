namespace Leetcode1779;


public class Solution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        int min = int.MaxValue;
        int ans = -1;
        for(int i = 0; i < points.Length; i++)
        {
            if(points[i][0] == x || points[i][1] == y)
            {
                int distance = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
                if(distance < min)
                {
                    min = distance;
                    ans = i;
                }
            }
        }
        return ans;
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