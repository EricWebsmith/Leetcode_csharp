namespace Leetcode5946;

public class Solution
{
    public int MostWordsFound(string[] sentences)
    {
        int maxLength = 0;
        foreach(string sentence in sentences)
        {
            int length = 0;
            for(int i = 1; i<sentence.Length; i++)
            {
                if(sentence[i] ==' ')
                {
                    length++;
                }
            }
            maxLength = Math.Max(maxLength, length);
        }
        return maxLength+1;
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