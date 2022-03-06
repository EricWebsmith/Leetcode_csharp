namespace Leetcode6016;


public class Solution
{
    public IList<string> CellsInRange(string s)
    {
        char startLetter = s[0];
        char endLetter = s[3];
        char startDigit = s[1];
        char endDigit = s[4];

        IList<string> ans = new List<string>();
        for ( char letter = startLetter; letter <= endLetter; letter++)
        {
            for( char digit = startDigit; digit <= endDigit; digit++)
            {
                ans.Add(letter.ToString() + digit.ToString());
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