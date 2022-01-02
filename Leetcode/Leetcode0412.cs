namespace Leetcode0412;

/// <summary>
/// Runtime: 124 ms, faster than 83.56% of C# online submissions for Fizz Buzz.
/// Memory Usage: 46.8 MB, less than 55.81% of C# online submissions for Fizz Buzz.
/// </summary>
public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        string[] ans = new string[n];
        for(int i = 1; i <= n; i++)
        {
            if(i % 15 == 0)
            {
                ans[i - 1] = "FizzBuzz";
            }
            else if(i %3 == 0)
            {
                ans[i - 1] = "Fizz";
            }
            else if(i % 5 == 0)
            {
                ans[i - 1] = "Buzz";
            }
            else
            {
                ans[i - 1] = i.ToString();
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

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}