namespace Leetcode1678;


public class Solution
{
    public string Interpret(string command)
    {
        return command.Replace("()", "o").Replace("(al)", "al");
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
Runtime: 64 ms, faster than 99.22% of C# online submissions for Goal Parser Interpretation.
Memory Usage: 36.8 MB, less than 16.02% of C# online submissions for Goal Parser Interpretation. 
 */