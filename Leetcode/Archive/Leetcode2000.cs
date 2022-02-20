namespace Leetcode2000;


public class Solution
{
    public string ReversePrefix(string word, char ch)
    {
        int index = word.IndexOf(ch);
        if(index == -1) { return word; }
        StringBuilder sb = new StringBuilder(word);
        for(int i=0; i<=index/2; i++)
        {
            char t = sb[i];
            sb[i] = sb[index - i];
            sb[index-i] = t;
        }
        return sb.ToString();
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