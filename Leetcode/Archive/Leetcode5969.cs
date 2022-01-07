namespace Leetcode5969;


public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        Array.Sort(asteroids);
        int n = asteroids.Length;
        for (int i = 0; i < n; i++)
        {
            if (mass < asteroids[i])
            {
                return false;
            }

            mass += asteroids[i];
        }
        return true;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}